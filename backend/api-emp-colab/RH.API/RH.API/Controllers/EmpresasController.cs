using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;
using System;
using System.Threading.Tasks;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresasController(IEmpresaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodasEmpresasAsync();
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

        [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresa = await _service.BuscarEmpresaPorId(id);
            if (empresa == null)
                return NotFound("Empresa não encontrada.");
            return Ok(empresa);
        }
        catch (Exception ex) { throw; }
    }


    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] Empresa empresa)
    {
        try
        {
            await _service.InserirEmpresa(empresa);
            return Ok("Empresa inserida com sucesso.");
        }
        catch (Exception ex) { throw; }
    }



    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] Empresa empresa)
    {
        try
        {
            var atualizada = await _service.AtualizarEmpresa(empresa);
            if (atualizada == null)
                return NotFound("Empresa não encontrada para atualização.");
            return Ok("Empresa atualizada com sucesso.");
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var excluida = await _service.ExcluirEmpresa(id);
            if (excluida == null)
                return NotFound("Empresa não encontrada para exclusão.");
            return Ok("Empresa excluída com sucesso.");
        }
        catch (Exception ex) { throw; }
    }
}