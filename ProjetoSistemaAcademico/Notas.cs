using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Notas : Aluno
    {
        float Matematica { get; set; }
        float Portugues { get; set; }
        float Ciencias { get; set; }
        float Historia { get; set; }
        float Geografia { get; set; }

        public Notas(
            string nome,
            string cpf,
            DateTime dataNascimento,
            string curso,
            int numMatricula,
            float matematica,
            float portugues,
            float ciencias,
            float historia,
            float geografia)
            : base(nome, cpf, dataNascimento, curso, numMatricula)
        {
            Matematica = matematica;
            Portugues = portugues;
            Ciencias = ciencias;
            Historia = historia;
            Geografia = geografia;
        }

        public override string ToString()
        {
            return
                "===============================\n" +
                $"Número de Matrícula: {NumMatricula}\n" +
                "===============================\n" +
                $"Nota de Matemática: {Matematica}\n" +
                $"Nota de Português: {Portugues}\n" +
                $"Nota de Ciências: {Ciencias}\n" +
                $"Nota de História: {Historia}\n" +
                $"Nota de Geografia: {Geografia}\n" +
                "===============================\n";
        }
    }
}
