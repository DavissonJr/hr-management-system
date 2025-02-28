using RH.API.Domain;
using RH.API.Dto;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;
using AutoMapper;
using RH.API.DTOs;
using RH.API.Ultilities;

namespace RH.API.Services.Services
{
    public class ColaboradoresService : IColaboradorService
    {
        private readonly IColaboradoresRepository _colaboradoresRepository;
        private readonly IMapper _mapper;
        Metodos metodo = new();

        public ColaboradoresService(IColaboradoresRepository colaboradoresRepository, IMapper mapper)
        {
            _colaboradoresRepository = colaboradoresRepository;
            _mapper = mapper;
        }

        public async Task<bool> InserirColaborador(CreateColaboradorDto colaboradorDto)
        {
            ValidarColaborador(colaboradorDto);
            metodo.ValidaCpf(colaboradorDto.CPF);

            // Usando AutoMapper para mapear o DTO para o domínio
            var colaborador = _mapper.Map<Colaborador>(colaboradorDto);

            return await _colaboradoresRepository.InserirColaborador(colaborador);
        }

        public async Task<bool> AtualizarColaborador(int id, UpdateColaboradorDto colaboradorDto)
        {
            ValidarColaborador(colaboradorDto);
            metodo.ValidaCpf(colaboradorDto.CPF);

            // Usando AutoMapper para mapear o DTO para o domínio
            var colaborador = _mapper.Map<Colaborador>(colaboradorDto);
            colaborador.ColaboradorId = id; 

            return await _colaboradoresRepository.AtualizarColaborador(colaborador);
        }

        public async Task<ColaboradorDto> BuscarColaboradoresPorId(int id)
        {
            return await _colaboradoresRepository.BuscarColaboradoresPorId(id);
        }

        public async Task<List<ColaboradorDto>> BuscarTodosColaboradores()
        {
            return await _colaboradoresRepository.BuscarTodosColaboradores();
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            return await _colaboradoresRepository.ExcluirColaborador(id);
        }

        #region metodos de validações

        #region validação de nulidade
        private void ValidarColaborador(IColaboradorDto colaborador)
        {
            if (string.IsNullOrWhiteSpace(colaborador.Nome))
                throw new Exception("O nome do colaborador é obrigatório.");

            if (string.IsNullOrWhiteSpace(colaborador.CPF))
                throw new Exception("O CPF do colaborador é obrigatório.");

            if (colaborador.Matricula <= 0)
                throw new Exception("A matrícula do colaborador deve ser um número positivo.");

            if (colaborador.EmpresaId <= 0)
                throw new Exception("O ID da empresa deve ser um número positivo.");
        }

        #endregion

        #endregion
    }
}
