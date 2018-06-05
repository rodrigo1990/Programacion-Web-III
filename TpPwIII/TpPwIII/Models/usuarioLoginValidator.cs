using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace TpPwIII.Models
{
    public class UsuarioLoginValidator
    {
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match emailMatch;
        

        public bool ValidarLogin(Usuario u)
        {
            emailMatch = emailRegex.Match(u.Email);
             

           

            if(emailMatch.Success & u.Contrasenia.Length<=20)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }
}