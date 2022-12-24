using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenAI;
namespace chatGPT
{
    public class ChatBot
    {
        const string API_KEY = "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";
        public static async void Davinci(string mensagem)
        {
            var openAI = new OpenAIAPI(apiKeys: API_KEY, engine: Engine.Davinci);

            int max_tokens = 4086;

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
            return "Eu sou o Assistant, um modelo de linguagem de computador treinado por OpenAI. Sou capaz de responder a perguntas e ajudá-lo com tarefas específicas usando meu conhecimento e habilidades de processamento de linguagem natural. Minha função principal é ajudar as pessoas a encontrar informações e resolver problemas. Caso queira encerrar o programa digite: sair";
        }

        public static string EncerrarChat()
        {
            return "Obrigado e até a próxima.";
        }
        public static void Apresentacao(string mensagem)
        {

            Random geradorAleatorio = new Random();

            Console.ForegroundColor = ConsoleColor.Green;

            foreach (char letra in mensagem)
            {

                int tempoSaida = geradorAleatorio.Next(70);

                Console.Write(letra);

                if (tempoSaida % 2 == 0)
                {
                    tempoSaida = geradorAleatorio.Next(350);
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