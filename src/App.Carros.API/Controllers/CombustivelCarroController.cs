using App.Carros.Application.DTOs;
using App.Carros.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Carros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CombustivelCarroController : ControllerBase
    {
        private readonly ICombustivelCarroService _combustivelCarroService;

        public CombustivelCarroController(ICombustivelCarroService combustivelCarroService)
        {
            _combustivelCarroService = combustivelCarroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CombustivelCarroDTO>>> Get()
        {
            var direcaoCarros = await _combustivelCarroService.GetCombustivelCarrosAsync();

            if (direcaoCarros == null) return NotFound("Cumbustivel Carro não encontrados.");

            return Ok(direcaoCarros);

        }

        [HttpGet("{id:int}", Name = "GetCombustivelCarro")]
        public async Task<ActionResult<CombustivelCarroDTO>> Get(int id)
        {
            var direcaoCarros = await _combustivelCarroService.GetCombustivelCarroPeloIdAsync(id);

            if (direcaoCarros == null) return NotFound("Cumbustivel Carro não encontrados.");

            return Ok(direcaoCarros);

        }

        [HttpPost]
        public async Task<ActionResult<CombustivelCarroDTO>> Post([FromBody] CombustivelCarroDTO combustivelCarroDto)
        {
            if (combustivelCarroDto == null) return BadRequest("Data Invalida.");

            await _combustivelCarroService.CriarAsync(combustivelCarroDto);

            return new CreatedAtRouteResult("GetCombustivelCarro", new { id = combustivelCarroDto.Id }, combustivelCarroDto);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CombustivelCarroDTO>> Put(int id, [FromBody] CombustivelCarroDTO combustivelCarroDto)
        {
            if (id != combustivelCarroDto.Id) return BadRequest("Data invalida.");

            if (combustivelCarroDto == null) return BadRequest("Data invalida.");

            await _combustivelCarroService.AlterarAsync(combustivelCarroDto);

            return Ok(combustivelCarroDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CombustivelCarroDTO>> Delete(int id)
        {
            var CambioCarroDto = await _combustivelCarroService.GetCombustivelCarroPeloIdAsync(id);

            if (CambioCarroDto == null) return NotFound("Cumbustivel Carro não encontrado.");

            await _combustivelCarroService.DeletarAsync(id);

            return Ok(CambioCarroDto);
        }

    }
}
