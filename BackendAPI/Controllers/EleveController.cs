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
    public class EleveController : ControllerBase
    {
        private readonly IService<Eleve> _serviceEleve;

        public EleveController(IService<Eleve> serviceEleve)
        {
            _serviceEleve = serviceEleve;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = await _serviceEleve.GetAllAsync<EleveDto>(filter, route);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchString([FromQuery] PaginationFilter filter, [FromQuery] string? search)
        {
            Expression<Func<Eleve, bool>> predicate = e => true; // prédicat par défaut (tout sélectionner)

            if (!string.IsNullOrEmpty(search))
            {
                predicate = e =>
                    (e.NomEleve != null && e.NomEleve.Contains(search)) ||
                    (e.PostNomEleve != null && e.PostNomEleve.Contains(search)) ||
                    (e.SexeEleve != null && e.SexeEleve.Contains(search));
            }

            var route = Request.Path.Value;
            var response = await _serviceEleve.GetBySearchStringAsync<EleveDto>(filter, route, predicate);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _serviceEleve.GetByIdAsync<EleveDto>(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EleveDto elevedto)
        {
            await _serviceEleve.AddAsync<EleveDto>(elevedto);
            return CreatedAtAction(nameof(Get), new { id = elevedto.Id }, elevedto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EleveDto elevedto)
        {
            var response = await _serviceEleve.UpdateAsync<EleveDto>(id, elevedto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceEleve.DeleteAsync(id);
            return NoContent();
        }

    }
}
