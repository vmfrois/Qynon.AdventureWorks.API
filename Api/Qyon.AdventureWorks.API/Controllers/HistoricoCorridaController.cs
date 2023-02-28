using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Services;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoCorridaController : ControllerBase
    {
        private readonly IHistoricoCorridaService _service;
        

        public HistoricoCorridaController(IHistoricoCorridaService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("get/tempoMedio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCompetidoresComTempoMedio()
        {
            var competidores = await _service.GetCompetidoresComTempoMedio();
            if (competidores == null)
            {
                return BadRequest();
            }
            return Ok(competidores);
        }

        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] HistoricoCorrida model)
        {
            if (model == null)
            {
                return BadRequest("Modelo esta nulo");
            }
            await _service.InsertHistorico(model);
            return CreatedAtAction(nameof(HistoricoCorrida), new { Id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HistoricoCorrida model)
        {
            if (id != model.Id)
            {
                return BadRequest($"O ID {id} não é igual");
            }
            try
            {
                await _service.UpdateHistorico(id, model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Historico atualizado com sucesso.");
        }

    }
}
