//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Custos")]
    public class Custo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione um funcionário para continuar.")]
        public int? FuncionarioId { get; set; }

        [Required(ErrorMessage = "Selecione um departamento para continuar.")]
        public int? DepartamentoId { get; set; }

        [StringLength(500, MinimumLength = 1,  ErrorMessage = "O campo Descrição é obrigatório e deve conter no máximo 500 caracteres.")]        
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public decimal? Valor { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Departamento Departamento { get; set; }

    }
}