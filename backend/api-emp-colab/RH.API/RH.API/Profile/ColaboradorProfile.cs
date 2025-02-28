using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.DTOs;

public class ColaboradorProfile : Profile
{
    public ColaboradorProfile()
    {
        // Mapeando de CreateColaboradorDto para Colaborador
        CreateMap<CreateColaboradorDto, Colaborador>();

        // Mapeando de UpdateColaboradorDto para Colaborador
        CreateMap<UpdateColaboradorDto, Colaborador>();

        // Mapeando de Colaborador para ColaboradorDto (DTO de leitura)
        CreateMap<Colaborador, ColaboradorDto>()
            .ForMember(dest => dest.EmpresaNome, opt => opt.MapFrom(src => src.EmpresaNome));
    }
}