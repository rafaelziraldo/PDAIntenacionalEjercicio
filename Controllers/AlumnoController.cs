using PDAIntenacionalEjercicio.db;
using PDAIntenacionalEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDAIntenacionalEjercicio.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Index()
        {
            var db = new SqlEjercicioPDA();
            var alumnos = db.Alumnos.ToList();
            return View(alumnos);
        }

        public ActionResult Create()
        {
            var alumno = new Alumno();
            alumno.FechaDeIngreso = DateTime.Now;
            alumno.FechaDeNacimiento = DateTime.Now;


            return View(alumno);
        }
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                var db = new SqlEjercicioPDA();

                db.Alumnos.Add(alumno);
                db.SaveChanges();



                return Redirect("/Alumno/Index");
            }
            return View(alumno);
        }
        public ActionResult Detalle(int id)
        {
            var db = new SqlEjercicioPDA();
            var alumno = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();
            return View(alumno);
        }
    }
}