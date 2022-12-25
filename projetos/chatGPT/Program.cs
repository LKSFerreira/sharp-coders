using chatGPT;

ChatBot.iChat(ChatBot.IniciarChat(), ConsoleColor.Green);
ChatBot.iChat("sair", ConsoleColor.Red);
Console.Write($"\n");

do
{
    string mensagem = Console.ReadLine()!.Trim();

    if (mensagem == "sair" || mensagem == "Sair" || mensagem == "Exit" || mensagem == "exit")
    {
        ChatBot.iChat(ChatBot.EncerrarChat(), ConsoleColor.Green);
        Thread.Sleep(2500);
        break;
    }
    ChatBot.Davinci(mensagem);


} while (true);