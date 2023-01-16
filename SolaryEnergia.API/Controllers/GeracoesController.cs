using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Interfaces.Services;

namespace SolaryEnergia.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeracoesController : ControllerBase
    {

        private readonly IGeracaoService _geracaoService;

        public GeracoesController(IGeracaoService geracaoService)
        {
            _geracaoService = geracaoService;
        }

        [HttpGet]
        [Route("~/api/unidade/{idUnidade}/geracoes")]
        public IActionResult Get(
            [FromRoute] int idUnidade)
        {

            var geracoes = _geracaoService.Get()
                .Where(g => g.UnidadeId == idUnidade)
                .ToList();
            return Ok(geracoes);
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_geracaoService.Get());
        }



        [HttpGet("{id}")]
        public IActionResult GetById(
        [FromRoute] int id )
        {
            return Ok(_geracaoService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(
        [FromBody] GeracaoDto geracaoDto )
        {
            _geracaoService.Post(geracaoDto);
            return Created("api/geracoes", geracaoDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(
        [FromBody] GeracaoDto geracaoDto,
        [FromRoute] int id )
        {
            geracaoDto.Id = id;
            _geracaoService.Put(geracaoDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(
            [FromRoute] int id
        )
        {
            _geracaoService.Delete(id);

            return NoContent();
        }
    }
}



