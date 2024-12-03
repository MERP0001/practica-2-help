using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Motoring;
using RepairMan.DataClasses.Repairing;
using RepairMan.Services.Repairing;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopCategoriesController : ControllerBase
    {
        private readonly IWorkshopCategoryService _service;

        public WorkshopCategoriesController(IWorkshopCategoryService workshopCategoryService)
        {
            _service = workshopCategoryService;
        }

        /// <summary>
        /// Retorna todas las categorias de taller o las filtra.
        /// </summary>
        /// <param name="name">Nombre de la categoria</param>
        /// <returns>Las categorias de taller</returns>
        [HttpGet]
        public IActionResult All(string name = null)
        {
            return Ok(_service.All(x =>
                 (name == null || x.Name.IndexOf(name) > -1)
            ));
        }

        /// <summary>
        /// Reorna una categoria por su id
        /// </summary>
        /// <param name="id">Identificacion de la categoria</param>
        /// <returns>Una categoria</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var workshopCategory = _service.Get(id);
            if (workshopCategory == null)
                return NotFound();
            return Ok(workshopCategory);
        }


        /// <summary>
        /// Permite crear una categoria
        /// </summary>
        /// <param name="category">Una categoria</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = UserRole.Administrator)]
        public IActionResult Create(WorkshopCategory category)
        {
            try
            {
                var createdCategory = _service.Create(category);
                return CreatedAtAction(nameof(GetById), new { id = createdCategory.WorkshopCategoryId }, createdCategory);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Elimina una categoria por su Id
        /// </summary>
        /// <param name="id">Id de la categoria</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var category = _service.Delete(id);
            if (category == null)
                return NotFound();

            return NoContent();
        }


        /// <summary>
        /// Permite actualizar una categoria
        /// </summary>
        /// <param name="id">Id de la categoria a actualizar</param>
        /// <param name="category">Una categoria</param>
        /// <returns></returns>
        [Authorize(Roles = UserRole.Administrator)]
        [HttpPatch("{id}")]
        public IActionResult Update(Guid id, WorkshopCategory category)
        {
            if (category.WorkshopCategoryId != id)
                return BadRequest();

            try
            {
                _service.Update(category);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
