using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPwIII.Models;
using WebApplication1.Utilities;
using System.IO;


namespace TpPwIII.Controllers
{
    public class ArchivoController : Controller
    {
        ArchivoRepository archivoRepository = new ArchivoRepository();
        SessionValidator sv = new SessionValidator();

        // GET: Archivo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ArchivoTarea archivo) {

            if (sv.ValidarSesion() == true)
            {
                archivo.RutaArchivo = ArchivoUtility.Guardar(Request.Files[0], archivo.IdTarea, "");

                archivoRepository.Crear(archivo);

                return RedirectToAction("DetalleTarea", "Tarea", new { idTarea = archivo.IdTarea });
            }
            else
            {

                return RedirectToAction("Index", "Usuario");
            }

            


        }
    }
}