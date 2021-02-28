using PDAIntenacionalEjercicio.db;
using PDAIntenacionalEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDAIntenacionalEjercicio.Controllers
{
    public class ProfesorController : Controller
    {
        public ActionResult Index()
        {
            var db = new SqlEjercicioPDA();
            var alumnos = db.Profesores.ToList();
            return View(alumnos);
        }

        public ActionResult Create()
        {
            var profesor = new Profesor();

            profesor.FechaDeNacimiento = DateTime.Now;


            return View(profesor);
        }
        [HttpPost]
        public ActionResult Create(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                var db = new SqlEjercicioPDA();

                db.Profesores.Add(profesor);
                db.SaveChanges();



                return Redirect("/Profesor/Index");
            }
            return View(profesor);
        }
    }
}