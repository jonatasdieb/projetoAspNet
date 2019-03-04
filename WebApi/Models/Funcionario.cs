using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

    [Table("Funcionarios")]
    public class Funcionario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Selecione um departamento para continuar.")]
        public int? DepartamentoId { get; set; }

        [StringLength(200, ErrorMessage = "O nome do funcionário é obrigatório deve conter no máximo 200 caracteres.", MinimumLength = 3)]      
        public string Nome { get; set; }        

        public virtual Departamento Departamento { get; set; }
    }

}