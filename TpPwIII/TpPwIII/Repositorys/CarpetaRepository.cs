﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncryptData;


namespace TpPwIII.Models
{
    public class CarpetaRepository
    {
        TareaRepository tareaRepository = new TareaRepository();
        ComentarioRepository comentarioRepository = new ComentarioRepository();
        MyContext ctx = new MyContext();
        List<Tarea> tareas = new List<Tarea>();
        List<ComentarioTarea> comentarios = new List<ComentarioTarea>();
        

        public void InsertarCarpeta(Carpeta car)
        {
            car.IdUsuario = Int32.Parse(System.Web.HttpContext.Current.Session["ID"].ToString());
            car.FechaCreacion = DateTime.Now;

            ctx.Carpetas.Add(car);
            ctx.SaveChanges();
        }

        public List<Carpeta> BuscarCarpetas(int idUsuario)
        {
            return ctx.Carpetas.Where(o => o.IdUsuario == idUsuario ||  o.IdUsuario == null).OrderBy(o=>o.Nombre).ToList();
        }

        public List<Carpeta> BuscarCarpetasMenosGeneral(int idUsuario)
        {
            return ctx.Carpetas.Where(o => o.IdUsuario == idUsuario).OrderByDescending(o => o.Nombre).ToList();
        }

        public void EliminarCarpeta(int idCarpeta)
        {
            tareas = tareaRepository.BuscarTareasPorCarpeta(idCarpeta);

            foreach(Tarea tarea in tareas)
            {
                tareaRepository.EliminarTarea(tarea);

            }

            Carpeta carpeta = new Carpeta();

            carpeta = ctx.Carpetas.Where(o=>o.IdCarpeta==idCarpeta).First();

            ctx.Carpetas.Remove(carpeta);

            ctx.SaveChanges();

        }


        public Carpeta BuscarCarpeta(int idCarpeta)
        {
            Carpeta carpeta = ctx.Carpetas.Find(idCarpeta);

            return carpeta;
        }

        public void ActualizarCarpeta(Carpeta nuevaCarpeta)
        {
            Carpeta carpeta = ctx.Carpetas.Find(nuevaCarpeta.IdCarpeta);

            carpeta.Nombre = nuevaCarpeta.Nombre;
            carpeta.Descripcion = nuevaCarpeta.Descripcion;

            ctx.SaveChanges();
        }

        public void CrearGeneral()
        {
            if (BuscarGeneral() == null) { 
                Carpeta c = new Carpeta();
                c.FechaCreacion = DateTime.Now;
                c.Nombre = "General";
                c.Descripcion = "Carpeta general";
                c.IdUsuario = null;

                ctx.Carpetas.Add(c);
                ctx.SaveChanges();
            }

        }

        public Carpeta BuscarGeneral()
        {
            Carpeta carpeta = ctx.Carpetas.Where(o => o.Nombre == "General").FirstOrDefault();
            if (carpeta != null) { 
            return carpeta;
            }
            else
            {
                return null;
            }
        }

    }
}