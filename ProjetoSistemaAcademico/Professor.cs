using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Professor : Pessoa
    {
        float Salario { get; set; }

        public Professor(string nome, long cpf, DateTime dataNascimento, float salario)
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
                $"Sálario: {Salario}\n" +
                "===============================\n";


        }
    }

}
