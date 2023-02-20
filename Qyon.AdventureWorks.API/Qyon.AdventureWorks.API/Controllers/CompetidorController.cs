using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Service;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetidorController : ControllerBase
    {
        private readonly ICompetidorService _service;

        public CompetidorController(ICompetidorService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var competidores = await _service.GetCompetidores();
            if(competidores == null)
            {
                return BadRequest();
            }
            return Ok(competidores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var competidor = await _service.GetCompetidor(id);
            if(competidor == null)
            {
                return NotFound("Competidor não encontrado");
            }
            return Ok(competidor);
        }

        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] Competidor model)
        {
            if (model == null)
            {
                return BadRequest("Modelo esta nulo");
            }
            await _service.InsertCompetidor(model);
            return CreatedAtAction(nameof(GetById), new { Id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] Competidor model)
        {
            if (id != model.Id)
            {
                return BadRequest($"O ID {id} não é igual");
            }
            try
            {
                await _service.UpdateCompetidor(id, model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Competidor atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var competidor = await _service.GetCompetidor(id);
            if (competidor == null)
            {
                return NotFound($"Competidor {id} não foi encontrado");
            }
            await _service.DeleteCompetidor(id);
            return Ok(competidor);
        }

    }
}
