using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Aluno : Pessoa
    {      
        public int NumMatricula { get; set; }

        public Aluno(string nome, string cpf, DateTime dataNascimento, int numMatricula)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            NumMatricula = numMatricula;
        }

        public override string ToString()
        {
            return
                "===============================\n" +
                $"Nome: {Nome}\n" +
                $"CPF: {Cpf}\n" +
                $"Data de Nascimento: {DataNascimento.ToShortDateString()}\n" +         
                $"Número de Matrícula: {NumMatricula}\n" +
                "===============================\n";
        }
    }
}

