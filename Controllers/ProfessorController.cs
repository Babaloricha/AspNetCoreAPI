using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(){}

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Professores: Marta,Paula,Lucas,Rafa");
        }
    }
}
