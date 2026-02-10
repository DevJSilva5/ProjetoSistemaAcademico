using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Notas
    {
        public int NumMatricula { get; set; }
        public Dictionary<string, float> Boletim { get; set; }

        public Notas(int numMatricula)
        {
            NumMatricula = numMatricula;
            Boletim = new Dictionary<string, float>();
        }

        public void LancarNota(string materia, float nota)
        {
            if (Boletim.ContainsKey(materia))
            {
                Boletim[materia] = nota;
            }
            else
            {
                Boletim.Add(materia, nota);
            }
        }

        public float CalcularMediaGeral()
        {
            if (Boletim.Count == 0) return 0;
            return Boletim.Values.Average();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===============================");
            sb.AppendLine($"BOLETIM (Matrícula: {NumMatricula})");
            sb.AppendLine("===============================");

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

