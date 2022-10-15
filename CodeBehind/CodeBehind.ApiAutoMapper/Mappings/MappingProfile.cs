using System;
using AutoMapper;
using CodeBehind.ApiAutoMapper.DTOs;
using CodeBehind.ApiAutoMapper.Models;

namespace CodeBehind.apiAutoMapper.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Funcionario, FuncionarioDTO>()
                .ForMember(dest => dest.Nome, src => src.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Sobrenome, src => src.MapFrom(src => src.Sobrenome))
                .ForMember(dest => dest.Sexo, src => src.MapFrom(src => src.Sexo == Sexo.Masculino ? "M" : "F"))
                .ForMember(dest => dest.DataNascimento, src => src.MapFrom(src => src.DataNascimento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.IsAtivo, src => src.MapFrom(src => src.Salario > 0 ? true : false))
                .ReverseMap();

            CreateMap<Endereco, EnderecoDTO>();
        }
    }
}
