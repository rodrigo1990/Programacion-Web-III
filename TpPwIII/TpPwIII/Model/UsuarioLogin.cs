using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TpPwIII.Models
{
    public class UsuarioLogin
    {
        

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Ingrese un email")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido Ej: prueba@myfoldering.com")]
        public string Email { get; set; }


        [NotMapped]
        public bool RecordarUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña")]
        [RegularExpression(@"^.{1,20}$", ErrorMessage = "Ingrese una contraseña que tenga como maximo 20 caracteres")]
        [NotMapped]
        public string ContraseniaLogin { get; set; }
    }
}