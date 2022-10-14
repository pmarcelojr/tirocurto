using System;
using AutoMapper;
using CodeBehind.AutoMapper.Models;

namespace CodeBehind.AutoMapper
{
    class Program
    {
        private static IMapper _mapper;

        static void Main(string[] args)
        {
            Console.WriteLine("CodeBehind - Mapeamento de Objetos!");

            var mapper = new MapperConfiguration(p => p.CreateMap<Entidade, EntidadeDto>().ReverseMap()).CreateMapper();
            _mapper = mapper;

            var dto = new EntidadeDto()
            {
                Id = 1,
                Nome = "Marcelo",
                Sobrenome = "Santos",
                Idade = 28,
                Sexo = "M"
            };

            var entidade1 = MetodoTradicional(dto);

            var entidade2 = MetodoAutoMapper(dto);

            var entidade3 = MetodoGenerico<Entidade>(dto);
        }

        private static Entidade MetodoTradicional(EntidadeDto dto)
        {
            return new Entidade
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Sobrenome = dto.Sobrenome,
                Idade = dto.Idade,
                Sexo = dto.Sexo
            };
        }

        private static Entidade MetodoAutoMapper(EntidadeDto dto)
        {
            return _mapper.Map<Entidade>(dto);
        }

        private static T MetodoGenerico<T>(object obj)
        {
            return _mapper.Map<T>(obj);
        }
    }
}
