using BackendAPI.DTOs;
using BackendAPI.Models;
using BackendAPI.Services;
using BackendAPI.Services.Interfaces;
using BackendAPI.Wrappers.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EcoleController : ControllerBase
    {
        private readonly IService<Ecole> _serviceEcole;

        public EcoleController(IService<Ecole> serviceEcole)
        {
            _serviceEcole = serviceEcole;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = await _serviceEcole.GetAllAsync<EcoleDto>(filter, route);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchString([FromQuery] PaginationFilter filter, [FromQuery] string? search)
        {
            Expression<Func<Ecole, bool>> predicate = e => true; // prédicat par défaut (tout sélectionner)

            if (!string.IsNullOrEmpty(search))
            {
                predicate = e =>
                    (e.TitreEcole != null && e.TitreEcole.Contains(search)) ||
                    (e.Matricule_Secope != null && e.Matricule_Secope.Contains(search)) ||
                    (e.AdresseEcole != null && e.AdresseEcole.Contains(search));
            }

            var route = Request.Path.Value;
            var response = await _serviceEcole.GetBySearchStringAsync<EcoleDto>(filter, route,predicate);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _serviceEcole.GetByIdAsync<EcoleDto>(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EcoleDto ecoledto)
        {
            var response = await _serviceEcole.AddAsync<EcoleDto>(ecoledto);
            return CreatedAtAction(nameof(Get), new { id = response.Data.Id }, response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EcoleDto ecoledto)
        {
            var response = await _serviceEcole.UpdateAsync<EcoleDto>(id, ecoledto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceEcole.DeleteAsync(id);
            return NoContent();
        }

    }
}
