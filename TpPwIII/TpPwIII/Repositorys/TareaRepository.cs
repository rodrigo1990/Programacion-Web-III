using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
namespace TpPwIII.Models
{
    public class TareaRepository
    {
        MyContext ctx = new MyContext();
        ComentarioRepository comentarioRepository = new ComentarioRepository();
        List<ComentarioTarea> comentarios = new List<ComentarioTarea>();
        List<Tarea> tareas;


        public void InsertarTarea(Tarea tar)
        {

          
            try
            {
                ctx.Tareas.Add(tar);
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
        }//function

       

        public List<Tarea> BuscarTareasPorCarpetaYUsuario(int idCarpeta,int idUsuario)
        {
            tareas = new List<Tarea>();

            tareas = ctx.Tareas.Where(o => o.IdCarpeta == idCarpeta).Where(o=>o.IdUsuario==idUsuario).ToList();

            return tareas;

        }

        public List<Tarea> BuscarTareasPorCarpeta(int idCarpeta)
        {
            tareas = new List<Tarea>();

            tareas = ctx.Tareas.Where(o => o.IdCarpeta == idCarpeta).ToList();

            return tareas;

        }

        public List<Tarea> ListarTareas(int idUsuario)
        {

            tareas = new List<Tarea>();

            tareas = ctx.Tareas.Where(o=>o.IdUsuario==idUsuario).OrderByDescending(o => o.FechaCreacion).ToList();

            return tareas;

            

        }

        public List<Tarea> ListarTareasCompletadas(int idUsuario)
        {
            tareas = new List<Tarea>();
            tareas = ctx.Tareas.Where(o=>o.IdUsuario==idUsuario).Where(o => o.Completada == 1).ToList();

            return tareas;
        }


        public List<Tarea> ListarTareasIncompletas(int idUsuario)
        {
            tareas = new List<Tarea>();
            tareas = ctx.Tareas.Where(o => o.IdUsuario == idUsuario).Where(o => o.Completada == 0).ToList();

            return tareas;
        }

        public List<TareaHomeViewModel> ListarTareasConCarpeta(int idUsuario)
        {
           List<TareaHomeViewModel> tareas = new List<TareaHomeViewModel>();

            tareas = (from Tarea in ctx.Tareas
                          join Carpeta in ctx.Carpetas on Tarea.IdCarpeta equals Carpeta.IdCarpeta
                      where Tarea.IdUsuario==idUsuario
                      where Tarea.Completada==0
                      orderby Tarea.FechaFin descending, Tarea.Prioridad ascending
                          select new TareaHomeViewModel {
                              IdTarea = Tarea.IdTarea,
                              FechaFin  = Tarea.FechaFin,
                              Nombre = Tarea.Nombre,
                              Prioridad = Tarea.Prioridad,
                              NombreCarpeta = Carpeta.Nombre,
                              EstimadoHoras = Tarea.EstimadoHoras,
                              Completada = Tarea.Completada
                          }).ToList();

            return tareas;
        }//action

        public void CompletarTarea(int idTarea)
        {
            Tarea tarea = new Tarea();

            tarea = ctx.Tareas.Find(idTarea);

            tarea.Completada = 1;

            ctx.SaveChanges();
        }

        public Tarea ListarTarea(int idTarea)
        {
            Tarea tarea = new Tarea();
            tarea = ctx.Tareas.Find(idTarea);

            return tarea;
        }


        public void EliminarTarea(Tarea tarea)
        {
            //Elimino comentarios
            comentarios = comentarioRepository.BuscarComentarios(tarea.IdTarea);

            ctx.Tareas.Remove(tarea);


            foreach (ComentarioTarea comentario in comentarios)
            {
                ctx.Comentarios.Attach(comentario);
                ctx.Comentarios.Remove(comentario);
            }

           
            ctx.SaveChanges();
        }

        public void ActualizarTarea(Tarea nuevaTarea)
        {
            Tarea tarea;
            tarea = ctx.Tareas.Find(nuevaTarea.IdTarea);

            tarea.Nombre = nuevaTarea.Nombre;
            tarea.Descripcion = nuevaTarea.Descripcion;
            tarea.FechaFin = nuevaTarea.FechaFin;
            tarea.IdCarpeta = nuevaTarea.IdCarpeta;
            tarea.EstimadoHoras = nuevaTarea.EstimadoHoras;
            tarea.Prioridad = nuevaTarea.Prioridad;

            ctx.SaveChanges();
        }
    }
}