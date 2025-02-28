using RH.API.Domain;
using RH.API.Dto;
using RH.API.DTOs;

namespace RH.API.Services.Interface
{
    public interface IColaboradorService
    {       
        Task<List<ColaboradorDto>> BuscarTodosColaboradores();
        Task<ColaboradorDto> BuscarColaboradoresPorId(int id);
        Task<bool> InserirColaborador(CreateColaboradorDto colaborador);
        Task<bool> AtualizarColaborador(int id, UpdateColaboradorDto colaborador);
        Task<bool> ExcluirColaborador(int id);
    }
}
