using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPwIII.Models
{
    public class TareaM
    {
        public int IdTarea { get; set; }
        public int IdCarpeta { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> EstimadoHoras { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public short Prioridad { get; set; }
        public short Completada { get; set; }
        public System.DateTime FechaCreacion { get; set; }

        public TareaM ModelarTarea(Tarea tarea)
        {
            TareaM tareaM = new TareaM();
            tareaM.IdTarea = tarea.IdTarea;
            tareaM.IdCarpeta = tarea.IdCarpeta;
            tareaM.IdUsuario = tarea.IdUsuario;
            tareaM.Nombre = tarea.Nombre;
            tareaM.Descripcion = tarea.Descripcion;
            tareaM.FechaCreacion = tarea.FechaCreacion;

            tareaM.FechaFin = tarea.FechaFin;
            tareaM.EstimadoHoras = tarea.EstimadoHoras;
            tareaM.Prioridad = tarea.Prioridad;

          

            return tareaM;
        }
    }
}