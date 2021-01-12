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
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        private readonly IRepository _repo;
        public ProfessorController(SmartContext context,IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor nao Cadastrado");
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {

            var prof = _repo.GetProfessorByID(id);
            if (prof == null) return BadRequest("Professor nao encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor nao Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorByID(id);
            if (prof == null) return BadRequest("Professor nao encontrado");

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Patch(int id)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("Professor nao encontrado");
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professo Excluido");
            }
            return BadRequest("Professor nao excluido");
        }
    }
}
