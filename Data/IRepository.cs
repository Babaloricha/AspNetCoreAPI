using SmartEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEscola.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();


        Aluno[] GetAllAlunos(bool incluiDisciplina);
        Aluno[] GetAllAlunosByDisciplina(int disciplinaID, bool incluiProfessor);
        Aluno GetAlunoByID(int id, bool incluiProfessor = false);

        Professor[] GetAllProfessores(bool incluiAluno);
        Professor[] GetAllProfessoresByDisciplina(int DisciplinaID, bool incluiAluno);
        Professor GetProfessorByID(int id, bool incluiAluno = false);
    }
}
