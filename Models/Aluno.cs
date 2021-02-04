﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEscola.Models
{
    public class Aluno
    {
        public Aluno() { }

        public Aluno(int id, int matricula,string nome,string sobrenome,string telefone,DateTime dataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;
            this.Matricula = matricula;

        }

        public int Id { get; set; }

        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public DateTime dataInicio { get; set; } = DateTime.Now;
        public DateTime? dataFim { get; set; } = null;

        public bool Ativo { get; set; } = true;


        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
