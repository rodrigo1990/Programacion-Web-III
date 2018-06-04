using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using reCAPTCHA.MVC;
using TpPwIII.Models;

namespace TpPwIII.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioRepository ur = new UsuarioRepository();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [CaptchaValidator(
        PrivateKey = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe",
        ErrorMessage = "Invalid input captcha.",
        RequiredMessage = "The captcha field is required.")]
        [ValidateAntiForgeryToken]
        public ActionResult registrarUsuario([Bind(Include = "Nombre,Apellido,Edad,Email,Contrasenia,ConfirmPass")] Usuario usu, bool captchaValid)
        {
            
            if (ModelState.IsValid)
            {
                ur.insertarUsuario(usu);
                
                ViewBag.titulo = "¡Enhorabuena! te has registrado exitosamente";
                return View("Landing_Registrar_Usuario");
            }

            return View("Index");



        }
    }
}