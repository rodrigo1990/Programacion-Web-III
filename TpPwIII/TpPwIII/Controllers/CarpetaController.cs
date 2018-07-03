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

                List<Carpeta> lista = carpetaRepository.BuscarCarpetas(Int32.Parse(Session["ID"].ToString()));

                return View(lista);
            }
            else
            {
                Session["Controller"] = "Carpeta";
                Session["Action"] = "MisCarpetas";
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
                Session["Controller"] = "Carpeta";
                Session["Action"] = "CrearForm";
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

                    return RedirectToAction("MisCarpetas");


                }
                else
                {

                    ViewBag.estado = "Carpeta  NO registrada";

                    return RedirectToAction("MisCarpetas");
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }


        }

        public ActionResult EliminarCarpeta(int idCarpeta)
        {
            if (sv.ValidarSesion() == true)
            {
                carpetaRepository.EliminarCarpeta(idCarpeta);


                return RedirectToAction("MisCarpetas");
            }
            else
            {
               
                return RedirectToAction("Index", "Usuario");
            }
           
        }

        public ActionResult ActualizarForm(int idCarpeta)
        {
            if (sv.ValidarSesion() == true)
            {
                ViewBag.carpeta = carpetaRepository.BuscarCarpeta(idCarpeta);

                return View();
            }
            else
            {
                Session["Controller"] = "Carpeta";
                Session["Action"] = "CrearForm";
                Session["IdCarpeta"] = idCarpeta.ToString();
                return RedirectToAction("Index", "Usuario");
            }


           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarCarpeta([Bind(Include = "IdCarpeta,Nombre,Descripcion")] Carpeta car)
        {
            if (sv.ValidarSesion() == true)
            {
                if (ModelState.IsValid)
                {
                    carpetaRepository.ActualizarCarpeta(car);

                    ViewBag.estado = "Carpeta Actualizada";

                    return RedirectToAction("MisCarpetas");


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