using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpPwIII.Models
{
    public class ComentarioRepository
    {
        MyContext ctx = new MyContext();
        List<ComentarioTarea> comentarios;
        
        public void InsertarComentario(ComentarioTarea comentario)
        {
            comentario.FechaCreacion = DateTime.Now;
            ctx.Comentarios.Add(comentario);
            ctx.SaveChanges();

        }

        public List<ComentarioTarea> BuscarComentarios(int idTarea)
        {
            comentarios = new List<ComentarioTarea>();
            comentarios = ctx.Comentarios.Where(o => o.IdTarea == idTarea).ToList();

            return comentarios;
        }

       

    }
}