using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace ProjetoSistemaAcademico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> Alunos = new List<Aluno>();
            List<Professor> Professores = new List<Professor>();
            List<Notas> notas = new List<Notas>();
            
            Pessoa a = null;
            int contadorNumMatricula = 1000;
            int i;
            for (i = 0; i < 100; i++)
            {
                Console.WriteLine("=================================================\n");
                Console.WriteLine("SEJA BEM VINDO A ESCOLA TÉCNICA SENAI CIMATEC!\n");
                Console.WriteLine("Selecione uma das opções abaixo:\n");
                Console.WriteLine("1 - Cadastrar Aluno\n");
                Console.WriteLine("2 - Cadastrar Professor\n");
                Console.WriteLine("3 - Consultar Aluno\n");
                Console.WriteLine("4 - Consultar Professor\n");
                Console.WriteLine("5 - Consultar Notas\n");
                Console.WriteLine("6 - Editar Notas\n");
                Console.WriteLine("7 - Sair\n");
                Console.WriteLine("=================================================\n");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:

                        Console.WriteLine("Cadastrar Aluno\n");


                        
                        string nomeA = "";

                        do {
                            Console.WriteLine("Digite o Nome do Aluno: ");
                            nomeA = Console.ReadLine();
                            if (nomeA.Length > 50)
                            {
                                Console.WriteLine("O nome do aluno deve conter no máximo 50 caracteres. Por favor, tente novamente.\n");
                            } else if (nomeA.Length < 4)
                            {

                                Console.WriteLine("O nome do aluno deve conter no minimo 4 caracteres. Por favor, tente novamente.\n");

                            } else if (Regex.IsMatch(nomeA, @"\d"))
                            {

                                Console.WriteLine("Números não são permitidos. Por favor, tente novamente.\n");

                            }
                        } while (nomeA.Length > 50 || nomeA.Length < 4 || Regex.IsMatch(nomeA, @"\d"));
                        

                            
                        string cpfA = "";

                        do
                        {
                            Console.WriteLine("Digite o CPF do Aluno: ");
                            cpfA = Console.ReadLine();
                            if (cpfA.Length > 11 || cpfA.Length < 11)
                                {
                                    Console.WriteLine("O CPF do aluno deve conter 11 Números. Por favor, tente novamente.\n");

                                }
                        } while (cpfA.Length > 11 || cpfA.Length < 11);





                            Console.WriteLine("Digite a Data de Nascimento do Aluno: (dd/mm/aa)");
                            DateTime datanascimentoA = DateTime.Parse(Console.ReadLine());




                        string cursoA = "";
                        do
                        {
                            Console.WriteLine("Digite o Nome do Curso: ");
                            cursoA = Console.ReadLine();
                            if (cursoA.Length > 50)
                            {
                                Console.WriteLine("O nome do curso deve conter no máximo 50 caracteres. Por favor, tente novamente.\n");
                            }
                            else if (cursoA.Length < 4)
                            {

                                Console.WriteLine("O nome do curso deve conter no minimo 4 caracteres. Por favor, tente novamente.\n");

                            }
                            else if (Regex.IsMatch(cursoA, @"\d"))
                            {

                                Console.WriteLine("Números não são permitidos. Por favor, tente novamente.\n");

                            }
                        } while (cursoA.Length > 50 || cursoA.Length < 4 || Regex.IsMatch(cursoA, @"\d"));
                        


                        int numMatriculaA = contadorNumMatricula++;


                            Aluno x = new Aluno(nomeA, cpfA, datanascimentoA, cursoA, numMatriculaA);
                            Alunos.Add(x);

                            Console.WriteLine("Aluno Cadastrado com Sucesso!\n");

                            break;
                    case 2:

                                Console.WriteLine("Cadastrar Professor\n");

                                Console.WriteLine("Digite o Nome do Professor: ");
                                string nomeP = Console.ReadLine();

                                Console.WriteLine("Digite o CPF do Professor: ");
                                string cpfP = Console.ReadLine();

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

                                if (Senha == "1234")
                                {
                                    Console.WriteLine("Acesso Permitido!\n");
                                    Console.WriteLine("Digite o Número de Matrícula do Aluno: ");

                                    string buscarAluno = Console.ReadLine();
                                    if (int.TryParse(buscarAluno, out int numMatriculaBusca))
                                    {
                                        Aluno alunoEncontrado = Alunos.FirstOrDefault(p => p.NumMatricula == numMatriculaBusca);
                                        Console.WriteLine("Aluno Encontrado");

                                        foreach (var prod in Alunos)
                                        {
                                            Console.WriteLine(prod.ToString());
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Número de matrícula inválido.");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta! Acesso Negado.\n");
                                }

                                break;
                            case 7:
                                i = 1000;
                                break;

                            default:

                                Console.WriteLine("Opção Inválida! Tente Novamente.\n");
                                break;


                            }
                        }
                        
            

        }
    }
}
