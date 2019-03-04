using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Departamentos")]
    public class Departamento
    {      

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome do departamento é obrigatório deve conter no máximo 100 caracteres.")]        
        public string Nome { get; set; }      
        
    }
}