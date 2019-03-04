using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "O nome do usuário é obrigatório deve conter entre 4 e 20 caracteres.")]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha é obrigatória e deve conter entre 6 e 20 caracteres.")]
        public string Password { get; set; }

    }
}