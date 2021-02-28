using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDAIntenacionalEjercicio.Models
{
    public abstract class Persona
    {
        [Key]
        public int Id { set; get; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { set; get; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Debe Ingresar el Apellido")]
        public string Apellido { set; get; }
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Debe Ingresar el DNI")]
        public string DNI { set; get; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { set; get; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Debe Seleccionar Sexo")]
        public string Sexo { set; get; }
        public List<Curso> Cursos { set; get; }

    }
}