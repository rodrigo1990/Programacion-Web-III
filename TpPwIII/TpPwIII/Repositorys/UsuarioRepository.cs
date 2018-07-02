using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
namespace TpPwIII.Models
{
    public class UsuarioRepository
    {
        MyContext ctx = new MyContext();

        public string insertarUsuario(Usuario usu)
        {
            Usuario usuarioExistente = ctx.Usuarios.Where(o => o.Email == usu.Email).FirstOrDefault();

            if (usuarioExistente == null) { 
           
                Random rnd = new Random();

                usu.Activo = 1;
                usu.CodigoActivacion = rnd.Next(1, 1000000).ToString();
                usu.FechaActivacion = DateTime.Now;
                usu.FechaRegistracion = DateTime.Now;
                ctx.Usuarios.Add(usu);
                ctx.SaveChanges();

                Usuario u = ctx.Usuarios.Where(o => o.Email == usu.Email).FirstOrDefault();

             

                return "Usuario registrado";
            }else if (usuarioExistente.Activo == 0)
            {
                
                usuarioExistente.Nombre = usu.Nombre;
                usuarioExistente.Apellido = usu.Apellido;
                usuarioExistente.Contrasenia = usu.Contrasenia;
                usuarioExistente.ConfirmPass = usu.Contrasenia;
                usuarioExistente.Activo = 1;
                try { 
                    ctx.SaveChanges();

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine(dbEx);
                        }
                    }
                }

                return "Usuario actualizado";



            }else if (usuarioExistente.Activo == 1)
            {
                return "Usuario existente";
            }


                return "";


        }//function


        public Usuario BuscarUsuarioEmail(Usuario usu)
        {
            Usuario u = ctx.Usuarios.Where(o => o.Email == usu.Email).FirstOrDefault();

            return u;
        }


        public Usuario BuscarUsuarioLogueado(UsuarioLogin usu)
        {
            Usuario u = ctx.Usuarios.Where(o => o.Email == usu.Email)
                                    .Where(o => o.Contrasenia == usu.ContraseniaLogin)
                                    .FirstOrDefault();

            if (u != null)
            {
                if (u.Activo != 0)
                {
                    //El usuario se encuentra registrado y activo
                    u.EstadoLogin = 1;
                    return u;
                }
                else
                {
                    //El usuario se encuentra registrado pero inactivo
                    u.EstadoLogin = 2;
                    return u;
                }
            }
            else
            {
                //El usuario no se encuentra registrado y/o su email y contraseña no coinciden
                Usuario usuarioNoRegistrado = new Usuario();
                usuarioNoRegistrado.EstadoLogin = 3;
                return usuarioNoRegistrado;
            }

        }

    }//class
}//namespace