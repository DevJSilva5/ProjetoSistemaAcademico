using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace APPteste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            Pessoa a = null;

            for (i = 0; i < 100; i++)
            {

                Console.WriteLine("SEJA BEM VINDO A ESCOLA TÉCNICA SENAI CIMATEC!\n");
                Console.WriteLine("Selecione uma das opções abaixo:\n");
                Console.WriteLine("1 - Cadastrar Aluno\n");
                Console.WriteLine("2 - Cadastrar Professor\n");
                Console.WriteLine("3 - Consultar Aluno\n");
                Console.WriteLine("4 - Consultar Professor\n");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:

                        Console.WriteLine("Cadastrar Aluno\n");

                        a = new Pessoa();

                        Console.WriteLine("Digite o Nome do Aluno: ");
                        a.nome = Console.ReadLine();
                        Alunos.Add(a.nome);
                        Console.WriteLine("Digite o CPF do Aluno: ");
                        a.cpf = long.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a Data de Nascimento do Aluno: ");
                        a.dataNascimento = Console.ReadLine();
                        Console.WriteLine("Aluno Cadastrado com Sucesso!\n");

                        break;
                    case 3:
                        Console.WriteLine("Consultar Aluno\n");
                        if (a != null)
                        {
                            Console.WriteLine("Nome do Aluno: " + a.nome);
                            Console.WriteLine("CPF do Aluno: " + a.cpf);
                            Console.WriteLine("Data de Nascimento do Aluno: " + a.dataNascimento + "\n");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum aluno cadastrado.\n");
                        }
                        break;

                }
            }

        }
    }
}
