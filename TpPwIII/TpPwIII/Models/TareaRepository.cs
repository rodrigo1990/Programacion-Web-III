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

        public List<Tarea> BuscarTareasPorCarpeta(int idCarpeta)
        {
            tareas = new List<Tarea>();

            tareas = ctx.Tareas.Where(o => o.IdCarpeta == idCarpeta).ToList();

            return tareas;

        }

        public List<Tarea> ListarTareas()
        {

            tareas = new List<Tarea>();

            tareas = ctx.Tareas.OrderByDescending(o => o.FechaCreacion).ToList();

            return tareas;

            

        }

        public List<Tarea> ListarTareasCompletadas()
        {
            tareas = new List<Tarea>();
            tareas = ctx.Tareas.Where(o => o.Completada == 1).ToList();

            return tareas;
        }


        public List<Tarea> ListarTareasIncompletas()
        {
            tareas = new List<Tarea>();
            tareas = ctx.Tareas.Where(o => o.Completada == 0).ToList();

            return tareas;
        }
    }
}