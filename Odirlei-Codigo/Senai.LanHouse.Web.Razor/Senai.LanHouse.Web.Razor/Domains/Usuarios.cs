using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [EmailAddress(ErrorMessage = "Informe um email valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
