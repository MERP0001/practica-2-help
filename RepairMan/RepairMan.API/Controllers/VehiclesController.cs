using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.DataClasses.Motoring;
using RepairMan.Services.Motoring;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        /// <summary>
        /// Servicio para interaccion con el acceso a datos de vehiculos.
        /// </summary>
        public readonly IVehicleService _service;
        /// <summary>
        /// Controlador de Cupones
        /// </summary>
        /// <param name="service"></param>
        public VehiclesController(IVehicleService service)
        {
            _service = service;
        }


        /// <summary>
        /// Obtiene un vehiculo por su identificacion
        /// </summary>
        /// <param name="id">Identificacion</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var vehicle = _service.Get(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        /// <summary>
        /// Elimina un vehiculo especifico por su identificacion
        /// </summary>
        /// <param name="id">identificacion</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var vehicle = _service.Delete(id);
            if (vehicle == null)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Crea un vehiculo
        /// </summary>
        /// <param name="vehicle">El vehiculo</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            try
            {
                _service.Create(vehicle);
                return CreatedAtAction(nameof(GetById), new { id = vehicle.VehicleId }, _service.Get(vehicle.VehicleId));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception);
            }
        }


        /// <summary>
        /// Actualiza un vehiculo
        /// </summary>
        /// <param name="id">Identificacion del vehiculo</param>
        /// <param name="vehicle">Nuevo vehiculo</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Vehicle vehicle)
        {

            var existingVehicle = _service.Get(id);
            if (existingVehicle == null)
            {
                return NotFound();
            }
            try
            {
                existingVehicle.ReleaseDate = vehicle.ReleaseDate;
                existingVehicle.ModelId = vehicle.ModelId;
                _service.Update(existingVehicle);
                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception);
            }
        }
    }
}