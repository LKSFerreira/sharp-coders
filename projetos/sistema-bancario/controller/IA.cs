namespace sistema_bancario
{
    public class IA
    {
        public static void iBank(string mensagem)
        {
            // O gerador de números aleatórios usado para gerar o tempo de saída
            Random geradorAleatorio = new Random();

            // Mostra cada letra da mensagem letra por letra
            foreach (char letra in mensagem)
            {
                // Gera um novo valor aleatório para o tempo de saída
                int tempoSaida = geradorAleatorio.Next(50);

                // Exibe a letra e espera o tempo de saída antes de passar para a próxima
                Console.Write(letra);

                if (tempoSaida % 2 == 0)
                {
                    tempoSaida = geradorAleatorio.Next(170);
                    Thread.Sleep(tempoSaida);
                }
                else
                {
                    Thread.Sleep(tempoSaida);
                }
            }
            System.Console.WriteLine();
        }
        public static void BarraCarregamento()
        {
            int barraCarregamento = 25;

            for (int i = 0; i <= 25; i++)
            {
                Console.Write("\rExecutando: " + new string('\u2588', i) + new string(' ', barraCarregamento - i) + " " + i * 4 + "%");
                Thread.Sleep(100);
            }
            System.Console.WriteLine("\n");
        }
    }
}