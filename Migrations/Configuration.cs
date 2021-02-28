namespace PDAIntenacionalEjercicio.Migrations
{
    using PDAIntenacionalEjercicio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PDAIntenacionalEjercicio.db.SqlEjercicioPDA>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PDAIntenacionalEjercicio.db.SqlEjercicioPDA context)
        {
            context.Alumnos.Add(new Alumno
            {
                Nombre = "Jose",
                Apellido = "Hernandez",
                FechaDeNacimiento = new DateTime(1995, 4, 5),
                DNI = "32456789",
                Sexo = "M",
                FechaDeIngreso = new DateTime(2019, 3, 4),
                Carrera = "Ingenieria en Sistemas",
                Domicilio = "Los Pinos 1276"
            });
            context.Alumnos.Add(new Alumno
            {
                Nombre = "Laura",
                Apellido = "Fernandez",
                FechaDeNacimiento = new DateTime(1997, 7, 12),
                DNI = "30456789",
                Sexo = "M",
                FechaDeIngreso = new DateTime(2019, 2, 20),
                Carrera = "Ingenieria en Sistemas",
                Domicilio = "Emancipador 1276"
            });
            context.Profesores.Add(new Profesor
            {
                Nombre = "Pedro",
                Apellido = "Aguirre",
                FechaDeNacimiento = new DateTime(1970, 4, 5),
                DNI = "25456543",
                Sexo = "M",
              
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
