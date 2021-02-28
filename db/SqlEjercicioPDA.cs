using PDAIntenacionalEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PDAIntenacionalEjercicio.db
{
   
        public class SqlEjercicioPDA : DbContext
        {
            public SqlEjercicioPDA() : base("Ejercicio PDA")
            {
            }

            public DbSet<Alumno> Alumnos { get; set; }
            public DbSet<Curso> Cursos { get; set; }
            public DbSet<Profesor> Profesores { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    
}