using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    // A classe Aluno herda da classe Pessoa, representando um aluno no sistema acadêmico, contendo informações adicionais como número de matrícula
    public class Aluno : Pessoa
    {
        // Propriedade para o número de matrícula do aluno
        public int NumMatricula { get; set; }

        // Construtor para inicializar as propriedades do aluno
        public Aluno(string nome, string cpf, DateTime dataNascimento, int numMatricula)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            NumMatricula = numMatricula;
        }

        // Sobrescreve o método ToString para exibir as informações do aluno de forma formatada
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

