using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpPwIII.Models;

namespace TpPwIII.Controllers
{
    public class ComentarioController : Controller
    {
        ComentarioRepository comentarioRepository = new ComentarioRepository();
        SessionValidator sv = new SessionValidator();
        

        // GET: Comentario
        public ActionResult Crear(ComentarioTarea comentario)
        {
            if (sv.ValidarSesion() == true)
            {
                comentarioRepository.InsertarComentario(comentario);

                return RedirectToAction("DetalleTarea", "Tarea", new { idTarea = comentario.IdTarea });
            }
            else
            {

                return RedirectToAction("Index", "Usuario");
            }


           
        }
    }
}