using System;

namespace CodeBehind.ApiAutoMapper.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public Double Salario { get; set; }
        public Endereco Endereco { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
