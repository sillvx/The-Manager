using System;
using Spectre.Console;

namespace Gerenciador_de_Senhas

{
    public class TheManager
    {
        static void Main(string[] args)
        {
            //declaração de vetores e variáveis que iremos usar na frente
            string[] nome = new string[6];
            string[] login = new string[6];
            string[] senha = new string[6];
            string[] obs = new string[6];
            int ncad = 0;                                           //contador de número de cadastros
            int i = 0;                                             //indice do while na hora de cadastrar
            
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
                new TextPrompt<string>("[blue]Digite[/] [white]novamente[/] [blue]sua Senha-Mestra:[/] ")  //AnsiConsole.Prompt gera a escrita da senha
                    .PromptStyle("white")                                                    //.PromptStyle é a cor dos *****
                    .Secret());                        //são duas váriáveis, a que definimos no passo anterior, e que receberá pelo teclado agora


            if (tentativa == mestra)
            {
                                                                            //caso a Tentativa seja igual a Senha-Mestra, o programa vai para (goto) Iniciar
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

            //a partir daqui, o sistema de IFs para entrar nas seções de cada opção do menu
            if (mode == "Cadastrar senhas")
            {
                ncad++;
                Console.Clear();
                Console.WriteLine("Ótimo! Este será seu {0}º cadastro.", ncad);
                Thread.Sleep(1000);
                Console.Clear();

                if (ncad >= 6)
                {
                    AnsiConsole.MarkupLine("[reverse red]Limite Atingido!!![/]");
                    Thread.Sleep(2000);
                    mode = "";
                    goto iniciar;
                }

                var ruleNome = new Rule("[blue]Nome[/]");
                ruleNome.LeftJustified();
                AnsiConsole.Write(ruleNome);
                AnsiConsole.MarkupLine(" 1 - Por favor, dê um nome ao cadastro.");
                nome[i] = Console.ReadLine();

                var ruleLogin = new Rule("[blue]Login[/]");
                ruleLogin.LeftJustified();
                AnsiConsole.Write(ruleLogin);
                AnsiConsole.MarkupLine(" 2 - Digite o Login. [grey](usuário ou e-mail)[/]");
                login[i] = Console.ReadLine();

                var ruleSenha = new Rule("[blue]Senha[/]");
                ruleSenha.LeftJustified();
                AnsiConsole.Write(ruleSenha);
                AnsiConsole.MarkupLine(" 3 - Digite a senha que deseja salvar.");
                senha[i] = Console.ReadLine();

                var ruleObs = new Rule("[blue]Observações[/]");
                ruleObs.LeftJustified();
                AnsiConsole.Write(ruleObs);
                AnsiConsole.MarkupLine(" 4 - Digite observações de sua escolha. [grey]ou deixe em branco se preferir[/]");
                obs[i] = Console.ReadLine();

                i++;

                Console.ReadKey();
                goto iniciar;
            }

            if (mode == "Ver seus cadastros")
            { 
                var linhacadastros = new Rule("[white]CADASTROS:[/]");
                linhacadastros.Justification = Justify.Left;
                linhacadastros.Style = Style.Parse("blue");
                AnsiConsole.Write(linhacadastros);

                var cadastros = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .AddChoices(new[] {
                            "[underline blue]<- Voltar ao menu inicial.[/]", "Login RollBack RX", "Acesso ao Sistema", "Gmail Empresa", nome[0],
                            nome[1], nome[2], nome[3], nome[4], nome[5]
                       }));
                if (cadastros == "[underline blue]<- Voltar ao menu inicial.[/]")
                {
                    cadastros = "";
                    goto iniciar;
                }
                if (cadastros == "Login RollBack RX")
                {
                    AnsiConsole.MarkupLine("Nome: Login RollBack RX");
                    AnsiConsole.MarkupLine("Login: Administrator");
                    AnsiConsole.MarkupLine("Senha: 4590");
                    AnsiConsole.MarkupLine("Observações: Exemplo com informações de login para o Rollback RX.");
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == "Acesso ao Sistema")
                {
                    AnsiConsole.MarkupLine("Nome: Acesso ao Sistema");
                    AnsiConsole.MarkupLine("Login: root");
                    AnsiConsole.MarkupLine("Senha: 9060");
                    AnsiConsole.MarkupLine("Observações: Exemplo com informações de login para o sistema de uma empresa.");
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == "Gmail Empresa")
                {
                    AnsiConsole.MarkupLine("Nome: Gmail Empresa");
                    AnsiConsole.MarkupLine("Login: farmacia@gmail.com");
                    AnsiConsole.MarkupLine("Senha: Farmacia123@");
                    AnsiConsole.MarkupLine("Observações: Exemplo com informações de acesso à um e-mail empresarial.");
                    Console.ReadKey();
                    goto iniciar;
                }

                if (cadastros == nome[0])
                {
                    AnsiConsole.MarkupLine("Nome: {0}", nome[0]);
                    AnsiConsole.MarkupLine("Login: {0}", login[0]);
                    AnsiConsole.MarkupLine("Senha: {0}", senha[0]);
                    AnsiConsole.MarkupLine("Observações: {0}", obs[0]);
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == nome[1])
                {
                    AnsiConsole.MarkupLine("Nome: {0}", nome[1]);
                    AnsiConsole.MarkupLine("Login: {0}", login[1]);
                    AnsiConsole.MarkupLine("Senha: {0}", senha[1]);
                    AnsiConsole.MarkupLine("Observações: {0}", obs[1]);
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == nome[2])
                {
                    AnsiConsole.MarkupLine("Nome: {0}", nome[2]);
                    AnsiConsole.MarkupLine("Login: {0}", login[2]);
                    AnsiConsole.MarkupLine("Senha: {0}", senha[2]);
                    AnsiConsole.MarkupLine("Observações: {0}", obs[2]);
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == nome[3])
                {
                    AnsiConsole.MarkupLine("Nome: {0}", nome[3]);
                    AnsiConsole.MarkupLine("Login: {0}", login[3]);
                    AnsiConsole.MarkupLine("Senha: {0}", senha[3]);
                    AnsiConsole.MarkupLine("Observações: {0}", obs[3]);
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == nome[4])
                {
                    AnsiConsole.MarkupLine("Nome: {0}", nome[4]);
                    AnsiConsole.MarkupLine("Login: {0}", login[4]);
                    AnsiConsole.MarkupLine("Senha: {0}", senha[4]);
                    AnsiConsole.MarkupLine("Observações: {0}", obs[4]);
                    Console.ReadKey();
                    goto iniciar;
                }
                if (cadastros == nome[5])
                {
                    AnsiConsole.MarkupLine("Nome: {0}", nome[5]);
                    AnsiConsole.MarkupLine("Login: {0}", login[5]);
                    AnsiConsole.MarkupLine("Senha: {0}", senha[5]);
                    AnsiConsole.MarkupLine("Observações: {0}", obs[5]);
                    Console.ReadKey();
                    goto iniciar;
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