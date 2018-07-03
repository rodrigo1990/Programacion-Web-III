using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using reCAPTCHA.MVC;
using TpPwIII.Models;
using EncryptData;
using System.Data.Entity.Validation;

namespace TpPwIII.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        SessionValidator sv = new SessionValidator();
        TareaRepository tareaRepository = new TareaRepository();
        CarpetaRepository carpetaRepository = new CarpetaRepository();

        public ActionResult Index()
        {
            carpetaRepository.CrearGeneral();
            HttpCookieCollection MyCookieCollection = Request.Cookies;
            HttpCookie MyCookie = MyCookieCollection.Get("UsuarioCookies");

            if (MyCookie != null)
            {
                
                UsuarioLogin usuario = new UsuarioLogin();

                usuario.Email = Cipher.DecryptString(MyCookie["Email"]);
                usuario.ContraseniaLogin = Cipher.DecryptString(MyCookie["Contrasenia"]);

                Usuario usuarioEncontrado=usuarioRepository.BuscarUsuarioLogueado(usuario);

                if (usuarioEncontrado.EstadoLogin == 1) {
                    Session["ID"] = MyCookie["ID"];
                    Session["Email"] = MyCookie["Email"];
                    Session["Contrasenia"] = MyCookie["Contrasenia"];

                    return RedirectToAction("Home");

                }
            }

            return View();
        }

        public ActionResult Home()
        {
            bool estado = sv.ValidarSesion();
            if (sv.ValidarSesion() == true)
            {
                List<TareaHomeViewModel> lista = tareaRepository.ListarTareasConCarpeta(Int32.Parse(Session["ID"].ToString()));
                return View(lista);
            }
            else
            {
                Session["Controller"] = "Usuario";
                Session["Action"] = "Home";
                return RedirectToAction("Index");
            }

            


        }

        

        [HttpPost]
        [CaptchaValidator(
        PrivateKey = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe",
        ErrorMessage = "Invalid input captcha.",
        RequiredMessage = "The captcha field is required.")]
        [ValidateAntiForgeryToken]
        public ActionResult registrarUsuario([Bind(Include = "Nombre,Apellido,Email,Contrasenia,ConfirmPass")] Usuario usu, bool captchaValid)
        {
            
            if (ModelState.IsValid)
            {
                string estado = usuarioRepository.insertarUsuario(usu);
                if (estado == "Usuario registrado") { 

                    ViewBag.titulo = "¡Enhorabuena! te has registrado exitosamente";
                    return View("Landing_Registrar_Usuario");

                }else if(estado == "Usuario actualizado")
                {
                    ViewBag.titulo = "¡Enhorabuena! te hemos activado y hemos actualizado tus datos";
                    return View("Landing_Registrar_Usuario");

                }else if(estado == "Usuario existente")
                {
                    ViewBag.titulo = "Tu usuario ya existe";
                    return View("Landing_Registrar_Usuario");
                }
             
            
            }

            return View("Index");



        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoguearUsuario(UsuarioLogin usu)
        {
            UsuarioLoginValidator uv = new UsuarioLoginValidator();
            Usuario usuarioEncontrado = usuarioRepository.BuscarUsuarioLogueado(usu);

            if (uv.ValidarLogin(usu) == true)
            {
                //El usuario se encuentra registrado y activo
                if (usuarioEncontrado.EstadoLogin == 1)
                {
                    //Creo la sesion con la informacion encriptada
                    Session["ID"] = usuarioEncontrado.IdUsuario;
                    Session["Email"] = Cipher.EncryptString(usuarioEncontrado.Email);
                    Session["Contrasenia"] = Cipher.EncryptString(usuarioEncontrado.Contrasenia);

                    if (usu.RecordarUsuario == true)
                    {
                        //Creo las cookies se llenan con los datos de sesion
                        HttpCookie myCookie = new HttpCookie("UsuarioCookies");
                        myCookie["ID"] = Session["ID"].ToString();
                        myCookie["Email"] = Session["Email"].ToString();
                        myCookie["Contrasenia"] = Session["Contrasenia"].ToString();
                        myCookie["RecordarUsuario"] = "1";

                        myCookie.Expires = DateTime.Now.AddDays(30d);
                        Response.Cookies.Add(myCookie);
                    }

                    if (sv.ValidarIntentoDeIngresoAVista() == true)
                    {
                        if (sv.ValidarIdCarpeta() == true)
                        {
                            return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(),new { idCarpeta = Int32.Parse(Session["IdCarpeta"].ToString()) });
                        }
                        else if(sv.ValidarIdTarea()==true)
                        {
                            return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { idTarea = Int32.Parse(Session["IdTarea"].ToString()) });
                        }
                        return RedirectToAction(Session["Action"].ToString(),Session["Controller"].ToString());
                    }
                    else
                    {
                        return RedirectToAction("Home");
                    }

                }//El usuario se encuentra registrado pero inactivo
                else if (usuarioEncontrado.EstadoLogin == 2)
                {
                    ViewBag.estadoLogin = "Usuario inactivo";
                    return View("Index");

                }else if (usuarioEncontrado.EstadoLogin == 3) //El usuario no se encuentra registrado y/o su email y contraseña no coinciden
                {
                    ViewBag.estadoLogin = "Verifique usuario y/o contraseña";
                    return View("Index");

                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                ViewBag.estadoLogin = "Verifique usuario y/o contraseña";
                return View("Index");
            }

        }//FUNCTION

        public ActionResult CerrarSesion()
        {
            if (Request.Cookies["UsuarioCookies"] != null)
            {
                Response.Cookies["UsuarioCookies"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();
            return View("Index");
        }

    }
}