using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncryptData;


namespace TpPwIII.Models
{
    public class CarpetaRepository
    {
        MyContext ctx = new MyContext();

        public void InsertarCarpeta(Carpeta car)
        {
            car.IdUsuario = Int32.Parse(System.Web.HttpContext.Current.Session["ID"].ToString());
            car.FechaCreacion = DateTime.Now;

            ctx.Carpetas.Add(car);
            ctx.SaveChanges();
        }

        public List<Carpeta> BuscarCarpetas(int idUsuario)
        {
            return ctx.Carpetas.Where(o => o.IdUsuario == idUsuario).OrderBy(o=>o.Nombre).ToList();
        }

    }
}