using Application.Interfaces;
using Application.Request;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsorcioController : ControllerBase
    {
        private readonly IConsorcioUseCase _consorcioUseCase;
        private readonly IValidator<ConsorcioRequest> ValidarRequisicaoConsorcio;

        public ConsorcioController(IConsorcioUseCase consorcioUseCase, IValidator<ConsorcioRequest> validarRequisicaoConsorcio)
        {
            _consorcioUseCase = consorcioUseCase;
            ValidarRequisicaoConsorcio = validarRequisicaoConsorcio;
        }

        [HttpPost]
        public IActionResult AdicionarConsorcio([FromBody] ConsorcioRequest consorcioRequest)
        {
            var validation = ValidarRequisicaoConsorcio.Validate(consorcioRequest);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);
        
            _consorcioUseCase.AdicionarConsorcio(consorcioRequest);
            return Created("api/consorcio", null);
        }


        [HttpPut]
        public IActionResult AtualizarConsorcio(int id, ConsorcioRequest consorcioRequest)
        {
            var validation = ValidarRequisicaoConsorcio.Validate(consorcioRequest);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            _consorcioUseCase.AtualizarConsorcio(id,consorcioRequest);
            return Ok("Consórcio atualizado com sucesso.");
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarConsorcio(int id)
        {
            _consorcioUseCase.ExcluirConsorcio(id);
            return Ok("Consórcio excluído com sucesso.");
        }


        [HttpGet("{id}")]
        public IActionResult BuscarConsorcioById(int id)
        {
            var result = _consorcioUseCase.BuscarConsorcio(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet]
        public IActionResult ListarConsorcios()
        {
            var result = _consorcioUseCase.BuscarTodosConsorcios();
            return Ok(result);
        }

    }
}
