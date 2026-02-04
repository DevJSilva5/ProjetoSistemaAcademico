using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Aluno : Pessoa
    {

        public string Curso { get; set; }
        public int NumMatricula { get; set; }

    public Aluno(string nome, long cpf, DateTime dataNascimento, string curso, int numMatricula)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Curso = curso;
            NumMatricula = numMatricula;
        }

        public override string ToString()
        {

            return 
                "===============================\n" +
                $"Nome: {Nome}\n" +
                $"CPF: {Cpf}\n" +
                $"Data de Nascimento: {DataNascimento.ToShortDateString()}\n" +
                $"Curso: {Curso}\n" +
                $"Número de Matrícula: {NumMatricula}\n" +
                "===============================\n";
            

        }
    }
    }