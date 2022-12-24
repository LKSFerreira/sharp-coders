using chatGPT;

ChatBot.Apresentacao(ChatBot.IniciarChat());

do
{
    string mensagem = Console.ReadLine()!;

    if (mensagem == "sair" || mensagem == "Sair" || mensagem == "Exit" || mensagem == "exit")
    {
        ChatBot.Apresentacao(ChatBot.EncerrarChat());
        Thread.Sleep(2500);
        break;
    }
    ChatBot.Davinci(mensagem);


} while (true);