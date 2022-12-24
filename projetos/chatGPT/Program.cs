using chatGPT;

do
{
    string mensagem = Console.ReadLine()!;

    ChatBot.Davinci(mensagem);

} while (true);