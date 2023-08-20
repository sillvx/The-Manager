using System;
using Spectre.Console;

namespace Gerenciador_de_Senhas

{
    internal class TheManager
    {
        static void Main(string[] args)
        {
            //programa começa a partir daqui:

            AnsiConsole.MarkupLine("[blue]Defina sua senha mestra[/]");     //AnsiConsole.MarkupLine é o nosso novo Console.WriteLine
            string mestra = Console.ReadLine();                             //definimos uma váriavel parar guardar a senha mestra, necessária pra entrar no programa
            Console.Clear();

        tentativadesenha:
            AnsiConsole.MarkupLine("[blue]Digite sua senha mestra[/]");     //aqui fazemos a verificação da senha mestra usando a variável Tentativa
            string tentativa = Console.ReadLine();                          //são duas váriáveis, a que definimos no passo anterior, e que receberá pelo teclado agora


            if (tentativa == mestra)
            {
                Console.WriteLine("funcionou");                             //caso a Tentativa seja igual a Senha-Mestra, o programa vai para (goto) Iniciar
                goto iniciar;                                               //iniciar é onde fica o nosso menu

            }
            else
            {
                Console.WriteLine("errou");                                 //se Tentativa não for igual a Senha-Mestra, retorna à verificação
                goto tentativadesenha;
            }

        iniciar: //a partir daqui, o meu iniciar e suas opções...
            Console.Clear();
            var mode = AnsiConsole.Prompt(                                  //AnsiConsole.Prompt vai criar uma listagem com as opções do menu iniciar
                new SelectionPrompt<string>()                               //.title vai definir oq vai ficar escrito em cima dessa lista
                    .Title(@"================================               
GERENCIADOR DE SENHAS 2000 V0.01
================================")
                    .AddChoices(new[]
                        {
                         "Cadastrar senhas", "Ver seus cadastros",          //addChoices definine nossas opções de menu
                         "Mudar Senha-Mestra",  "Sair do Programa" 
                        }));

                                                                            //a partir daqui, o sistema de IFs para entrar nas seções de cada opção do menu
            if (mode == "Ver seus cadastros")                              
            {
                Console.WriteLine("aaaaa funcionou");  //ainda não fizemos esse sistema.
            }
            else if (mode == "Cadastrar senhas")
            {
                AnsiConsole.MarkupLine("[bold]Não há senhas salvas.[/]");   //Aqui dizemos ao usuário que não tem salvas, e vamos pedir a ele para salvar a primeira
                Thread.Sleep(500);                                          //thread.sleep pausa a execução por determinado tempo, nesse caso, 500 milissegundos
                var criar = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[underline]Deseja cadastrar sua primeira senha[/]?")  //(pedindo para criar)
                        .PageSize(3)
                        .MoreChoicesText("[grey](bazinga)[/]") //PLACEHOLDER !!!! 
                        .AddChoices(new[] {
                            "Sim", "Não",                                             //aqui é a confirmação, se quer ou não criar
                    }));
                if (criar == "Não")
                {
                    criar = "";
                    goto iniciar;                                                     //se ele escolher "não", volta ao menu
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ótimo!");                                      //se ele escolher "sim", começa o cadastro
                    Thread.Sleep(1000);
                    Console.Clear();

                    string[] senha1 = new string[4];                                  //criamos um vetor com 4 informações: nome, login, senha e observações  

                    AnsiConsole.MarkupLine("Por favor, dê um nome ao cadastro.");
                    senha1[0] = Console.ReadLine();

                    AnsiConsole.MarkupLine("Digite o Login. [grey](usuário ou e-mail)[/]");
                    senha1[1] = Console.ReadLine();

                    AnsiConsole.MarkupLine("Digite a senha.");
                    senha1[2] = Console.ReadLine();

                    AnsiConsole.MarkupLine("Digite observações de sua escolha. [grey]ou deixe em branco se preferir[/]");
                    senha1[3] = Console.ReadLine();

                    Console.WriteLine("{0}, {1}, {2}, {3}", senha1[0], senha1[1], senha1[2], senha1[3]);  //ao final do cadastro, mostra cada informação

                }

            }
            else if (mode == "Mudar Senha-Mestra")                              //se o usuário quiser mudar a senha
            {
                Console.WriteLine("Digite a Senha-Mestra para continuar.");     
                tentativa = Console.ReadLine();
                if (tentativa == mestra)                                        //vai pedir a atual senha antes, se a verificação estiver correta, vai para a próxima etapa
                {
                    Console.Clear();
                    Console.WriteLine(@"Essa é a senha-mestra atual: {0}
Digite a nova senha.", mestra); //mostra a Mestra original
                    string novamestra;
                    mestra = Console.ReadLine(); //input para a nova mestra
                }
                else
                {
                    Console.Clear();                                                    //se a verificação estiver incorreta, vai te dizer que tá errado e vai voltar ao menuc
                    Console.WriteLine("A Senha Está Incorreta! Tente novamente.");
                    Console.ReadKey();
                    goto iniciar;
                }
            }

            Console.ReadKey();
        }
    }
}
