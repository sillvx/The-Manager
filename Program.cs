using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

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

            string opcao1;
            string opcao2;
            string opcao3;
            string opcao4;
            string menu;

            opcao1 = "1";
            opcao2 = "2";
            opcao3 = "3";
            opcao4 = "4";

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
            
            iniciar:
            menu = Console.ReadLine();
            if (menu == opcao1)
            {
                Console.Clear();
                Console.WriteLine("Funcionou menó");
            }
            else if (menu == opcao2)
            {
                Console.Clear();
                Console.WriteLine("tbm funcionou meno");
            }
            else if (menu == opcao3)
            {
                Console.Clear();
                goto escolheu3;
            }
            else if (menu == opcao4)
            {
                Console.Clear();
                goto escolheu4;
            }

        escolheu1: //Mostrar as Senhas!!!!


        escolheu2:


        escolheu3: //Mudar Senha!!!!
            Console.Clear();
            Console.WriteLine(mestra); //mostra a Mestra original
            string novamestra;
            novamestra = Console.ReadLine(); //input para a nova mestra

            var replacement = mestra.Replace("{0}", novamestra); //comando que vai substituir a original pela nova
            Console.WriteLine("Funcionou meno {0}", novamestra); //retorna que funcionou, e a nova mestra
                                                                 //STATUS GERAL: "Works on my machine" 10/10!!!!

        escolheu4:
            string sair;
            string naosair;
            string tbmnaosair;
            sair = "sim";
            naosair = "nao";
            tbmnaosair = "não";

            Console.WriteLine(@"Você tem certeza que deseja sair?
SIM
NÃO");
            string desejo;
            desejo = Console.ReadLine();
            if (desejo == sair)
            {
                Environment.Exit(0);
            }
        
        }
    }
}