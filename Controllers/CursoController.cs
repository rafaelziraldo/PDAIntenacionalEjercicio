using PDAIntenacionalEjercicio.db;
using PDAIntenacionalEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDAIntenacionalEjercicio.Controllers
{
    public class CursoController : Controller
    {
        public ActionResult Index()
        {
            var db = new SqlEjercicioPDA();
            var cursos = db.Cursos.ToList();
            return View(cursos);
        }

        public ActionResult Create()
        {

            var db = new SqlEjercicioPDA();
            var curso = new Curso();
            CargarSelect(db, curso);



            return View(curso);
        }
        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            var db = new SqlEjercicioPDA();
            curso.Alumnos = new List<Alumno>();
            curso.Profesores = new List<Profesor>();
            if (ModelState.IsValid)
            {
                foreach (var alum in curso.AlumnosIds)
                {
                    curso.Alumnos.Add(db.Alumnos.ToList().Where(a => a.Id.ToString() == alum).First());
                }
                foreach (var profe in curso.ProfesoresIds)
                {
                    curso.Profesores.Add(db.Profesores.ToList().Where(a => a.Id.ToString() == profe).First());
                }

                db.Cursos.Add(curso);
                db.SaveChanges();



                return Redirect("/Curso/Index");
            }
            CargarSelect(db,curso);
            return View(curso);
        }
        public ActionResult Detalle(int id)
        {
            var db = new SqlEjercicioPDA();
            var curso = db.Cursos.Where(a => a.Id == id).FirstOrDefault();
            return View(curso);
        }

        public void CargarSelect(SqlEjercicioPDA db,Curso curso)
        {
            List<SelectListItem> itemsProfesores = new List<SelectListItem>();
            curso.ProfesoresIds = new List<string>();

            var profesores = db.Profesores.ToList();
            //string[] profesoresId = new string[profesores.Count];
            for (var i = 0; i < profesores.Count; i++)
            {
                itemsProfesores.Add(new SelectListItem()
                {
                    Text = profesores[i].Nombre + " " + profesores[i].Apellido,
                    Value = profesores[i].Id.ToString()
                });
                //profesoresId[i] = profesores[i].Id.ToString();

            }
            curso.ProfesoresView = new MultiSelectList(itemsProfesores.OrderBy(i => i.Text), "Value", "Text");

            List<SelectListItem> itemsAlumnos = new List<SelectListItem>();
            curso.AlumnosIds = new List<string>();

            var alumnos = db.Alumnos.ToList();
            //string[] alumnosId = new string[alumnos.Count];
            for (var i = 0; i < alumnos.Count; i++)
            {
                itemsAlumnos.Add(new SelectListItem()
                {
                    Text = alumnos[i].Nombre + " " + alumnos[i].Apellido,
                    Value = alumnos[i].Id.ToString()
                });
                //alumnosId[i] = alumnos[i].Id.ToString();

            }
            curso.AlumnosView = new MultiSelectList(itemsAlumnos.OrderBy(i => i.Text), "Value", "Text");
        }
    }
}