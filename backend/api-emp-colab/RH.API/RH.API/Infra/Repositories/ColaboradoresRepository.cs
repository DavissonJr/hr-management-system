using System.Data;
using AutoMapper;
using Dapper;
using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories
{
    public class ColaboradoresRepository : IColaboradoresRepository
    {
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;  // Injetando AutoMapper

        public ColaboradoresRepository(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = "UPDATE COLABORADORES SET NOME=@NOME, CPF=@CPF, MATRICULA=@MATRICULA, EMPRESAID=@EMPRESAID WHERE COLABORADORID=@ID";
                var parametros = new
                {
                    NOME = colaborador.Nome,
                    CPF = colaborador.CPF,
                    MATRICULA = colaborador.Matricula,
                    EMPRESAID = colaborador.EmpresaId,
                    ID = colaborador.ColaboradorId
                };
                var colaboradorAtualizado = await _connection.ExecuteAsync(sql, parametros);
                return colaboradorAtualizado > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ColaboradorDto> BuscarColaboradoresPorId(int id)
        {
            try
            {
                string sql = @"
            SELECT C.ColaboradorId, C.Nome, C.CPF, C.Matricula, C.EmpresaId, E.NOME as EmpresaNome
            FROM COLABORADORES C
            INNER JOIN EMPRESAS E ON E.EMPRESAID = C.EMPRESAID
            WHERE C.ColaboradorId = @ID";

                var colaboradores = await _connection.QueryAsync<ColaboradorDto>(sql, new { ID = id });
                return colaboradores.FirstOrDefault(); // Retorna o primeiro ou nulo
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Logando o erro
                throw;
            }
        }





        public async Task<List<ColaboradorDto>> BuscarTodosColaboradores()
        {
            try
            {
                string sql = "SELECT C.ColaboradorId, C.Nome, C.CPF, C.Matricula, C.EmpresaId, E.NOME as EmpresaNome " +
                             "FROM COLABORADORES C " +
                             "INNER JOIN EMPRESAS E ON E.EMPRESAID = C.EMPRESAID";

                var colaboradores = await _connection.QueryAsync<ColaboradorDto>(sql);
                return colaboradores.ToList(); // Adicionando o retorno da lista
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Logando o erro
                throw;
            }
        }


        public async Task<bool> ExcluirColaborador(int id)
        {
            try
            {
                string sql = "DELETE FROM COLABORADORES WHERE COLABORADORID = @ID";
                var colaboradorExcluido = await _connection.ExecuteAsync(sql, new { ID = id });
                return colaboradorExcluido > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = "INSERT INTO COLABORADORES (NOME, CPF, MATRICULA, EMPRESAID) VALUES (@NOME, @CPF, @MATRICULA, @EMPRESAID)";
                var parametros = new
                {
                    NOME = colaborador.Nome,
                    CPF = colaborador.CPF,
                    MATRICULA = colaborador.Matricula,
                    EMPRESAID = colaborador.EmpresaId
                };
                var colaboradorInserido = await _connection.ExecuteAsync(sql, parametros);
                return colaboradorInserido > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
