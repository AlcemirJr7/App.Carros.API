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
    public class DirecaoCarroController : ControllerBase
    {
        private readonly IDirecaoCarroService _direcaoCarroService;

        public DirecaoCarroController(IDirecaoCarroService direcaoCarroService)
        {
            _direcaoCarroService = direcaoCarroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirecaoCarroDTO>>> Get()
        {
            var direcaoCarros = await _direcaoCarroService.GetDirecaoCarrosAsync();

            if (direcaoCarros == null) return NotFound("CambioCarro não encontrados.");

            return Ok(direcaoCarros);

        }

        [HttpGet("{id:int}", Name = "GetDirecaoCarro")]
        public async Task<ActionResult<DirecaoCarroDTO>> Get(int id)
        {
            var direcaoCarros = await _direcaoCarroService.GetDirecaoCarroPeloIdAsync(id);

            if (direcaoCarros == null) return NotFound("CambioCarro não encontrados.");

            return Ok(direcaoCarros);

        }

        [HttpPost]
        public async Task<ActionResult<DirecaoCarroDTO>> Post([FromBody] DirecaoCarroDTO direcaoCarroDto)
        {
            if (direcaoCarroDto == null) return BadRequest("Data Invalida.");

            await _direcaoCarroService.CriarAsync(direcaoCarroDto);

            return new CreatedAtRouteResult("GetDirecaoCarro", new { id = direcaoCarroDto.Id }, direcaoCarroDto);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DirecaoCarroDTO>> Put(int id, [FromBody] DirecaoCarroDTO direcaoCarroDto)
        {
            if (id != direcaoCarroDto.Id) return BadRequest("Data invalida.");

            if (direcaoCarroDto == null) return BadRequest("Data invalida.");

            await _direcaoCarroService.AlterarAsync(direcaoCarroDto);

            return Ok(direcaoCarroDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DirecaoCarroDTO>> Delete(int id)
        {
            var CambioCarroDto = await _direcaoCarroService.GetDirecaoCarroPeloIdAsync(id);

            if (CambioCarroDto == null) return NotFound("Cambio Carro não encontrado.");

            await _direcaoCarroService.DeletarAsync(id);

            return Ok(CambioCarroDto);
        }

    }
}
