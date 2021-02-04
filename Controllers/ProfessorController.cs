using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEscola.Data;
using SmartEscola.DTO;
using SmartEscola.Models;

namespace SmartEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professores));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(_mapper.Map<ProfessorDTO>(professor));
        }

        
        [HttpPost]
        public IActionResult Post(ProfessorRegisterDTO model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(professor));
            }

            return BadRequest("Professor nao Cadastrado");
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegisterDTO model)
        {
            
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("Professor nao encontrado");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(professor));
            }

            return BadRequest("Professor nao Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegisterDTO model)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("Professor nao encontrado");

            _mapper.Map(model, professor);

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDTO>(professor));
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
