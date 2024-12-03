using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Motoring;
using RepairMan.Services.Motoring;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public readonly IBrandService _service;
        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas las marcas de vehiculo, o las filtra
        /// </summary>
        /// <param name="name">Nombre de la marca</param>
        /// <returns>Las marcas de vehiculo</returns>
        [HttpGet]
        public IActionResult All(string name = null)
        {
            return Ok(_service.All(x =>
                 (name == null || x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)) 
            ));
        }

        /// <summary>
        /// Retorna una marca especifica de vehiculo por su id.
        /// </summary>
        /// <param name="id">Id de la marca de vehiculo</param>
        /// <returns>La marca de vehiculo</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var brand = _service.Get(id);
            if (brand == null)
                return NotFound();
            return Ok(brand);
        }

        /// <summary>
        /// Permite crear una marca.
        /// </summary>
        /// <param name="brand">Una marca</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = UserRole.Administrator)]
        public IActionResult Create(Brand brand)
        {
            try
            {
                var createdBrand = _service.Create(brand);
                return CreatedAtAction(nameof(GetById), new { id = createdBrand.BrandId }, createdBrand);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        /// <summary>
        /// Permite actualizar una marca
        /// </summary>
        /// <param name="id">Id de la marca a actualizar</param>
        /// <param name="brand">Una marca</param>
        /// <returns></returns>
        [Authorize(Roles = UserRole.Administrator)]
        [HttpPatch("{id}")]
        public IActionResult Update(Guid id, Brand brand)
        {
            try
            {
                _service.Update(brand);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
