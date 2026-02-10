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
                Console.WriteLine("      ESCOLA TÉCNICA SENAI CIMATEC");
                Console.WriteLine("=================================================");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Cadastrar Professor");
                Console.WriteLine("3 - Consultar Aluno");
                Console.WriteLine("4 - Consultar Professor");
                Console.WriteLine("5 - Consultar Notas");
                Console.WriteLine("6 - Lançar Notas (Área do Professor)");
                Console.WriteLine("7 - Sair");
                Console.WriteLine("=================================================");
                Console.Write("Escolha uma opção: ");

                int escolha;
                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Opção inválida.");
                    Console.ReadLine();
                    continue;
                }

                switch (escolha)
                {
                    case 1:
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

                    case 2:
                        Console.WriteLine("\n--- Cadastrar Professor ---");

                        string nomeP = "";
                        do
                        {
                            Console.Write("Digite o Nome do Professor: ");
                            nomeP = Console.ReadLine();
                            if (nomeP.Length > 50 || nomeP.Length < 4 || Regex.IsMatch(nomeP, @"\d"))
                            {
                                Console.WriteLine("Erro: Nome deve ter entre 4 e 50 caracteres e não conter números.");
                            }
                        } while (nomeP.Length > 50 || nomeP.Length < 4 || Regex.IsMatch(nomeP, @"\d"));

                        string cpfP = "";
                        do
                        {
                            Console.Write("Digite o CPF do Professor (11 números): ");
                            cpfP = Console.ReadLine();
                            if (cpfP.Length != 11)
                                Console.WriteLine("Erro: O CPF deve conter exatamente 11 números.");
                        } while (cpfP.Length != 11);

                        Console.Write("Digite a Data de Nascimento (dd/mm/aa): ");
                        DateTime datanascimentoP;
                        while (!DateTime.TryParse(Console.ReadLine(), out datanascimentoP))
                        {
                            Console.Write("Data inválida. Tente novamente: ");
                        }

                        Console.Write("Salário: ");
                        float salarioP;
                        while (!float.TryParse(Console.ReadLine(), out salarioP))
                        {
                            Console.Write("Valor inválido. Digite o salário novamente: ");
                        }

                        string senhaP = "";
                        do
                        {
                            Console.Write("Crie uma Senha de Acesso: ");
                            senhaP = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(senhaP)) Console.WriteLine("A senha não pode ser vazia.");
                        } while (string.IsNullOrWhiteSpace(senhaP));

                        Professor novoProf = new Professor(nomeP, cpfP, datanascimentoP, salarioP, senhaP);

                        bool adicionarMais = true;
                        while (adicionarMais)
                        {
                            Console.Write("\nDigite o nome da matéria que este professor leciona: ");
                            string materia = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(materia))
                            {
                                novoProf.AdicionarDisciplina(materia);
                                Console.WriteLine($"Matéria '{materia}' adicionada.");
                            }

                            Console.Write("Deseja inserir outra matéria? (S/N): ");
                            string resp = Console.ReadLine().ToUpper();
                            if (resp != "S") adicionarMais = false;
                        }

                        Professores.Add(novoProf);
                        Console.WriteLine("\nProfessor Cadastrado com Sucesso!");
                        Console.WriteLine("Pressione Enter para voltar.");
                        Console.ReadLine();
                        break;

                    case 3:
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

                    case 4:
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

                    case 5:
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

                    case 6:
                        Console.WriteLine("\n--- Área do Professor ---");

                        Console.Write("Digite seu Nome (como cadastrado): ");
                        string nomeLogin = Console.ReadLine();

                        Professor profLogado = Professores.FirstOrDefault(p => p.Nome.Equals(nomeLogin, StringComparison.OrdinalIgnoreCase));

                        if (profLogado == null)
                        {
                            Console.WriteLine("Professor não encontrado!");
                            Console.ReadLine();
                            break;
                        }

                        Console.Write($"Olá, {profLogado.Nome}. Digite sua senha: ");
                        string senhaDigitada = Console.ReadLine();

                        if (senhaDigitada != profLogado.Senha)
                        {
                            Console.WriteLine("Senha Incorreta! Acesso Negado.");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\n--- Acesso Permitido ---");
                        Console.WriteLine($"Suas matérias: {string.Join(", ", profLogado.Disciplinas)}");

                        Console.Write("\nDigite a Matrícula do Aluno para dar nota: ");
                        if (int.TryParse(Console.ReadLine(), out int matBusca))
                        {
                            Aluno alunoAlvo = Alunos.FirstOrDefault(a => a.NumMatricula == matBusca);
                            if (alunoAlvo == null)
                            {
                                Console.WriteLine("Aluno não encontrado.");
                                Console.ReadLine();
                                break;
                            }

                            Console.WriteLine($"Aluno: {alunoAlvo.Nome}");

                            Notas boletimAluno = ListaDeNotas.FirstOrDefault(n => n.NumMatricula == matBusca);
                            if (boletimAluno == null)
                            {
                                boletimAluno = new Notas(matBusca);
                                ListaDeNotas.Add(boletimAluno);
                            }

                            foreach (string materia in profLogado.Disciplinas)
                            {
                                Console.Write($"Nota para {materia} (Pressione ENTER para pular ou digite a nota): ");
                                string inputNota = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(inputNota))
                                {
                                    if (float.TryParse(inputNota.Replace(".", ","), out float valorNota))
                                    {
                                        boletimAluno.LancarNota(materia, valorNota);
                                        Console.WriteLine($"Nota de {materia} salva.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor inválido.");
                                    }
                                }
                            }
                            Console.WriteLine("\nProcesso finalizado.");
                        }
                        else
                        {
                            Console.WriteLine("Matrícula inválida.");
                        }
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

