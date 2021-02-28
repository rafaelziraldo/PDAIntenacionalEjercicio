namespace PDAIntenacionalEjercicio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaDeIngreso = c.DateTime(nullable: false),
                        Carrera = c.String(nullable: false),
                        Domicilio = c.String(),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        DNI = c.String(nullable: false),
                        FechaDeNacimiento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Año = c.String(nullable: false),
                        Semestre = c.String(nullable: false),
                        Turno = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        DNI = c.String(nullable: false),
                        FechaDeNacimiento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CursoAlumno",
                c => new
                    {
                        Curso_Id = c.Int(nullable: false),
                        Alumno_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Curso_Id, t.Alumno_Id })
                .ForeignKey("dbo.Curso", t => t.Curso_Id, cascadeDelete: true)
                .ForeignKey("dbo.Alumno", t => t.Alumno_Id, cascadeDelete: true)
                .Index(t => t.Curso_Id)
                .Index(t => t.Alumno_Id);
            
            CreateTable(
                "dbo.ProfesorCurso",
                c => new
                    {
                        Profesor_Id = c.Int(nullable: false),
                        Curso_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profesor_Id, t.Curso_Id })
                .ForeignKey("dbo.Profesor", t => t.Profesor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.Curso_Id, cascadeDelete: true)
                .Index(t => t.Profesor_Id)
                .Index(t => t.Curso_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfesorCurso", "Curso_Id", "dbo.Curso");
            DropForeignKey("dbo.ProfesorCurso", "Profesor_Id", "dbo.Profesor");
            DropForeignKey("dbo.CursoAlumno", "Alumno_Id", "dbo.Alumno");
            DropForeignKey("dbo.CursoAlumno", "Curso_Id", "dbo.Curso");
            DropIndex("dbo.ProfesorCurso", new[] { "Curso_Id" });
            DropIndex("dbo.ProfesorCurso", new[] { "Profesor_Id" });
            DropIndex("dbo.CursoAlumno", new[] { "Alumno_Id" });
            DropIndex("dbo.CursoAlumno", new[] { "Curso_Id" });
            DropTable("dbo.ProfesorCurso");
            DropTable("dbo.CursoAlumno");
            DropTable("dbo.Profesor");
            DropTable("dbo.Curso");
            DropTable("dbo.Alumno");
        }
    }
}
