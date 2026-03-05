using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    // A classe Pessoa representa uma pessoa genérica no sistema acadêmico, contendo informações básicas como nome, CPF e data de nascimento
    public class Pessoa
    {
        // Propriedade para o nome da pessoa
        public string Nome { get; set; }
        // Propriedade para o CPF da pessoa
        public string Cpf { get; set; }
        // Propriedade para a data de nascimento da pessoa
        public DateTime DataNascimento { get; set; }
    }
}

