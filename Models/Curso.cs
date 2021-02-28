using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDAIntenacionalEjercicio.Models
{
    public class Curso
    {
        [Key]
        public int Id { set; get; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { set; get; }
        [Display(Name = "Año")]
        [Required(ErrorMessage = "Debe Ingresar el Año")]
        public string Año { set; get; }
        [Display(Name = "Semestre")]
        [Required(ErrorMessage = "Debe Ingresar el Semestre")]
        public string Semestre { set; get; }
        [Display(Name = "Turno")]
        [Required(ErrorMessage = "Debe Ingresar el Turno")]
        public string Turno { set; get; }
        public virtual List<Profesor> Profesores { set; get; }
        public virtual List<Alumno> Alumnos { set; get; }
        [NotMapped]
        public MultiSelectList ProfesoresView { set; get; }
        [NotMapped]
        public MultiSelectList AlumnosView { set; get; }
        [NotMapped]
        public List<string> AlumnosIds { set; get; }
        [NotMapped]
        public List<string> ProfesoresIds { set; get; }

    }
}