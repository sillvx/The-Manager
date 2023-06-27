using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using Spectre.Console;

namespace PWR.MGR
{
    class Program
    {
        public static void Main(string[] args)
        {
            string mestra; //Variável que define a senha-mestra

            //prompt inicial da senha mestra
            Console.WriteLine("Digite a Senha-Mestra");
            mestra = Console.ReadLine(); 
            Console.Clear();
            
            verificar: //aqui acontece a verificação, se estiver errada, voltará pra cá
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
                Console.WriteLine("A Senha Está Incorreta! Tente novamente.");
                goto verificar;
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
                Console.WriteLine("asijdauisdbauis");
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
        }
    }
}

//EXCLUIR ISSO DEPOIS
//string rep1 = mestra.Replace($"{mestra}", novamestra);  //cria uma nova string substituindo o conteúdo de mestra por novamestra
//Console.WriteLine("{0}", rep1); //retorna o 'novo' conteúdo //STATUS GERAL: "Works on my machine" 10/10!!!! ??????