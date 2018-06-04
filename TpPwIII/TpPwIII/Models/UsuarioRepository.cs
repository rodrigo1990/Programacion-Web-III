using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPwIII.Models
{
    public class UsuarioRepository
    {
        MyContext ctx = new MyContext();

        public void insertarUsuario(Usuario usu)
        {
            Random rnd = new Random();

            usu.Activo = 1;
            usu.CodigoActivacion = rnd.Next(1, 1000000).ToString();
            usu.FechaActivacion = DateTime.Now;
            usu.FechaRegistracion = DateTime.Now;
            ctx.Usuarios.Add(usu);
            ctx.SaveChanges();

            Usuario u = ctx.Usuarios.Where(o => o.Email == usu.Email).FirstOrDefault();

            if (u != null)
            {
                Carpeta c = new Carpeta();
                c.FechaCreacion = DateTime.Now;
                c.Nombre = "General";
                c.Descripcion = "Carpeta general";
                c.IdUsuario = u.IdUsuario;

                ctx.Carpetas.Add(c);
                ctx.SaveChanges();

            }




        }
    }
}