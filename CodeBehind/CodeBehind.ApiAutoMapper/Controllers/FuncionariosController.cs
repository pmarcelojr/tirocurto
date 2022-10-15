using AutoMapper;
using CodeBehind.ApiAutoMapper.DTOs;
using CodeBehind.ApiAutoMapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBehind.ApiAutoMapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IMapper _mapper;

        public FuncionariosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(Funcionario funcionario)
        {
            var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionario);
            return Ok(funcionarioDTO);
        }
    }
}
