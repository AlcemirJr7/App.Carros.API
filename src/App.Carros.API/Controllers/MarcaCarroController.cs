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
    public class MarcaCarroController : ControllerBase
    {
        private readonly IMarcaCarroService _marcaCarroService;

        public MarcaCarroController(IMarcaCarroService marcaCarroService)
        {
            _marcaCarroService = marcaCarroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaCarroDTO>>> Get()
        {
            var marcaCarros = await _marcaCarroService.GetMarcaCarrosAsync();

            if (marcaCarros == null) return NotFound("Marca Carro não encontrados.");

            return Ok(marcaCarros);

        }

        [HttpGet("{id:int}", Name = "GetMarcaCarro")]
        public async Task<ActionResult<MarcaCarroDTO>> Get(int id)
        {
            var marcaCarros = await _marcaCarroService.GetMarcasCarroPeloIdAsync(id);

            if (marcaCarros == null) return NotFound("Marca Carro não encontrados.");

            return Ok(marcaCarros);

        }

        [HttpPost]
        public async Task<ActionResult<MarcaCarroDTO>> Post([FromBody] MarcaCarroDTO marcaCarroDto)
        {
            if (marcaCarroDto == null) return BadRequest("Data Invalida.");

            await _marcaCarroService.CriarAsync(marcaCarroDto);

            return new CreatedAtRouteResult("GetMarcaCarro", new { id = marcaCarroDto.Id }, marcaCarroDto);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MarcaCarroDTO>> Put(int id, [FromBody] MarcaCarroDTO marcaCarroDto)
        {
            if (id != marcaCarroDto.Id) return BadRequest("Data invalida.");

            if (marcaCarroDto == null) return BadRequest("Data invalida.");

            await _marcaCarroService.AlterarAsync(marcaCarroDto);

            return Ok(marcaCarroDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MarcaCarroDTO>> Delete(int id)
        {
            var CambioCarroDto = await _marcaCarroService.GetMarcasCarroPeloIdAsync(id);

            if (CambioCarroDto == null) return NotFound("Marca Carrro não encontrado.");

            await _marcaCarroService.DeletarAsync(id);

            return Ok(CambioCarroDto);
        }

    }
}
