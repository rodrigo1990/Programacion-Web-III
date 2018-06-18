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
        }
    }
}