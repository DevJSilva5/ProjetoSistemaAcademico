using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaAcademico
{
    public class Notas
    {
        // Identificador para saber de qual aluno são essas notas
        public int NumMatricula { get; set; }

        // Propriedades precisam ser PUBLIC para serem acessadas no Program.cs
        public float Matematica { get; set; }
        public float Portugues { get; set; }
        public float Ciencias { get; set; }
        public float Historia { get; set; }
        public float Geografia { get; set; }

        public Notas(int numMatricula, float matematica, float portugues, float ciencias, float historia, float geografia)
        {
            NumMatricula = numMatricula;
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
                $"BOLETIM (Matrícula: {NumMatricula})\n" +
                "===============================\n" +
                $"Nota de Matemática: {Matematica}\n" +
                $"Nota de Português:  {Portugues}\n" +
                $"Nota de Ciências:   {Ciencias}\n" +
                $"Nota de História:   {Historia}\n" +
                $"Nota de Geografia:  {Geografia}\n" +
                "===============================\n";
        }
    }
}

