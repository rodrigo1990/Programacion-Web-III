using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPwIII.Models
{
    public class SessionValidator
    {
        public bool ValidarSesion()
        {
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["Email"] as string)
                ||
                !string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["Contrasenia"] as string)
                ||
                !string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["IdUsuario"] as string)
                )
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