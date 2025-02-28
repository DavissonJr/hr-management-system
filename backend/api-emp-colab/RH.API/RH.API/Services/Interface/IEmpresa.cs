using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IEmpresaService
{
    Task<List<Empresa>> BuscarTodasEmpresasAsync();
    Task<Empresa> BuscarEmpresaPorId(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> ExcluirEmpresa(int id);
}
