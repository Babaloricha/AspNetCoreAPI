using Microsoft.EntityFrameworkCore;
using SmartEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEscola.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) {}
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoCurso>()
                .HasKey(AC => new { AC.AlunoId, AC.CursoId });

            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });


            builder.Entity<Professor>()
                .HasData(new List<Professor>() {
                    new Professor(1,1,"Lauro","Olivira"),
                    new Professor(2,2,"Roberto","Soares"),
                    new Professor(3,3,"Ronaldo","Marconi"),
                    new Professor(4,4,"Rodrigo","Carvalho"),
                    new Professor(5,5,"Lauro","Olivira"),
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>() {
                    new Curso(1,"Tecnologia da Informaçao"),
                    new Curso(2,"Sistemas da Informaçao"),
                    new Curso(3,"Ciencia da Informaçao")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>
                {
                    new Disciplina(1,"Matematica",1,1),
                    new Disciplina(2,"Matematica",1,3),
                    new Disciplina(3,"Fisica",2,3),
                    new Disciplina(4,"Portugues",3,1),
                    new Disciplina(5,"Ingles",4,1),
                    new Disciplina(6,"Ingles",4,2),
                    new Disciplina(7,"Ingles",4,3),
                    new Disciplina(8,"Programação",5,1),
                    new Disciplina(9,"Programação",5,2),
                    new Disciplina(10,"Programação",5,3)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>() {
                    new Aluno(1,1,"Marta","Kent","11111111",DateTime.Parse("01/01/1999")),
                    new Aluno(2,2,"Eduardo","Kent","11111111",DateTime.Parse("01/01/1989")),
                    new Aluno(3,3,"Maria","Kent","11111111",DateTime.Parse("01/01/1900")),
                    new Aluno(4,4,"Rafael","Kent","11111111",DateTime.Parse("01/01/1900")),
                    new Aluno(5,5,"Carlos","Kent","11111111",DateTime.Parse("01/01/1800")),
                    new Aluno(6,6,"Adriana","Kent","11111111",DateTime.Parse("01/01/2000")),
                    new Aluno(7,7,"Pedro","Kent","11111111",DateTime.Parse("01/01/2015")),
                });

            builder.Entity<AlunoDisciplina>()
                 .HasData(new List<AlunoDisciplina>() { 
                     new AlunoDisciplina() {AlunoId = 1,DisciplinaId = 2 },
                     new AlunoDisciplina() {AlunoId = 1,DisciplinaId = 4 },
                     new AlunoDisciplina() {AlunoId = 1,DisciplinaId = 5 },
                     new AlunoDisciplina() {AlunoId = 2,DisciplinaId = 1 },
                     new AlunoDisciplina() {AlunoId = 2,DisciplinaId = 2 },
                     new AlunoDisciplina() {AlunoId = 2,DisciplinaId = 5 },
                     new AlunoDisciplina() {AlunoId = 3,DisciplinaId = 1 },
                     new AlunoDisciplina() {AlunoId = 3,DisciplinaId = 2 },
                     new AlunoDisciplina() {AlunoId = 3,DisciplinaId = 3 },
                     new AlunoDisciplina() {AlunoId = 4,DisciplinaId = 1 },
                     new AlunoDisciplina() {AlunoId = 4,DisciplinaId = 4 },
                     new AlunoDisciplina() {AlunoId = 4,DisciplinaId = 5 },
                     new AlunoDisciplina() {AlunoId = 5,DisciplinaId = 2 },
                     new AlunoDisciplina() {AlunoId = 5,DisciplinaId = 4 },
                     new AlunoDisciplina() {AlunoId = 5,DisciplinaId = 5 },
                     new AlunoDisciplina() {AlunoId = 6,DisciplinaId = 2 },
                     new AlunoDisciplina() {AlunoId = 6,DisciplinaId = 3 },
                     new AlunoDisciplina() {AlunoId = 6,DisciplinaId = 4 },
                     new AlunoDisciplina() {AlunoId = 7,DisciplinaId = 3 },
                     new AlunoDisciplina() {AlunoId = 7,DisciplinaId = 4 },
                     new AlunoDisciplina() {AlunoId = 7,DisciplinaId = 5 }
                 });
        }
    }
}
