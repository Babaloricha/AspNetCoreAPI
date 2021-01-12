using Microsoft.EntityFrameworkCore;
using SmartEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEscola.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }


        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool incluiDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluiDisciplina)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();

        }


        public Aluno GetAlunoByID(int id,bool incluiProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluiProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().Where(a => a.Id == id);

            return query.ToArray().FirstOrDefault();
        }

        public Aluno[] GetAllAlunosByDisciplina(int disciplinaID, bool incluiProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluiProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.AlunoDisciplinas.Any(ad => ad.DisciplinaId == disciplinaID));

            return query.ToArray();
        }

        

        public Professor[] GetAllProfessores(bool incluiAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if (incluiAluno)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(pd => pd.AlunoDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplina(int DisciplinaID ,bool incluiAluno = false)
        {   
            IQueryable<Professor> query = _context.Professores;

            if (incluiAluno)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(pd => pd.AlunoDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(professor => professor.Disciplinas.Any(ad => ad.AlunoDisciplinas.Any(d => d.DisciplinaId == DisciplinaID )));

            return query.ToArray();
        }

        public Professor GetProfessorByID(int id, bool incluiAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (incluiAluno)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(pd => pd.AlunoDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().Where(p => p.Id == id);

            return query.FirstOrDefault();
        }
    }
}
