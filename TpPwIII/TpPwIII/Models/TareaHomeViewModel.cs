using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPwIII.Models
{
    public class TareaHomeViewModel
    {
        public int IdTarea { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string Nombre { get; set; }
        public short Prioridad { get; set; }
        public string NombreCarpeta { get; set; }
        public Nullable<decimal> EstimadoHoras { get; set; }
        public short Completada { get; set; }

    }

    
}