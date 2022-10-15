namespace CodeBehind.ApiAutoMapper.DTOs
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public bool IsAtivo { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
    }
}
