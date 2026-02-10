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
        public List<string> Disciplinas { get; set; }
        public string Senha { get; private set; }

        public Professor(string nome, string cpf, DateTime dataNascimento, float salario, string senha)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Salario = salario;
            Senha = senha;
            Disciplinas = new List<string>();
        }

        public void AdicionarDisciplina(string disciplina)
        {
            Disciplinas.Add(disciplina);
        }

        public override string ToString()
        {
            string listaDisciplinas = string.Join(", ", Disciplinas);

            return
                "===============================\n" +
                $"Nome: {Nome}\n" +
                $"CPF: {Cpf}\n" +
                $"Disciplinas: {listaDisciplinas}\n" +
                $"Salário: R$ {Salario.ToString("F2")}\n" +
                "===============================\n";
        }
    }
}

