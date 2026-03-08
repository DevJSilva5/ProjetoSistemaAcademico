using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ProjetoSistemaAcademico
{
    //By: João Pedro Silva de Almeida - DevJSilva5
    internal class Program
    {
        static void Main(string[] args)
        {
            // Listas para armazenar alunos, professores e notas
            List<Aluno> Alunos = new List<Aluno>();
            List<Professor> Professores = new List<Professor>();
            List<Notas> ListaDeNotas = new List<Notas>();

            
            // Contador para gerar números de matrícula únicos
            int contadorNumMatricula = 1000;
            // Variável para controlar a execução do menu
            bool executar = true;

            // Loop principal do menu
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
                Console.WriteLine("7 - Remover Aluno");
                Console.WriteLine("8 - Remover Professor");
                Console.WriteLine("9 - Sair");
                Console.WriteLine("=================================================");
                Console.Write("Escolha uma opção: ");

                // Captura a escolha do usuário e utiliza um bloco try-catch para tratar possíveis erros de entrada, como digitar texto em vez de números
                try
                {
                    int escolha = Convert.ToInt32(Console.ReadLine());

                    // Estrutura de controle para as opções do menu
                    switch (escolha)
                    {
                        // Opção 1: Cadastrar Aluno
                        case 1:
                            Console.WriteLine("\n--- Cadastrar Aluno ---");

                            // Validação do nome do aluno: deve ter entre 4 e 50 caracteres e não conter números
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

                            // Validação do CPF: deve conter exatamente 11 números
                            string cpfA = "";
                            do
                            {
                                Console.Write("Digite o CPF do Aluno (11 números): ");
                                cpfA = Console.ReadLine();
                                if (cpfA.Length != 11)
                                    Console.WriteLine("Erro: O CPF deve conter exatamente 11 números.");
                            } while (cpfA.Length != 11);

                            // Validação da data de nascimento: deve ser uma data válida
                            Console.Write("Digite a Data de Nascimento (dd/mm/aaaa): ");
                            DateTime datanascimentoA;
                            while (!DateTime.TryParse(Console.ReadLine(), out datanascimentoA))
                            {
                                Console.Write("Data inválida. Tente novamente: ");
                            }

                            // Gerar número de matrícula único para o aluno
                            int numMatriculaA = contadorNumMatricula++;

                            // Criar um novo objeto Aluno e adicioná-lo à lista de alunos
                            Aluno novoAluno = new Aluno(nomeA, cpfA, datanascimentoA, numMatriculaA);
                            Alunos.Add(novoAluno);

                            Console.WriteLine($"\nAluno Cadastrado com Sucesso! Matrícula: {numMatriculaA}");
                            Console.WriteLine("Pressione Enter para voltar.");
                            Console.ReadLine();
                            break;

                        // Opção 2: Cadastrar Professor
                        case 2:
                            Console.WriteLine("\n--- Cadastrar Professor ---");

                            // Validação do nome do professor: deve ter entre 4 e 50 caracteres e não conter números
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

                            // Validação do CPF: deve conter exatamente 11 números
                            string cpfP = "";
                            do
                            {
                                Console.Write("Digite o CPF do Professor (11 números): ");
                                cpfP = Console.ReadLine();
                                if (cpfP.Length != 11)
                                    Console.WriteLine("Erro: O CPF deve conter exatamente 11 números.");
                            } while (cpfP.Length != 11);

                            // Validação da data de nascimento: deve ser uma data válida
                            Console.Write("Digite a Data de Nascimento (dd/mm/aaaa): ");
                            DateTime datanascimentoP;
                            while (!DateTime.TryParse(Console.ReadLine(), out datanascimentoP))
                            {
                                Console.Write("Data inválida. Tente novamente: ");
                            }

                            // Validação do salário: deve ser um número válido
                            Console.Write("Salário: ");
                            float salarioP;
                            while (!float.TryParse(Console.ReadLine(), out salarioP))
                            {
                                Console.Write("Valor inválido. Digite o salário novamente: ");
                            }

                            // Validação da senha: não pode ser vazia
                            string senhaP = "";
                            do
                            {
                                Console.Write("Crie uma Senha de Acesso: ");
                                senhaP = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(senhaP)) Console.WriteLine("A senha não pode ser vazia.");
                            } while (string.IsNullOrWhiteSpace(senhaP));

                            // Criar um novo objeto Professor e adicioná-lo à lista de professores
                            Professor novoProf = new Professor(nomeP, cpfP, datanascimentoP, salarioP, senhaP);

                            // Permitir que o professor adicione as disciplinas que leciona
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

                                // Perguntar se o usuário deseja adicionar mais matérias
                                Console.Write("Deseja inserir outra matéria? (S/N): ");
                                string resp = Console.ReadLine().ToUpper();
                                if (resp != "S") adicionarMais = false;
                            }

                            // Adicionar o professor à lista de professores
                            Professores.Add(novoProf);
                            Console.WriteLine("\nProfessor Cadastrado com Sucesso!");
                            Console.WriteLine("Pressione Enter para voltar.");
                            Console.ReadLine();
                            break;

                        // Opção 3: Consultar Alunos
                        case 3:
                            Console.WriteLine("\n--- Consultar Alunos ---");

                            // Verificar se há alunos cadastrados e exibi-los, ou mostrar mensagem caso contrário
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

                        // Opção 4: Consultar Professores
                        case 4:
                            Console.WriteLine("\n--- Consultar Professores ---");

                            // Verificar se há professores cadastrados e exibi-los, ou mostrar mensagem caso contrário
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

                        // Opção 5: Consultar Notas
                        case 5:
                            Console.WriteLine("\n--- Consultar Notas ---");
                            try
                            {
                                // Solicitar ao usuário o número de matrícula
                                Console.Write("Digite o Número de Matrícula do Aluno: ");
                                if (!int.TryParse(Console.ReadLine(), out int matConsulta))
                                    throw new Exception("Matrícula inválida.");

                                // Buscar as notas do aluno específico
                                var notasEncontradas = ListaDeNotas.FirstOrDefault(n => n.NumMatricula == matConsulta);
                                var alunoDono = Alunos.FirstOrDefault(a => a.NumMatricula == matConsulta);

                                if (notasEncontradas == null)
                                    throw new Exception("Nenhuma nota lançada para esta matrícula.");

                                // Exibe os dados do aluno e seu boletim individual
                                if (alunoDono != null) Console.WriteLine($"ALUNO: {alunoDono.Nome}");
                                Console.WriteLine(notasEncontradas.ToString());

                                
                                // SelectMany "achata" todos os dicionários de notas em uma única sequência de valores
                                var todasAsNotasDaEscola = ListaDeNotas.SelectMany(n => n.Boletim.Values);

                                if (todasAsNotasDaEscola.Any())
                                {
                                    double mediaEscola = todasAsNotasDaEscola.Average();
                                    Console.WriteLine("-------------------------------");
                                    Console.WriteLine($"MÉDIA GERAL DA ESCOLA: {mediaEscola:F1}");
                                    Console.WriteLine("-------------------------------");
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }

                            Console.WriteLine("Pressione Enter para voltar.");
                            Console.ReadLine();
                            break;

                        // Opção 6: Lançar Notas (Área do Professor)
                        case 6:
                            Console.WriteLine("\n--- Área do Professor ---");

                            // Solicitar ao professor que faça login digitando seu nome e senha, e validar as credenciais para permitir o acesso
                            Console.Write("Digite seu Nome (como cadastrado): ");
                            string nomeLogin = Console.ReadLine();

                            // Buscar o professor na lista de professores com base no nome digitado, ignorando diferenças de maiúsculas/minúsculas
                            Professor profLogado = Professores.FirstOrDefault(p => p.Nome.Equals(nomeLogin, StringComparison.OrdinalIgnoreCase));

                            // Se o professor não for encontrado, exibir mensagem de erro e retornar ao menu
                            if (profLogado == null)
                            {
                                Console.WriteLine("Professor não encontrado!");
                                Console.ReadLine();
                                break;
                            }

                            // Solicitar a senha do professor e validar, permitindo o acesso apenas se a senha estiver correta
                            Console.Write($"Olá, {profLogado.Nome}. Digite sua senha: ");
                            string senhaDigitada = Console.ReadLine();

                            // Chamada da interface para validar o acesso
                            if (!profLogado.Autenticar(senhaDigitada))
                            {
                                Console.WriteLine("Senha Incorreta! Acesso Negado.");
                                Console.ReadLine();
                                break;
                            }

                            // Se o login for bem-sucedido, exibir as matérias que o professor leciona e permitir que ele lance notas para os alunos
                            Console.WriteLine("\n--- Acesso Permitido ---");
                            Console.WriteLine($"Suas matérias: {string.Join(", ", profLogado.Disciplinas)}");

                            // Solicitar ao professor o número de matrícula do aluno para o qual deseja lançar notas, e validar a matrícula
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

                                // Buscar o boletim do aluno com base na matrícula, ou criar um novo boletim se ainda não existir
                                Notas boletimAluno = ListaDeNotas.FirstOrDefault(n => n.NumMatricula == matBusca);
                                if (boletimAluno == null)
                                {
                                    boletimAluno = new Notas(matBusca);
                                    ListaDeNotas.Add(boletimAluno);
                                }

                                foreach (string materia in profLogado.Disciplinas)
                                {
                                    //Solicitar ao professor a nota para cada matéria que ele leciona, e validar o valor da nota antes de lançá-la no boletim do aluno
                                    Console.Write($"Nota para {materia} (Pressione ENTER para pular ou digite a nota): ");
                                    string inputNota = Console.ReadLine();

                                    // Permitir que o professor pule o lançamento de nota para uma matéria específica, caso deseje
                                    if (!string.IsNullOrWhiteSpace(inputNota))
                                    {
                                        // Substituir ponto por vírgula para permitir a entrada de notas com decimais, e tentar converter para float
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

                        // Opção 7: Remover Aluno
                        case 7:
                            Console.WriteLine("\n--- Remover Aluno ---");

                            // Solicitar ao usuário o número de matrícula do aluno a ser removido, e validar a matrícula
                            Console.Write("Digite o Número de Matrícula do Aluno a ser removido: ");
                            if (int.TryParse(Console.ReadLine(), out int matRemover))
                            {
                                // Buscar o aluno na lista de alunos com base na matrícula e removê-lo, e também remover as notas associadas a esse aluno, se existirem
                                Aluno alunoRemover = Alunos.FirstOrDefault(a => a.NumMatricula == matRemover);
                                if (alunoRemover != null)
                                {
                                    Alunos.Remove(alunoRemover);

                                    Notas notasRemover = ListaDeNotas.FirstOrDefault(n => n.NumMatricula == matRemover);
                                    if (notasRemover != null)
                                    {
                                        ListaDeNotas.Remove(notasRemover);
                                    }

                                    Console.WriteLine("Aluno removido com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Matrícula inválida.");
                            }
                            Console.WriteLine("Pressione Enter para voltar.");
                            Console.ReadLine();
                            break;

                        //Opção 8: Remover Professor
                        case 8:
                            Console.WriteLine("\n--- Remover Professor ---");

                            // Solicitar ao usuário o CPF do professor a ser removido, e validar o CPF
                            Console.Write("Digite o CPF do Professor a ser removido (11 números): ");
                            string cpfRemover = Console.ReadLine();

                            // Buscar o professor na lista de professores com base no CPF e removê-lo, ou mostrar mensagem caso o professor não seja encontrado
                            Professor profRemover = Professores.FirstOrDefault(p => p.Cpf == cpfRemover);
                            if (profRemover != null)
                            {
                                Professores.Remove(profRemover);
                                Console.WriteLine("Professor removido com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Professor não encontrado.");
                            }
                            Console.WriteLine("Pressione Enter para voltar.");
                            Console.ReadLine();
                            break;

                        // Opção 9: Sair do sistema
                        case 9:

                            // Definir a variável de controle para false para encerrar o loop do menu e exibir mensagem de encerramento
                            executar = false;
                            Console.WriteLine("Encerrando o sistema...");
                            break;

                        // Opção padrão: caso o usuário digite uma opção inválida, exibir mensagem de erro e retornar ao menu
                        default:
                            Console.WriteLine("Opção Inválida! Tente Novamente.");
                            Console.ReadLine();
                            break;
                    }
                    }
                    catch (FormatException)
                    {
                        // Captura erro se o usuário digitar texto ou caractere especial
                        Console.WriteLine("Erro: Você não digitou um número válido.");
                    }
                    catch (Exception ex)
                    {
                        // Captura qualquer outro erro inesperado
                        Console.WriteLine($"Erro inesperado: {ex.Message}");
                    }

                }
            }
        }
    }

