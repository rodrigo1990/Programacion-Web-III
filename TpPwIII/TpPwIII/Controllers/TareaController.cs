using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPwIII.Models;

namespace TpPwIII.Controllers
{
    public class TareaController : Controller
    {
        CarpetaRepository carpetaRepository = new CarpetaRepository();
        TareaRepository tareaRepository = new TareaRepository();
        SessionValidator sv = new SessionValidator();
        // GET: Tarea
        public ActionResult MostrarTarea(int idCarpeta)
        {
            if (sv.ValidarSesion() == true)
            {
                ViewBag.tareas = tareaRepository.BuscarTareasPorCarpeta(idCarpeta,Int32.Parse(Session["ID"].ToString()));
                
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
                ViewBag.carpetas = carpetaRepository.BuscarCarpetas(Int32.Parse(Session["ID"].ToString()));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
                
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Nombre,Descripcion,FechaFin,Prioridad")] Tarea tar,FormCollection form)
        {
            if (sv.ValidarSesion() == true)
            {
                if (ModelState.IsValid)
                {
                    //  tar.EstimadoHoras = 2.5M;
                    tar.EstimadoHoras = Convert.ToDecimal(form["EstimadoHoras"]);
                    tar.IdCarpeta = Int32.Parse(form["Carpeta"].ToString());
                    tar.FechaCreacion = DateTime.Now;
                    tar.IdUsuario = Int32.Parse(Session["ID"].ToString());
                    tar.Completada = 0;
                    tar.FechaFin = Convert.ToDateTime(tar.FechaFin.ToString());
                    tareaRepository.InsertarTarea(tar);

                    ViewBag.estado = "Tarea registrada";
                    return View("Home","Usuario");

                }
                else
                {
                    ViewBag.estado = "Tarea NO registrada";
                    return View("MostrarTarea");
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }

            
        }//function

        public ActionResult MisTareas()
        {
            ViewBag.tareas = tareaRepository.ListarTareas(Int32.Parse(Session["ID"].ToString()));

            return View();
           

        }

        public ActionResult ListarTareasCompletadas()
        {
            ViewBag.tareas = tareaRepository.ListarTareasCompletadas(Int32.Parse(Session["ID"].ToString()));

            return View("MisTareas");
        }

        public ActionResult ListarTareasIncompletas()
        {
            ViewBag.tareas = tareaRepository.ListarTareasIncompletas(Int32.Parse(Session["ID"].ToString()));

            return View("MisTareas");
        }

        public ActionResult CompletarTarea(int idTarea)
        {
            tareaRepository.CompletarTarea(idTarea);

            return RedirectToAction("Home", "Usuario");
        }

        public ActionResult DetalleTarea(int idTarea)
        {
            ViewBag.tarea = tareaRepository.ListarTarea(idTarea);

            return View();
        }
    }
}