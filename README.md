Este é um guia prático para o seu Sistema de Gerenciamento Acadêmico, desenvolvido em C#. O projeto utiliza conceitos fundamentais de Orientação a Objetos (POO), como herança, interfaces e encapsulamento, para organizar a rotina de uma instituição de ensino.

🎓 Sistema Acadêmico - SENAI CIMATEC
Este sistema via console permite o cadastro e gerenciamento de alunos, professores e o lançamento de notas, com um sistema de autenticação simples para garantir que apenas docentes lancem informações acadêmicas.

✨ Funcionalidades
 * Gestão de Alunos: Cadastro com validação de nome, CPF e data de nascimento.
 * Gestão de Professores: Cadastro de docentes com definição de salário, disciplinas lecionadas e senha de acesso.
 * Boletim Digital: Registro de notas por disciplina e cálculo automático de média.
 * Autenticação: Área restrita para professores através de interface de autenticação.
 * Cálculo de Desempenho: Exibição da média geral do aluno e da média geral da escola.
   
🏗️ Estrutura do Projeto
O projeto está organizado seguindo princípios de POO para facilitar a manutenção e escalabilidade:
 * Pessoa.cs: Classe base (mãe) contendo atributos comuns (Nome, CPF, Data de Nascimento).
 * Aluno.cs: Herda de Pessoa e adiciona o número de matrícula.
 * Professor.cs: Herda de Pessoa, implementa a interface de autenticação e gerencia disciplinas.
 * Notas.cs: Gerencia o dicionário de notas e o cálculo de médias.
 * IAutenticavel.cs: Interface que define o contrato de segurança para o login.
 * Program.cs: O motor do sistema, contendo o menu principal e as validações de entrada.

🚀 Como Executar
Pré-requisitos
 * .NET SDK instalado (versão 6.0 ou superior recomendada).
 * Um terminal ou IDE (VS Code, Visual Studio, JetBrains Rider).
Passo a passo
 * Navegue até a pasta raiz do projeto via terminal.
 * Compile o projeto:
   dotnet build

 * Execute a aplicação:
   dotnet run

📖 Como Utilizar
Ao iniciar, você verá um menu numerado. Aqui estão os fluxos principais:

1. Fluxo de Cadastro
 * Alunos (Opção 1): O sistema gera automaticamente um número de matrícula único a partir de 1000.
 * Professores (Opção 2): Ao cadastrar um professor, você deve definir as disciplinas que ele domina. Isso é crucial para o lançamento de notas posterior.
2. Lançamento de Notas (Área do Professor)
 * Selecione a Opção 6.
 * Digite o Nome e a Senha do professor cadastrado.
 * Informe a Matrícula do aluno alvo.
 * O sistema listará apenas as matérias que aquele professor leciona. Insira as notas (use vírgula para decimais).
3. Consulta de Boletim
 * Na Opção 5, ao digitar a matrícula, o sistema exibe o boletim completo com a média e o status:
   * Aprovado: Média >= 7,0.
   * Em Recuperação: Média < 7,0.

🛠️ Validações Implementadas
 * Nomes: Não aceitam números e devem ter entre 4 e 50 caracteres.
 * CPF: Deve possuir exatamente 11 dígitos.
 * Segurança: Bloqueio de acesso caso a senha ou o nome do professor estejam incorretos.
 * Erros de Entrada: Tratamento de try-catch para evitar que o sistema feche ao digitar letras em campos numéricos.
