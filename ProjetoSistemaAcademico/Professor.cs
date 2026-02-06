using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Professor : Pessoa
    {
        public float Salario { get; set; }

        public Professor(string nome, string cpf, DateTime dataNascimento, float salario)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Salario = salario;
        }

        public override string ToString()
        {
            return
                "===============================\n" +
                $"Nome: {Nome}\n" +
                $"CPF: {Cpf}\n" +
                $"Data de Nascimento: {DataNascimento.ToShortDateString()}\n" +
                $"Salário: R$ {Salario.ToString("F2")}\n" + // Formatado para moeda
                "===============================\n";
        }
    }
}

