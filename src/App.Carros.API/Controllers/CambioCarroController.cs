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
    public class CambioCarroController : ControllerBase
    {
        private readonly ICambioCarroService _cambioCarroService;

        public CambioCarroController(ICambioCarroService cambioCarroService)
        {
            _cambioCarroService = cambioCarroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CambioCarroDTO>>> Get()
        {
            var cambioCarros = await _cambioCarroService.GetCambioCarrosAsync();

            if (cambioCarros == null) return NotFound("CambioCarro não encontrados.");

            return Ok(cambioCarros);

        }

        [HttpGet("{id:int}", Name = "GetCambioCarro")]
        public async Task<ActionResult<CambioCarroDTO>> Get(int id)
        {
            var cambioCarros = await _cambioCarroService.GetCambioCarroPeloIdAsync(id);

            if (cambioCarros == null) return NotFound("CambioCarro não encontrados.");

            return Ok(cambioCarros);

        }

        [HttpPost]
        public async Task<ActionResult<CambioCarroDTO>> Post([FromBody] CambioCarroDTO cambioCarroDto)
        {
            if (cambioCarroDto == null) return BadRequest("Data Invalida.");

            await _cambioCarroService.CriarAsync(cambioCarroDto);

            return new CreatedAtRouteResult("GetCambioCarro", new { id = cambioCarroDto.Id }, cambioCarroDto);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CambioCarroDTO>> Put(int id,[FromBody] CambioCarroDTO cambioCarroDto)
        {
            if (id != cambioCarroDto.Id) return BadRequest("Data invalida.");

            if (cambioCarroDto == null) return BadRequest("Data invalida.");

            await _cambioCarroService.AlterarAsync(cambioCarroDto);

            return Ok(cambioCarroDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CambioCarroDTO>> Delete(int id)
        {
            var CambioCarroDto = await _cambioCarroService.GetCambioCarroPeloIdAsync(id);

            if (CambioCarroDto == null) return NotFound("Cambio Carro não encontrado.");

            await _cambioCarroService.DeletarAsync(id);

            return Ok(CambioCarroDto);
        }





    }
}
