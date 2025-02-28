using RH.API.Domain;
using RH.API.DTOs;  

namespace RH.API.Infra.Interfaces
{
    public interface IColaboradoresRepository
    {
        Task<List<ColaboradorDto>> BuscarTodosColaboradores();  
        Task<ColaboradorDto> BuscarColaboradoresPorId(int id); 
        Task<bool> InserirColaborador(Colaborador colaborador);
        Task<bool> AtualizarColaborador(Colaborador colaborador);
        Task<bool> ExcluirColaborador(int id);
    }
}
