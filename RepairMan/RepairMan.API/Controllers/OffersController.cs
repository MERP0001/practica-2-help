using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.Business.Common;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Repairing;
using RepairMan.Services.Motoring;
using RepairMan.Services.Repairing;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        public readonly IOfferService _service;
        private readonly IWorkshopService _workshopService;
        private readonly IUserControlLogic _userControlLogic;

        public OffersController(IOfferService service, IWorkshopService workshopService, IUserControlLogic userControlLogic)
        {
            _service = service;
            _workshopService = workshopService;
            _userControlLogic = userControlLogic;
        }

        /// <summary>
        /// Retorna todas las ofertas.
        /// </summary>
        /// <param name="description">Descripcion de la oferta</param>
        /// <param name="fromPrice">Precio minimo</param>
        /// <param name="toPrice">Precio maximo</param>
        /// <param name="workshopId">Taller</param>
        /// <param name="criteria">Criterio general</param>
        /// <returns>Las ofertas que coincidan</returns>
        [HttpGet]
        public IActionResult All(string description = null, decimal? fromPrice = null, decimal? toPrice = null, Guid? workshopId = null, string criteria = null)
        {
            return Ok(_service.All(x =>
                 (description == null || x.Description.Contains(description, StringComparison.InvariantCultureIgnoreCase)) &&
                 (fromPrice == null || x.Price >= fromPrice) &&
                 (toPrice == null || x.Price <= toPrice) &&
                 (workshopId == null || x.WorkshopId == workshopId) &&
                 (criteria == null || (x.Keywords.Contains(criteria, StringComparison.InvariantCultureIgnoreCase) || x.Description.Contains(criteria, StringComparison.InvariantCultureIgnoreCase)))
            ));
        }

        /// <summary>
        /// Retorna una oferta especifica por su id.
        /// </summary>
        /// <param name="id">Id de la oferta</param>
        /// <returns>Oferta solicitada</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var vehicleOffer = _service.Get(id);
            if (vehicleOffer == null)
                return NotFound();
            return Ok(vehicleOffer);
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

            var offer = _service.Get(id);
            var workshop = _workshopService.Get(offer.WorkshopId);
            if (workshop.OwnerId != authenticatedUser.UserId && !authenticatedUser.Roles.Contains(UserRole.Administrator))
            {
                return Unauthorized();
            }

            if (offer == null)
                return NotFound();

            _service.Delete(offer);
            return NoContent();
        }

        /// <summary>
        /// Crea un taller
        /// </summary>
        /// <param name="offer">El taller</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Create(Offer offer)
        {
            var authenticatedUser = _userControlLogic.GetUserByIdentity(User.Identity);
            var wokshop = _workshopService.Get(offer.WorkshopId);
            if (wokshop.OwnerId != authenticatedUser.UserId && !authenticatedUser.Roles.Contains(UserRole.Administrator))
            {
                return Unauthorized();
            }

            try
            {
                _service.Create(offer);
                return CreatedAtAction(nameof(GetById), new { id = offer.WorkshopId }, offer);
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
        /// <param name="offer">Nuevo taller</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Update(Guid id, Offer offer)
        {
            var authenticatedUser = _userControlLogic.GetUserByIdentity(User.Identity);

            var existingOffer = _service.Get(id);

            var workshop = _workshopService.Get(existingOffer.WorkshopId);

            if (workshop.OwnerId != authenticatedUser.UserId && !authenticatedUser.Roles.Contains(UserRole.Administrator))
            {
                return Unauthorized();
            }

            if (existingOffer == null)
            {
                return NotFound();
            }
            try
            {
                _service.Update(offer);
                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
