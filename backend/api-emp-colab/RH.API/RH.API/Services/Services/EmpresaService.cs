using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repository;
    public EmpresaService(IEmpresaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AtualizarEmpresa(Empresa empresa)
    {
        try
        {
            ValidarEmpresa(empresa);
            return await _repository.AtualizarEmpresa(empresa);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try
        {
            return await _repository.BuscarEmpresaPorId(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            var empresas = await _repository.BuscarTodasEmpresas();
            return empresas;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> ExcluirEmpresa(int id)
    {
        return await _repository.ExcluirEmpresa(id);
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        ValidarEmpresa(empresa);
        return await _repository.InserirEmpresa(empresa);
    }

    private void ValidarEmpresa(Empresa empresa)
    {
        if (string.IsNullOrWhiteSpace(empresa.Nome))
            throw new Exception("O nome da empresa não deve ser nulo!");
    }
}
