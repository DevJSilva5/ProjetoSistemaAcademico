using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjetoSistemaAcademico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> Alunos = new List<Aluno>();
            List<Professor> Professores = new List<Professor>();
            List<float> Notas = new List<float>();
            int i;
            Pessoa a = null;

            for (i = 0; i < 100; i++)
            {
                Console.WriteLine("=================================================\n");
                Console.WriteLine("SEJA BEM VINDO A ESCOLA TÉCNICA SENAI CIMATEC!\n");
                Console.WriteLine("Selecione uma das opções abaixo:\n");
                Console.WriteLine("1 - Cadastrar Aluno\n");
                Console.WriteLine("2 - Cadastrar Professor\n");
                Console.WriteLine("3 - Consultar Aluno\n");
                Console.WriteLine("4 - Consultar Professor\n");
                Console.WriteLine("5 - Consultar Notas");
                Console.WriteLine("6 - Editar  Notas\n");
                Console.WriteLine("=================================================\n");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:

                        Console.WriteLine("Cadastrar Aluno\n");

                

                        Console.WriteLine("Digite o Nome do Aluno: ");
                        string nomeA = Console.ReadLine();

                        Console.WriteLine("Digite o CPF do Aluno: ");
                        long cpfA  = long.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a Data de Nascimento do Aluno: ");
                        DateTime datanascimentoA = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o Curso do Aluno: ");
                        string cursoA = Console.ReadLine();

                        Console.WriteLine("Digite o Número de Matrícula do Aluno: ");
                        int numMatriculaA = int.Parse(Console.ReadLine());


                        Aluno p = new Aluno(nomeA, cpfA, datanascimentoA, cursoA, numMatriculaA);
                        Alunos.Add(p);

                        Console.WriteLine("Aluno Cadastrado com Sucesso!\n");

                        break;
                    case 2:

                        Console.WriteLine("Cadastrar Professor\n");

                        Console.WriteLine("Digite o Nome do Professor: ");
                        string nomeP = Console.ReadLine();

                        Console.WriteLine("Digite o CPF do Professor: ");
                        long cpfP = long.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a Data de Nascimento do Professor: ");
                        DateTime datanascimentoP = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o Salário do Professor: ");
                        float salarioP = float.Parse(Console.ReadLine());

                        Professor c = new Professor(nomeP, cpfP, datanascimentoP, salarioP);
                        Professores.Add(c);



                        break;
                    case 3:
                        Console.WriteLine("Consultar Aluno\n");
                        if (Alunos.Count > 0)
                        {
                            foreach (var prod in Alunos)
                            {
                                Console.WriteLine(prod.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum aluno cadastrado.\n");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Consultar Professor\n");
                        if (Alunos.Count > 0)
                        {
                            foreach (var prod in Professores)
                            {
                                Console.WriteLine(prod.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum Professor cadastrado.\n");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Consultar Notas\n");
                        Console.WriteLine("Digite o Número de Matrícula do Aluno: ");
                        Console.ReadLine();


                        break;
                    case 6:
                        Console.WriteLine("Editar Notas\n\nAcesso Exclusivo Para Professores\n\n Digite a Senha:     (senha: 1234)\n ");
                        string Senha = Console.ReadLine();

                        if(Senha == "1234")
                        {
                            Console.WriteLine("Acesso Permitido!\n");

                        }
                        else
                        {
                            Console.WriteLine("Senha Incorreta! Acesso Negado.\n");
                        }

                            break;


                }
            }

        }
    }
}
