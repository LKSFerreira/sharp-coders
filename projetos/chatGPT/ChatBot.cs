using OpenAI;

namespace chatGPT
{
    public class ChatBot
    {
        const string API_KEY = "";
        const string API_KEY_SECONDARY = "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";
        public static async void Davinci(string mensagem)
        {
            var openAI = new OpenAIAPI(apiKeys: API_KEY_SECONDARY, engine: Engine.Davinci);

            int max_tokens = 4050;

            await foreach (var token in openAI.Completions.StreamCompletionEnumerableAsync(new CompletionRequest(
                mensagem, max_tokens, 0.9, 1, presencePenalty: 0.6, frequencyPenalty: 0)))
            {
                Random geradorAleatorio = new Random();
                Console.ForegroundColor = ConsoleColor.Green;

                int tempoSaida = geradorAleatorio.Next(70);

                Console.Write(token);

                if (tempoSaida % 2 == 0)
                {
                    tempoSaida = geradorAleatorio.Next(350);
                    Thread.Sleep(tempoSaida);
                }
                else
                {
                    Thread.Sleep(tempoSaida);
                }
                Console.ResetColor();
            }
            Console.WriteLine("\n");
        }

        public static async Task BotOpenAIAsync(string mensagem)
        {
            var openAI = new OpenAIAPI(apiKeys: API_KEY, engine: Engine.Davinci);

            var request = new CompletionRequestBuilder()
                .WithPrompt(mensagem)
                .WithMaxTokens(4000)
                .Build();

            var result = await openAI.Completions.CreateCompletionAsync(request);

            Console.WriteLine($"{result.ToString()}");
        }
        public static string IniciarChat()
        {
            return "Eu sou um Assistente Virtual, um Modelo de Linguagem de computador.\nSou capaz de responder a perguntas e ajudá-lo com tarefas específicas usando meu conhecimento e habilidades de processamento de linguagem natural.\nMinha função principal é ajudar as pessoas a encontrar informações e resolver problemas. Caso queira encerrar o programa digite: ";
        }

        public static string EncerrarChat()
        {
            return "Obrigado e até a próxima.";
        }
        public static void iChat(string mensagem, ConsoleColor color)
        {

            Random geradorAleatorio = new Random();

            Console.ForegroundColor = color;

            foreach (char letra in mensagem)
            {

                int tempoSaida = geradorAleatorio.Next(50);

                Console.Write(letra);

                if (tempoSaida % 2 == 0)
                {
                    tempoSaida = geradorAleatorio.Next(100);
                    Thread.Sleep(tempoSaida);
                }
                else
                {
                    Thread.Sleep(tempoSaida);
                }
            }
            System.Console.Write("\n");
            Console.ResetColor();
        }
    }
}