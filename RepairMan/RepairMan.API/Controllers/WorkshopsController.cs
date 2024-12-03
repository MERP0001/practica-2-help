using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.Business.Common;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Motoring;
using RepairMan.DataClasses.Repairing;
using RepairMan.Services.Motoring;
using RepairMan.Services.Repairing;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        /// <summary>
        /// Servicio para interaccion con el acceso a datos de talleres.
        /// </summary>
        public readonly IWorkshopService _service;
        private readonly IUserControlLogic _userControlLogic;

        public WorkshopsController(IWorkshopService service, IUserControlLogic userControlLogic)
        {
            _service = service;
            _userControlLogic = userControlLogic;
        }

        private double DistanceTo(Geoposition baseCoordinates, Geoposition targetCoordinates)
        {
            if(baseCoordinates == null || targetCoordinates == null)
                return 0;

            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.34;
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = UserRole.Administrator)]
        public IActionResult All(string name = null, string description = null, string brandName = null, string modelName = null, string categoryName = null, Guid? categoryId = null, Guid? modelId = null, Guid? brandId = null, Guid? ownerId = null, string criteria = null, float? latitude = null, float? longitude = null, int? skip = null, int? max = null)
        {
            var canSeeAll = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = _userControlLogic.GetUserByIdentity(User.Identity);
                canSeeAll = user.Roles.Contains(UserRole.Administrator);
            }

            var results = _service.All(workshop =>
                 (canSeeAll || workshop.IsActive == true || (User.Identity.IsAuthenticated && workshop.OwnerId == Guid.Parse(User.Identity.Name))) &&
                 (name == null || workshop.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)) &&
                 (description == null || (workshop.Description ?? "").Contains(description, StringComparison.InvariantCultureIgnoreCase)) &&
                 (brandName == null || workshop.BrandSpecializations.Any(z => z.Brand.Name.Contains(brandName, StringComparison.InvariantCultureIgnoreCase))) &&
                 (modelName == null || workshop.ModelSpecializations.Any(z => z.Model.Name.Contains(modelName, StringComparison.InvariantCultureIgnoreCase))) &&
                 (categoryName == null || workshop.Categorization.Any(z => z.WorkshopCategory.Name.Contains(categoryName, StringComparison.InvariantCultureIgnoreCase))) &&
                 (categoryId == null || workshop.Categorization.Any(z => z.WorkshopCategory.WorkshopCategoryId == categoryId)) &&
                 (modelId == null || workshop.ModelSpecializations.Any(z => z.ModelId == modelId)) &&
                 (brandId == null || workshop.BrandSpecializations.Any(z => z.BrandId == brandId)) &&
                 (ownerId == null || workshop.OwnerId == ownerId) &&
                 (criteria == null || workshop.Categorization.Any(x => x.WorkshopCategory.Name.Contains(criteria, StringComparison.InvariantCultureIgnoreCase))
                                   || workshop.ModelSpecializations.Any(z => z.Model.Name.Contains(criteria, StringComparison.InvariantCultureIgnoreCase))
                                   || workshop.BrandSpecializations.Any(z => z.Brand.Name.Contains(criteria, StringComparison.InvariantCultureIgnoreCase))
                                   || (workshop.Name ?? "").Contains(criteria, StringComparison.InvariantCultureIgnoreCase)
                                   || (workshop.Description ?? "").Contains(criteria, StringComparison.InvariantCultureIgnoreCase)
                                   || (workshop.Contact.Address ?? "").Contains(criteria))
            );

            if (latitude != null && longitude != null)
            {
                var userPosition = new Geoposition(latitude.Value, longitude.Value);
                results = results.OrderBy(x => DistanceTo(x.Geoposition, userPosition));
            }

            if (skip != null)
            {
                results = results.Skip(skip.Value);
            }

            if (max != null) {
                results = results.Take(max.Value);
            }

            return Ok(results);
        }

        /// <summary>
        /// Obtiene un taller por su identificacion
        /// </summary>
        /// <param name="id">Identificacion</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var workshop = _service.Get(id);
            if (workshop == null)
                return NotFound();
            return Ok(workshop);
        }

        /// <summary>
        /// Elimina un taller especifico por su identificacion
        /// </summary>
        /// <param name="id">identificacion</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteById(Guid id)
        {
            var authenticatedUser = _userControlLogic.GetUserByIdentity(User.Identity);

            var workshop = _service.Get(id);
            if (workshop.OwnerId != authenticatedUser.UserId)
            {
                return Unauthorized();
            }

            if (workshop == null)
                return NotFound();

            _service.Delete(workshop);
            return NoContent();
        }

        /// <summary>
        /// Crea un taller
        /// </summary>
        /// <param name="workshop">El taller</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Create(Workshop workshop)
        {
            var authenticatedUser = _userControlLogic.GetUserByIdentity(User.Identity);
            try
            {
                workshop.OwnerId = authenticatedUser.UserId;
                _service.Create(workshop);
                if(!authenticatedUser.Roles.Contains(UserRole.BusinessOwner)) { 
                    authenticatedUser.Roles.Add(UserRole.BusinessOwner);
                }
                _userControlLogic.UpdateUser(authenticatedUser);
                return CreatedAtAction(nameof(GetById), new { id = workshop.WorkshopId }, workshop);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception);
            }
        }


        /// <summary>
        /// Actualiza un taller
        /// </summary>
        /// <param name="id">Identificacion del taller</param>
        /// <param name="workshop">Nuevo taller</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Update(Guid id, Workshop workshop)
        {
            var authenticatedUser = _userControlLogic.GetUserByIdentity(User.Identity);

            var existingWorkshop = _service.Get(id);

            if (existingWorkshop.OwnerId != authenticatedUser.UserId && !authenticatedUser.Roles.Contains(UserRole.Administrator))
            {
                return Unauthorized();
            }


            if (existingWorkshop == null)
            {
                return NotFound();
            }
            try
            {
                _service.Update(workshop);
                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
