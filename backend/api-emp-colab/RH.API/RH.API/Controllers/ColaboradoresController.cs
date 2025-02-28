using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorService _service;

        public ColaboradoresController(IColaboradorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarColaboradores()
        {
            try
            {
                var colaboradores = await _service.BuscarTodosColaboradores();
                return Ok(colaboradores);
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("colaborador-id/{id}")]
        public async Task<IActionResult> ColaboradorPorId(int id)
        {
            try
            {
                var colaborador = await _service.BuscarColaboradoresPorId(id);
                if (colaborador == null)
                {
                    return NotFound();
                }
                return Ok(colaborador);
            }
            catch (Exception) { throw; }
        }

        [HttpPost("inserir-colaborador")]
        public async Task<IActionResult> Inserir([FromBody] CreateColaboradorDto colaborador)
        {
            try
            {
                var colabs = await _service.InserirColaborador(colaborador);
                if (colabs == null)
                {
                    return NotFound();
                }
                return Ok(colabs);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPut("atualizar-colaborador/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateColaboradorDto colaboradorDto)
        {
            try
            {
                var resultado = await _service.AtualizarColaborador(id, colaboradorDto);
                if (resultado == null)
                {
                    return NotFound();
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirColaborador(int id)
        {
            try
            {
                var colab = await _service.ExcluirColaborador(id);
                if (colab == null)
                {
                    return NotFound();
                }
                return Ok(colab);
            }
            catch (Exception ex) { throw; }
        }
    }
}
