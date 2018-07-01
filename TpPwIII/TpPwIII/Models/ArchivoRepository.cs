using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPwIII.Models
{
    public class ArchivoRepository
    {
        MyContext ctx = new MyContext();
        List<ArchivoTarea> lista = new List<ArchivoTarea>();
        public void Crear(ArchivoTarea archivo)
        {
            archivo.FechaCreacion = DateTime.Now;
            ctx.Archivos.Add(archivo);

            ctx.SaveChanges();
        }

        public List<ArchivoTarea> BuscarArchivos(int idTarea)
        {
            lista = ctx.Archivos.Where(o => o.IdTarea == idTarea).ToList();

            return lista;
        }
    }
}