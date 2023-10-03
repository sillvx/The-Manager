using System;
using Spectre.Console;

namespace Gerenciador_de_Senhas

{
    public class TheManager
    {
        static void Main(string[] args)
        {
            string[] nome = new string[6];
            string[] login = new string[6];
            string[] senha = new string[6];
            string[] obs = new string[6];
            string nome1 = "";
            int ncad = 0;
            
            //programa começa a partir daqui:
            var linhamestra = new Rule("[white]SENHA-MESTRA:[/]");    //linha de cima (rule)
            linhamestra.Justification = Justify.Left;                   //texto justificado na esquerda
            linhamestra.Style = Style.Parse("blue");                    //cor da linha azul
            AnsiConsole.Write(linhamestra);                         //pra mostrar a linha

            string mestra;                             //definimos uma váriavel parar guardar a senha mestra, necessária pra entrar no programa

            mestra = AnsiConsole.Prompt(                                                    //esse é, básicamente, um Console.ReadLine();
                new TextPrompt<string>("[blue]Defina sua[/] [bold blue]Senha-Mestra:[/] ")  //AnsiConsole.Prompt gera a escrita da senha
                    .PromptStyle("white")                                                   //.PromptStyle é a cor dos *****
                    .Secret());                                                             //define que o texto ficar escondido (literalmente secret)


        tentativadesenha:
            Console.Clear();
            var linhaconfirmar = new Rule("[white]CONFIRMAÇÃO[/]");             //outra linha, texto "confirmação"
            linhaconfirmar.Justification = Justify.Left;
            linhaconfirmar.Style = Style.Parse("blue");
            AnsiConsole.Write(linhaconfirmar);                                  //mostra a linha

            string tentativa;

            tentativa = AnsiConsole.Prompt(                                                    //esse é, básicamente, um Console.ReadLine();
                new TextPrompt<string>("[blue]Digite a sua[/] [bold blue]Senha-Mestra:[/] ")  //AnsiConsole.Prompt gera a escrita da senha
                    .PromptStyle("white")                                                   //.PromptStyle é a cor dos *****
                    .Secret());                        //são duas váriáveis, a que definimos no passo anterior, e que receberá pelo teclado agora


            if (tentativa == mestra)
            {
                Console.WriteLine("funcionou");                             //caso a Tentativa seja igual a Senha-Mestra, o programa vai para (goto) Iniciar
                goto iniciar;                                               //iniciar é onde fica o nosso menu

            }
            else
            {
                AnsiConsole.MarkupLine("[red]A senha está errada![/]");                                 //se Tentativa não for igual a Senha-Mestra, retorna à verificação
                Thread.Sleep(1000); //thread.sleep é uma pausa na execução, nesse caso, de 1000 milissegundos
                goto tentativadesenha; //retorna pra verificação
            }


        iniciar: //a partir daqui, o meu iniciar e suas opções...
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("The Manager")               //logo do The Manager no menu iniciar
                    .Centered()                             //alinha a logo ao centro
                    .Color(Color.Blue));                    //define azul como a cor.

            var mode = AnsiConsole.Prompt(                                  //AnsiConsole.Prompt vai criar uma listagem com as opções do menu iniciar
                new SelectionPrompt<string>()                               //.title vai definir oq vai ficar escrito em cima dessa lista
                    //.Title("Gerenciador de Senhas")
                    .AddChoices(new[]
                        {
                         "Cadastrar senhas", "Ver seus cadastros",          //addChoices definine nossas opções de menu
                         "Mudar Senha-Mestra",  "Sair do Programa" 
                        }));

            bool vazio = true;                                          //boolean para verificar se já há alguma senha criada, isso vai nos ajudar futuramente

            string[] senha1 = new string[4];
            


            //a partir daqui, o sistema de IFs para entrar nas seções de cada opção do menu
            if (mode == "Cadastrar senhas")
            {
                ncad++;
                Console.Clear();
                Console.WriteLine("Ótimo! Este será seu {0}º cadastro.", ncad);
                Thread.Sleep(1000);
                Console.Clear();

                if (ncad == 1)
                {
                    AnsiConsole.MarkupLine("Por favor, dê um nome ao cadastro.");
                    nome[0] = Console.ReadLine();
                    AnsiConsole.MarkupLine("Digite o Login. [grey](usuário ou e-mail)[/]");
                    login[0] = Console.ReadLine();
                    AnsiConsole.MarkupLine("Digite a senha.");
                    senha[0] = Console.ReadLine();
                    AnsiConsole.MarkupLine("Digite observações de sua escolha. [grey]ou deixe em branco se preferir[/]");
                    obs[0] = Console.ReadLine();
                    AnsiConsole.WriteLine("{0}, {1}, {2}, {3}", nome[0], login[0], senha[0], obs[0]);
                    
                }
                if (ncad == 2)
                {
                    AnsiConsole.WriteLine("avc");
                }


                                                //criamos um vetor com 4 informações: nome, login, senha e observações  

                AnsiConsole.MarkupLine("Por favor, dê um nome ao cadastro.");
                nome1 = Console.ReadLine();

                AnsiConsole.MarkupLine("Digite o Login. [grey](usuário ou e-mail)[/]");
                senha1[1] = Console.ReadLine();

                AnsiConsole.MarkupLine("Digite a senha.");
                senha1[2] = Console.ReadLine();

                AnsiConsole.MarkupLine("Digite observações de sua escolha. [grey]ou deixe em branco se preferir[/]");
                senha1[3] = Console.ReadLine();

                Console.WriteLine("{0}, {1}, {2}, {3}", nome1, senha1[1], senha1[2], senha1[3]);  //ao final do cadastro, mostra cada informação
                Console.ReadKey();

                goto iniciar;

                vazio = true;
            }

            if (mode == "Ver seus cadastros")                              
            {
                Console.Clear();
                var linhacadastros = new Rule("[blue]CADASTROS:[/]");
                linhacadastros.Justification = Justify.Left;
                linhacadastros.Style = Style.Parse("blue");
                AnsiConsole.Write(linhacadastros);

                var cadastros = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .AddChoices(new[] {
                            "Login RollBack RX", "Acesso ao Sistema", "Gmail Empresa", "Voltar ao menu inicial.", nome1
                       }));
                if (cadastros == "Login RollBack RX")
                {
                    Console.WriteLine("enis");
                }
                if (cadastros == "Voltar ao menu inicial.")
                {
                    cadastros = "";
                    goto iniciar;
                }

                //REMOVER
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
                    mode = "Cadastrar senhas";                                                        //...
                }
            }

           
            
            if (mode == "Mudar Senha-Mestra")                              //se o usuário quiser mudar a senha
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
                    goto iniciar;
                }
                else
                {
                    Console.Clear();                                                    //se a verificação estiver incorreta, vai te dizer que tá errado e vai voltar ao menuc
                    Console.WriteLine("A Senha Está Incorreta! Tente novamente.");
                    Console.ReadKey();
                    goto iniciar;
                }
            }
            else                                                //caso escolha "fechar o programa"
            { 
                Environment.Exit(0);                            //Fecha o programa.
            }
            

            Console.ReadKey();
        }
    }
}