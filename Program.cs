using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GerenciadordeSenhas
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(@"Bem-vindo, este é o menu inicial. Selecione uma das opções abaixo:
    1 - Ver suas senhas
    2 - Gerenciar senhas
    3 - Mudar Senha-Mestra
    ]4 - Sair do Programa
            ");

            Console.ReadKey();
        }
    }
}