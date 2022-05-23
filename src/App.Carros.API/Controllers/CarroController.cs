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
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarroDTO>>> Get()
        {
            var carros = await _carroService.GetCarrosAsync();

            if (carros == null) return NotFound("Carros não encontrados.");

            return Ok(carros);

        }

        [HttpGet("{id:int}", Name = "GetCarro")]
        public async Task<ActionResult<CarroDTO>> Get(int? id)
        {
            var carro = await _carroService.GetCarroPeloIdAsync(id);

            if (carro == null) return NotFound("Carro não encontrados.");

            return Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarroDTO carroDto)
        {
            if (carroDto == null) return BadRequest("Data invalida.");
            
            await _carroService.CriarAsync(carroDto);

            return new CreatedAtRouteResult("GetCarro", new { id = carroDto.Id }, carroDto);

        }

        [HttpPut]
        public async Task<ActionResult<CarroDTO>> Put(int? id, [FromBody] CarroDTO carroDto)
        {
            if (id != carroDto.Id) return BadRequest("Data invalida.");

            if (carroDto == null) return BadRequest("Data invalida.");

            await _carroService.AlterarAsync(carroDto);

            return Ok(carroDto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarroDTO>> Put(int? id)
        {
            var carroDto = await _carroService.GetCarroPeloIdAsync(id);

            if (carroDto == null) return NotFound("Carro não encontrado.");

            await _carroService.DeletarAsync(id);

            return Ok(carroDto);
        }
        

    }
}
