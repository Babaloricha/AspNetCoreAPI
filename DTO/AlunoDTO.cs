﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEscola.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }

        public DateTime dataInicio { get; set; } = DateTime.Now;
     
        public bool Ativo { get; set; } = true;
    }
}
