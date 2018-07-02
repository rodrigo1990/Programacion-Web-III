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
                &&
                !string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["Contrasenia"] as string)
              
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarIntentoDeIngresoAVista()
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["Controller"] as string)
                &&
                !string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["Action"] as string)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarIdCarpeta()
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["IdCarpeta"] as string)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarIdTarea()
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["IdTarea"] as string)
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