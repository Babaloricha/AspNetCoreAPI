using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEscola.Data;
using SmartEscola.Models;

namespace SmartEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

       
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não Cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Aluno aluno)
        {

            var alu = _repo.GetAlunoByID(id);
            if (alu == null) return BadRequest("Aluno nao encontrado");


            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoByID(id);
            if (alu == null) return BadRequest("Aluno nao encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Patch(int id)
        {
            var aluno = _repo.GetAlunoByID(id);
            if (aluno == null) return BadRequest("Aluno nao encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno excluido");
            }

            return BadRequest("Aluno não Excluido");
        }
    }
}
