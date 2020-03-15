﻿using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {

                    case "1":
                        //to do: Adicionar aluno
                        Console.WriteLine("1- Inserir novo aluno");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        
                        // var nota = decimal.Parse(Console.ReadLine()); // "var" pega um dado de qualquer tipo
                        
                        //ou: aluno.Nota = decimal.Parse(Console.ReadLine());

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            //tryParse retornará valor booleano dizendo se pode ou não converter a nota
                            //entretanto, espera saída out, podendo a variável ser declarada junto ali 'nota'
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        
                        break;

                    case "2":
                        //to do: Listar alunos
                        foreach(var a in alunos){
                            //if(!a.Nome.Equals(""))
                            if (a != null && string.IsNullOrEmpty(a.Nome)){
                            Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }

                        break;

                    case "3":
                        //to do: calcular média geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i<alunos.Length; i++){
                            
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Console.WriteLine($"MEDIA GERAL{mediaGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opcao desejada");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular media geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            //Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
