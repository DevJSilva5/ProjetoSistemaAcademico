using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPteste
{
    internal class Pessoa
    {
        public List<string> Alunos { get; set; } = new List<string>();
        public string nome;
        public long cpf;
        public string dataNascimento;

        public Pessoa()
        {
            
            dataNascimento = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
