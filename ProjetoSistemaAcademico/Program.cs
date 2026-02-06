using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjetoSistemaAcademico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> Alunos = new List<Aluno>();
            List<Professor> Professores = new List<Professor>();
            List<Notas> ListaDeNotas = new List<Notas>();

            int contadorNumMatricula = 1000;
            bool executar = true;

            while (executar)
            {
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("SEJA BEM VINDO A ESCOLA TÉCNICA SENAI CIMATEC!");
                Console.WriteLine("=================================================");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Cadastrar Professor");
                Console.WriteLine("3 - Consultar Aluno");
                Console.WriteLine("4 - Consultar Professor");
                Console.WriteLine("5 - Consultar Notas");
                Console.WriteLine("6 - Editar/Lançar Notas (Área do Professor)");
                Console.WriteLine("7 - Sair");
                Console.WriteLine("=================================================");
                Console.Write("Escolha uma opção: ");

                int escolha;
                // Validação simples para não quebrar se digitar letra
                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Opção inválida. Pressione Enter.");
                    Console.ReadLine();
                    continue;
                }

                switch (escolha)
                {
                    case 1: // CADASTRAR ALUNO
                        Console.WriteLine("\n--- Cadastrar Aluno ---");

                        string nomeA = "";
                        do
                        {
                            Console.Write("Digite o Nome do Aluno: ");
                            nomeA = Console.ReadLine();
                            if (nomeA.Length > 50 || nomeA.Length < 4 || Regex.IsMatch(nomeA, @"\d"))
                            {
                                Console.WriteLine("Erro: Nome deve ter entre 4 e 50 caracteres e não conter números.");
                            }
                        } while (nomeA.Length > 50 || nomeA.Length < 4 || Regex.IsMatch(nomeA, @"\d"));

                        string cpfA = "";
                        do
                        {
                            Console.Write("Digite o CPF do Aluno (11 números): ");
                            cpfA = Console.ReadLine();
                            if (cpfA.Length != 11)
                                Console.WriteLine("Erro: O CPF deve conter exatamente 11 números.");
                        } while (cpfA.Length != 11);

                        Console.Write("Digite a Data de Nascimento (dd/mm/aaaa): ");
                        DateTime datanascimentoA;
                        while (!DateTime.TryParse(Console.ReadLine(), out datanascimentoA))
                        {
                            Console.Write("Data inválida. Tente novamente: ");
                        }

                        string cursoA = "";
                        do
                        {
                            Console.Write("Digite o Nome do Curso: ");
                            cursoA = Console.ReadLine();
                            if (cursoA.Length < 4 || Regex.IsMatch(cursoA, @"\d"))
                                Console.WriteLine("Nome do curso inválido (mínimo 4 letras, sem números).");
                        } while (cursoA.Length < 4 || Regex.IsMatch(cursoA, @"\d"));

                        int numMatriculaA = contadorNumMatricula++;
                        Aluno novoAluno = new Aluno(nomeA, cpfA, datanascimentoA, cursoA, numMatriculaA);
                        Alunos.Add(novoAluno);

                        Console.WriteLine($"\nAluno Cadastrado com Sucesso! Matrícula: {numMatriculaA}");
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 2: // CADASTRAR PROFESSOR
                        Console.WriteLine("\n--- Cadastrar Professor ---");

                        Console.Write("Digite o Nome do Professor: ");
                        string nomeP = Console.ReadLine();

                        Console.Write("Digite o CPF do Professor: ");
                        string cpfP = Console.ReadLine();

                        Console.Write("Digite a Data de Nascimento: ");
                        DateTime datanascimentoP;
                        while (!DateTime.TryParse(Console.ReadLine(), out datanascimentoP))
                        {
                            Console.Write("Data inválida. Tente novamente: ");
                        }

                        Console.Write("Digite o Salário do Professor: ");
                        float salarioP;
                        while (!float.TryParse(Console.ReadLine(), out salarioP))
                        {
                            Console.Write("Valor inválido. Digite o salário novamente: ");
                        }

                        Professor novoProf = new Professor(nomeP, cpfP, datanascimentoP, salarioP);
                        Professores.Add(novoProf);

                        Console.WriteLine("\nProfessor Cadastrado com Sucesso!");
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 3: // CONSULTAR ALUNOS
                        Console.WriteLine("\n--- Consultar Alunos ---");
                        if (Alunos.Count > 0)
                        {
                            foreach (var aluno in Alunos)
                            {
                                Console.WriteLine(aluno.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum aluno cadastrado.");
                        }
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 4: // CONSULTAR PROFESSORES
                        Console.WriteLine("\n--- Consultar Professores ---");
                        if (Professores.Count > 0)
                        {
                            foreach (var prof in Professores)
                            {
                                Console.WriteLine(prof.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum professor cadastrado.");
                        }
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 5: // CONSULTAR NOTAS
                        Console.WriteLine("\n--- Consultar Notas ---");
                        Console.Write("Digite o Número de Matrícula do Aluno: ");
                        if (int.TryParse(Console.ReadLine(), out int matConsulta))
                        {
                            var notasEncontradas = ListaDeNotas.FirstOrDefault(n => n.NumMatricula == matConsulta);
                            var alunoDono = Alunos.FirstOrDefault(a => a.NumMatricula == matConsulta);

                            if (notasEncontradas != null)
                            {
                                if (alunoDono != null) Console.WriteLine($"ALUNO: {alunoDono.Nome}");
                                Console.WriteLine(notasEncontradas.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma nota lançada para esta matrícula.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Matrícula inválida.");
                        }
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 6: // EDITAR NOTAS
                        Console.WriteLine("\n--- Editar Notas (Acesso Restrito) ---");
                        Console.Write("Digite a Senha (1234): ");
                        string senha = Console.ReadLine();

                        if (senha == "1234")
                        {
                            Console.WriteLine("Acesso Permitido!");
                            Console.Write("Digite o Número de Matrícula do Aluno: ");

                            if (int.TryParse(Console.ReadLine(), out int numMatriculaBusca))
                            {
                                Aluno alunoEncontrado = Alunos.FirstOrDefault(p => p.NumMatricula == numMatriculaBusca);

                                if (alunoEncontrado != null)
                                {
                                    Console.WriteLine($"\nAluno Encontrado: {alunoEncontrado.Nome}");
                                    Console.WriteLine("Insira as notas:");

                                    Console.Write("Matemática: ");
                                    float.TryParse(Console.ReadLine(), out float nMat);
                                    Console.Write("Português: ");
                                    float.TryParse(Console.ReadLine(), out float nPort);
                                    Console.Write("Ciências: ");
                                    float.TryParse(Console.ReadLine(), out float nCien);
                                    Console.Write("História: ");
                                    float.TryParse(Console.ReadLine(), out float nHist);
                                    Console.Write("Geografia: ");
                                    float.TryParse(Console.ReadLine(), out float nGeo);

                                    // Verifica se já existe nota para atualizar ou cria nova
                                    var notaExistente = ListaDeNotas.FirstOrDefault(n => n.NumMatricula == numMatriculaBusca);
                                    if (notaExistente != null)
                                    {
                                        notaExistente.Matematica = nMat;
                                        notaExistente.Portugues = nPort;
                                        notaExistente.Ciencias = nCien;
                                        notaExistente.Historia = nHist;
                                        notaExistente.Geografia = nGeo;
                                        Console.WriteLine("Notas atualizadas com sucesso!");
                                    }
                                    else
                                    {
                                        Notas novaNota = new Notas(numMatriculaBusca, nMat, nPort, nCien, nHist, nGeo);
                                        ListaDeNotas.Add(novaNota);
                                        Console.WriteLine("Notas lançadas com sucesso!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não encontrado com esta matrícula.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Número de matrícula inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Senha Incorreta! Acesso Negado.");
                        }
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 7:
                        executar = false;
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção Inválida! Tente Novamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}

