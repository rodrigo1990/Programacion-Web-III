using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPwIII.Models;
using EncryptData;

namespace TpPwIII.Controllers
{
    public class CarpetaController : Controller
    {
        CarpetaRepository carpetaRepository = new CarpetaRepository();
        SessionValidator sv = new SessionValidator();

        public ActionResult MisCarpetas()
        {
            if(sv.ValidarSesion() == true)
            {
                ViewBag.carpetas = carpetaRepository.BuscarCarpetas(Int32.Parse(Session["ID"].ToString()));

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }


        }


        public ActionResult CrearForm()
        {
            if (sv.ValidarSesion() == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Nombre,Descripcion")] Carpeta car)
        {
            if (sv.ValidarSesion() == true)
            {
                if (ModelState.IsValid)
                {
                    carpetaRepository.InsertarCarpeta(car);

                    ViewBag.estado = "Carpeta registrada";

                    return View("MisCarpetas");


                }
                else
                {

                    ViewBag.estado = "Carpeta  NO registrada";

                    return View("MisCarpetas");
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }


        }



    }
}