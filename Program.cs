using System;
using Spectre.Console;

namespace Gerenciador_de_Senhas

{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            AnsiConsole.MarkupLine("[blue]Defina sua senha mestra[/]");
            string mestra = Console.ReadLine();
            Console.Clear();

        tentativadesenha:
            AnsiConsole.MarkupLine("[blue]Digite sua senha mestra[/]");
            string tentativa = Console.ReadLine();


            if (tentativa == mestra)
            {
                Console.WriteLine("funcionou");
                goto iniciar;

            }
            else
            {
                Console.WriteLine("errou");
                goto tentativadesenha;
            }

            iniciar: //a partir daqui, o meu iniciar e suas opções...
            Console.Clear();
            var mode = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(@"================================
GERENCIADOR DE SENHAS 2000 V0.01
================================")
                    .AddChoices(new[]
                        {
                         "Ver as suas senhas", "Gerenciar senhas",
                         "Mudar Senha-Mestra",  "Sair do Programa"
                        }));

            if (mode == "Ver as suas senhas")
            {
                Console.WriteLine("aaaaa funcionou");
            }
            else if (mode == "Gerenciar senhas")
            {
                Console.WriteLine("bbbb funcionou");
            }
            else if (mode == "Mudar Senha-Mestra")
            {
                Console.WriteLine("Digite a Senha-Mestra para continuar.");
                tentativa = Console.ReadLine();
                if (tentativa == mestra)
                {
                    Console.Clear();
                    Console.WriteLine(@"Essa é a senha-mestra atual: {0}
Digite a nova senha.", mestra); //mostra a Mestra original
                    string novamestra;
                    mestra = Console.ReadLine(); //input para a nova mestra
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A Senha Está Incorreta! Tente novamente.");
                    Console.ReadKey();
                    goto iniciar;
                }
            }

                Console.ReadKey();
        }
    }
}