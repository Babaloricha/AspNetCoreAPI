using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEscola.DTO
{
    public class ProfessorRegisterDTO
    {
        public int Id { get; set; }

        public int Registro { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public DateTime dataInicio { get; set; } = DateTime.Now;
        public DateTime? dataFim { get; set; } = null;

        public bool Ativo { get; set; } = true;
    }
}
