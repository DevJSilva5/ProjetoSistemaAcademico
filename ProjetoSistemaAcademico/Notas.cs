using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    // A classe Notas representa as notas de um aluno, associadas a um número de matrícula e um boletim contendo as matérias e suas respectivas notas
    public class Notas
    {
        // Propriedade para o número de matrícula do aluno
        public int NumMatricula { get; set; }
        // Dicionário para armazenar as matérias e suas respectivas notas
        public Dictionary<string, float> Boletim { get; set; }


        // Construtor para inicializar o número de matrícula e o boletim
        public Notas(int numMatricula)
        {
            NumMatricula = numMatricula;
            Boletim = new Dictionary<string, float>();
        }

        // Método para lançar ou atualizar a nota de uma matéria no boletim
        public void LancarNota(string materia, float nota)
        {
            // Verifica se a matéria já existe no boletim, se sim, atualiza a nota, caso contrário, adiciona a nova matéria e nota
            if (Boletim.ContainsKey(materia))
            {
                Boletim[materia] = nota;
            }
            else
            {
                Boletim.Add(materia, nota);
            }
        }

        // Método para calcular a média geral das notas no boletim
        public float CalcularMediaGeral()
        {
            // Verifica se o boletim está vazio, se sim, retorna 0 para evitar divisão por zero, caso contrário, calcula a média das notas
            if (Boletim.Count == 0) return 0;
            return Boletim.Values.Average();
        }

        // Sobrescreve o método ToString para exibir o boletim do aluno de forma formatada, incluindo as matérias, notas, média geral e situação (aprovado ou em recuperação)
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===============================");
            sb.AppendLine($"BOLETIM (Matrícula: {NumMatricula})");
            sb.AppendLine("===============================");

            // Verifica se o boletim contém matérias e notas, se sim, exibe cada matéria e sua respectiva nota, caso contrário, exibe uma mensagem indicando que nenhuma nota foi lançada
            if (Boletim.Count > 0)
            {
                foreach (var item in Boletim)
                {
                    sb.AppendLine($"Matéria: {item.Key} | Nota: {item.Value:F1}");
                }
                sb.AppendLine("-------------------------------");
                sb.AppendLine($"MÉDIA GERAL: {CalcularMediaGeral():F1}");

                if (CalcularMediaGeral() >= 7) sb.AppendLine("Situação: APROVADO");
                else sb.AppendLine("Situação: EM RECUPERAÇÃO");
            }
            else
            {
                sb.AppendLine("Nenhuma nota lançada ainda.");
            }

            sb.AppendLine("===============================\n");
            return sb.ToString();
        }
    }
}

