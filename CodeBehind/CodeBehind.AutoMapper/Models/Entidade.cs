using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBehind.AutoMapper.Models
{
    [Table("Entidade")]
    public class Entidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public byte Idade { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public double Salario { get; set; }
    }
}
