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
    public class InscriptionController : ControllerBase
    {
        private readonly IService<Inscription> _serviceInscription;

        public InscriptionController(IService<Inscription> serviceInscription)
        {
            _serviceInscription = serviceInscription;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = await _serviceInscription.GetAllAsync<InscriptionDto>(filter, route, i => i.AnneeScolaire, i => i.Ecole, i => i.Eleve);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchString([FromQuery] PaginationFilter filter, [FromQuery] string? search)
        {
            Expression<Func<Inscription, bool>> predicate = e => true; // prédicat par défaut (tout sélectionner)

            if (!string.IsNullOrEmpty(search))
            {
                predicate = e =>
                    (e.AnneeScolaire.AnneeScolaire != 0 && e.AnneeScolaire.AnneeScolaire.ToString().Contains(search)) ||
                    (e.Eleve.NomEleve != null && e.Eleve.NomEleve.Contains(search)) ||
                    (e.Ecole.TitreEcole != null && e.Ecole.TitreEcole.Contains(search));
            }

            var route = Request.Path.Value;
            var response = await _serviceInscription.GetBySearchStringAsync<InscriptionDto>(filter, route, predicate);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _serviceInscription.GetByIdAsync<InscriptionDto>(id,i=>i.AnneeScolaire,i=>i.Ecole, i=>i.Eleve);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InscriptionDto inscriptiondto)
        {
            await _serviceInscription.AddAsync<InscriptionDto>(inscriptiondto);
            return CreatedAtAction(nameof(Get), new { id = inscriptiondto.Id }, inscriptiondto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InscriptionDto inscriptiondto)
        {
            var response = await _serviceInscription.UpdateAsync<InscriptionDto>(id, inscriptiondto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceInscription.DeleteAsync(id);
            return NoContent();
        }

    }
}
