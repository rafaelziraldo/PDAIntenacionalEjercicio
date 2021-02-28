using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDAIntenacionalEjercicio.Models
{
    public class Alumno : Persona
    {
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaDeIngreso { set; get; }
        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Debe Ingresar una Carrera")]
        public string Carrera { set; get; }
        [Display(Name = "Domicilio")]
        public string Domicilio { set; get; }


        public Alumno()
        {

        }
    }
}