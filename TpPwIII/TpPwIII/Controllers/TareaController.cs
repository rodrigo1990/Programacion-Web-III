using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPwIII.Models;
using System.Globalization;


namespace TpPwIII.Controllers
{
    public class TareaController : Controller
    {
        CarpetaRepository carpetaRepository = new CarpetaRepository();
        TareaRepository tareaRepository = new TareaRepository();
        SessionValidator sv = new SessionValidator();
        ComentarioRepository comentarioRepository = new ComentarioRepository();
        ArchivoRepository archivoRepository = new ArchivoRepository();


        // GET: Tarea
        public ActionResult MostrarTarea(int idCarpeta)
        {
            if (sv.ValidarSesion() == true)
            {

                List<Tarea> lista = tareaRepository.BuscarTareasPorCarpetaYUsuario(idCarpeta,Int32.Parse(Session["ID"].ToString()));
                
                return View(lista);
            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "MostrarTarea";
                Session["IdCarpeta"] = idCarpeta.ToString();

                return RedirectToAction("Index", "Usuario");
            }

        }

        public ActionResult CrearForm()
        {
            if (sv.ValidarSesion() == true)
            {
                
                ViewBag.carpetas = carpetaRepository.BuscarCarpetasMenosGeneral(Int32.Parse(Session["ID"].ToString()));
                return View();
            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "CrearForm";
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
                    CultureInfo culture = new CultureInfo("en-US");

                    if (Request["EstimadoHoras"] != "") { 
                        tar.EstimadoHoras=Convert.ToDecimal(Request["EstimadoHoras"],culture);
                    }

                    if (form["Carpeta"] == "0") { 
                        tar.IdCarpeta = 1;
                    }
                    else { 
                        tar.IdCarpeta = Int32.Parse(form["Carpeta"].ToString());
                    }
                    tar.FechaCreacion = DateTime.Now;
                    tar.IdUsuario = Int32.Parse(Session["ID"].ToString());
                    tar.Completada = 0;
                    if (tar.FechaFin != null) { 
                        tar.FechaFin = Convert.ToDateTime(tar.FechaFin.ToString());
                    }
                    else
                    {
                        tar.FechaFin = null;
                    }
                    tareaRepository.InsertarTarea(tar);

                    ViewBag.estado = "Tarea registrada";
                    return RedirectToAction("MisTareas");

                }
                else
                {
                    ViewBag.estado = "Tarea NO registrada";
                    return RedirectToAction("Home","Usuario");
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }

            
        }//function

        public ActionResult MisTareas()
        {
            if (sv.ValidarSesion() == true) {

                List<Tarea> lista = tareaRepository.ListarTareas(Int32.Parse(Session["ID"].ToString()));
                return View(lista);
            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "MisTareas";

                return RedirectToAction("Index", "Usuario");
            }
            
           

        }

        public ActionResult ListarTareasCompletadas()
        {
            if (sv.ValidarSesion() == true)
            {
                List<Tarea> lista = tareaRepository.ListarTareasCompletadas(Int32.Parse(Session["ID"].ToString()));

                return View("MisTareas", lista);
            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "ListarTareasCompletadas";
                return RedirectToAction("Index", "Usuario");
            }


            
        }

        public ActionResult ListarTareasIncompletas()
        {
            if (sv.ValidarSesion() == true)
            {
                List<Tarea> lista = tareaRepository.ListarTareasIncompletas(Int32.Parse(Session["ID"].ToString()));

                return View("MisTareas", lista);
            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "ListarTareasIncompletas";
                return RedirectToAction("Index", "Usuario");
            }



        }

        public ActionResult CompletarTarea(int idTarea)
        {
            if (sv.ValidarSesion() == true) { 
                tareaRepository.CompletarTarea(idTarea);

            return RedirectToAction("Home", "Usuario");
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        public ActionResult DetalleTarea(int idTarea)
        {
            if (sv.ValidarSesion() == true)
            {
       
                ViewBag.tarea = tareaRepository.ListarTarea(idTarea);
                ViewBag.comentarios = comentarioRepository.BuscarComentarios(idTarea);
                ViewBag.archivos = archivoRepository.BuscarArchivos(idTarea);
                return View();

            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "DetalleTarea";
                Session["IdTarea"] = idTarea.ToString();
                return RedirectToAction("Index", "Usuario");
            }


            
        }

        public ActionResult EliminarTarea(int idTarea)
        {
            if (sv.ValidarSesion() == true)
            {
                Tarea tarea = tareaRepository.ListarTarea(idTarea);

                tareaRepository.EliminarTarea(tarea);

                return RedirectToAction("MisTareas", "Tarea");

            }
            else
            {
               
                return RedirectToAction("Index", "Usuario");
            }


           
        }

        public ActionResult ActualizarForm(int idTarea)
        {
            if (sv.ValidarSesion() == true)
            {
                ViewBag.carpetas = carpetaRepository.BuscarCarpetas(Int32.Parse(Session["ID"].ToString()));
                ViewBag.tarea = tareaRepository.ListarTarea(idTarea);
                ViewBag.FechaFin = ViewBag.tarea.FechaFin.ToString("yyyy-MM-dd");
                ViewBag.EstimadoHoras = System.Convert.ToString(ViewBag.tarea.EstimadoHoras);
                ViewBag.EstimadoHoras = ViewBag.EstimadoHoras.Replace(",", ".");

                return View();

            }
            else
            {
                Session["Controller"] = "Tarea";
                Session["Action"] = "ActualizarForm";
                Session["IdTarea"] = idTarea.ToString();
                return RedirectToAction("Index", "Usuario");
            }


            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar([Bind(Include = "IdTarea,Nombre,Descripcion,FechaFin,Prioridad")] Tarea tar, FormCollection form)
        {
            if (sv.ValidarSesion() == true)
            {
                if (ModelState.IsValid)
                {
                    //  tar.EstimadoHoras = 2.5M;
                    tar.EstimadoHoras = Convert.ToDecimal(form["EstimadoHoras"]);
                    tar.IdCarpeta = Int32.Parse(form["Carpeta"]);
                    tar.FechaCreacion = DateTime.Now;
                    tar.IdUsuario = Int32.Parse(Session["ID"].ToString());
                    tar.Completada = 0;
                    tar.FechaFin = Convert.ToDateTime(tar.FechaFin.ToString());
                    tareaRepository.ActualizarTarea(tar);

                    ViewBag.estado = "Tarea actualizada";
                    return RedirectToAction("MisTareas");

                }
                else
                {
                    ViewBag.estado = "Tarea NO actualizada";
                    return View("Home", "Usuario");
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }
    }
}