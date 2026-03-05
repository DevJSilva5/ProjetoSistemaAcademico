using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    // A classe Professor herda de Pessoa e implementa IAutenticavel para permitir login
    public class Professor : Pessoa, IAutenticavel
    {
        // Propriedade para o salário do professor
        public float Salario { get; set; }
        // Lista de disciplinas que o professor leciona
        public List<string> Disciplinas { get; set; }
        // Propriedade para a senha do professor
        public string Senha { get; private set; }

        // Construtor para inicializar as propriedades do professor
        public Professor(string nome, string cpf, DateTime dataNascimento, float salario, string senha)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Salario = salario;
            Senha = senha;
            Disciplinas = new List<string>();
        }

        // Implementação do método da interface IAutenticavel
        public bool Autenticar(string senhaDigitada)
        {
            return this.Senha == senhaDigitada;
        }

        // Método para adicionar uma disciplina à lista de disciplinas do professor
        public void AdicionarDisciplina(string disciplina)
        {
            Disciplinas.Add(disciplina);
        }

        // Sobrescreve o método ToString para exibir as informações do professor de forma formatada
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

