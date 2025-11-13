using BackendAPI.DTOs;
using BackendAPI.Models;
using BackendAPI.Services;
using BackendAPI.Services.Interfaces;
using BackendAPI.Wrappers.Filter;
using BackendAPI.Wrappers.Helpers;
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
    public class AnneeScolaireController : ControllerBase
    {
        private readonly IService<Annee_Scolaire> _serviceAnnee_Scolaire;

        public AnneeScolaireController(IService<Annee_Scolaire> serviceAnnee_Scolaire)
        {
            _serviceAnnee_Scolaire = serviceAnnee_Scolaire;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = await _serviceAnnee_Scolaire.GetAllAsync<Annee_ScolaireDto>(filter, route);
            return Ok(response);

        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchString([FromQuery] PaginationFilter filter, [FromQuery] string? search)
        {
            Expression<Func<Annee_Scolaire, bool>> predicate = e => true; // prédicat par défaut (tout sélectionner)

            if (!string.IsNullOrEmpty(search))
            {
                predicate = e =>
                    (e.AnneeScolaire != 0 && e.AnneeScolaire.ToString().Contains(search));
            }

            var route = Request.Path.Value;
            var response = await _serviceAnnee_Scolaire.GetBySearchStringAsync<Annee_ScolaireDto>(filter, route, predicate);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _serviceAnnee_Scolaire.GetByIdAsync<Annee_ScolaireDto>(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Annee_ScolaireDto anneescolairedto)
        {
            await _serviceAnnee_Scolaire.AddAsync<Annee_ScolaireDto>(anneescolairedto);
            return CreatedAtAction(nameof(Get), new { id = anneescolairedto.AnneeScolaire }, anneescolairedto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Annee_ScolaireDto anneescolairedto)
        {
            var response = await _serviceAnnee_Scolaire.UpdateAsync<Annee_ScolaireDto>(id, anneescolairedto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _serviceAnnee_Scolaire.DeleteAsync(id);
            return NoContent();
        }

    }
}
