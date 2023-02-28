using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Service;
using System.Threading.Tasks;

namespace Qyon.AdventureWorks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PistaCorridaController : ControllerBase
    {
        private readonly IPistaCorridaService _service;

        public PistaCorridaController(IPistaCorridaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var pistas = await _service.GetListPistasCorridas();
            if (pistas == null)
            {
                return BadRequest();
            }
            return Ok(pistas);
        }

        [HttpGet]
        [Route("pistasUtilizadas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPistasUtilizadas()
        {
            var pistas = await _service.GetPistasUtilizadas();
            if (pistas == null)
            {
                return BadRequest();
            }
            return Ok(pistas);
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var pista = await _service.GetPistaCorrida(id);
            if (pista == null)
            {
                return NotFound("Pista de corrida não encontrada");
            }
            return Ok(pista);
        }

        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] PistaCorrida model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            await _service.InsertPistaCorrida(model);
            return CreatedAtAction(nameof(GetById), new { Id = model.Id }, model);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PistaCorrida model)
        {
            if (id != model.Id)
            {
                return BadRequest($"O ID {id} não é igual");
            }
            try
            {
                await _service.UpdatePistaCorrida(id, model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Pista de corrida atualizada com sucesso.");
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var pistaCorrida = await _service.GetPistaCorrida(id);
            if (pistaCorrida == null)
            {
                return NotFound($"Pista de corrida {id} não foi encontrada");
            }
            await _service.DeletePistaCorrida(id);
            return Ok(pistaCorrida);
        }

    }
}
