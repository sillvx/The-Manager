using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using Spectre.Console;

namespace GerenciadordeSenhas
{
    class Program
    {
        public static void Main(string[] args)
        {
            string mestra;
            string senhaerrada;
            senhaerrada = "A Senha Está Incorreta! Tente novamente.";

            Console.WriteLine("Digite a Senha-Mestra");
            mestra = Console.ReadLine();

            Console.Clear();
            
            errado:
            string tentativa;
            Console.WriteLine("Digite a Senha-Mestra para continuar.");
            tentativa = Console.ReadLine();
            if (tentativa == mestra)
            {
                Console.Clear();
                Console.WriteLine("funcionou meno");
            }
            else if (tentativa != mestra)
            {
                Console.WriteLine(senhaerrada);
                goto errado;
            }

        iniciar:
            int menu;
            bool um;
            bool dois;
            bool tres;
            bool quatro;
            um = false;
            dois = false;
            tres = false;
            quatro = false;
            
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(@"================================
GERENCIADOR DE SENHAS 2000 V0.01
================================
");
            Console.WriteLine(@"Bem-vindo, este é o menu inicial. Selecione uma das opções abaixo:
 1 - Ver suas senhas
 2 - Gerenciar senhas
 3 - Mudar Senha-Mestra
 4 - Sair do Programa
            ");

            int.TryParse(Console.ReadLine(), out menu);

            switch (menu)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("PLACEHOLDER");
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("PLACEHOLDER");
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        tres = true;
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        goto iniciar;
                        break;
                    }
            }

            //pós menu:

            if (tres = true)
            {
                Console.Clear();
                Console.WriteLine(@"Essa é a senha atual: {0}
Digite a nova senha.", mestra); //mostra a Mestra original
                string novamestra;
                novamestra = Console.ReadLine(); //input para a nova mestra

                string rep1 = mestra.Replace($"{mestra}", novamestra);  //cria uma nova string substituindo o conteúdo de mestra por novamestra
                Console.WriteLine("{0}", rep1);                         //retorna o 'novo' conteúdo 
                //STATUS GERAL: "Works on my machine" 10/10!!!! //???????

            }


        }
    }
}

