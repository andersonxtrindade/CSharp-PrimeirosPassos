using System;

namespace PrimeiroProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            aluno[] alunos = new aluno[5];
            string opcaoUsuario = ObterOpcaoUsuario();
            Console.WriteLine();
            int indiceAluno = 0;

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        indiceAluno = NovoAluno(alunos, indiceAluno);
                        break;
                    case "2":
                        ListarAlunos(alunos);
                        break;
                    case "3":
                        MediaGeral(alunos);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void MediaGeral(aluno[] alunos)
        {
            decimal notaTotal = 0;
            var nrAlunos = 0;
            for (int i = 0; i < alunos.Length; i++)
            {
                if (!string.IsNullOrEmpty(alunos[i].Nome))
                {
                    notaTotal = notaTotal + alunos[i].Nota;
                    nrAlunos++;
                }
            }

            var MediaGeral = notaTotal / nrAlunos;
            Conceito conceitoGeral;

            if (MediaGeral < 2)
            {
                conceitoGeral = Conceito.E;
            }
            else if (MediaGeral >= 2 | MediaGeral < 4)
            {
                conceitoGeral = Conceito.D;
            }
            else if (MediaGeral >= 4 | MediaGeral < 6)
            {
                conceitoGeral = Conceito.C;
            }
            else if (MediaGeral >= 6 | MediaGeral < 8)
            {
                conceitoGeral = Conceito.B;
            }
            else
            {
                conceitoGeral = Conceito.A;
            }

            Console.WriteLine($"A média geral é: {MediaGeral} e o conceito é {conceitoGeral}");
        }

        private static void ListarAlunos(aluno[] alunos)
        {
            int numAluno = 1;
            foreach (var a in alunos)
            {
                if (!string.IsNullOrEmpty(a.Nome))
                {
                    Console.WriteLine($"{numAluno}° Aluno, nome {a.Nome} e com nota {a.Nota}");
                    numAluno++;
                }
            }
            Console.WriteLine("");
        }

        private static int NovoAluno(aluno[] alunos, int indiceAluno)
        {
            Console.WriteLine("Informe o nome do aluno:");
            aluno aluno = new aluno();
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Informe a nota do aluno:");
            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {
                aluno.Nota = nota;
            }
            else
            {
                throw new ArgumentException("Valor da nota deve ser decimal!");

            }

            alunos[indiceAluno] = aluno;
            indiceAluno++;
            Console.WriteLine("");
            return indiceAluno;
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
