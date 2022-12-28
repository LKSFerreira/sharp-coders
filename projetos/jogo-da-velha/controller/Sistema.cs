using jogo_da_velha.model;
using jogo_da_velha.view;
using Newtonsoft.Json;


namespace jogo_da_velha.controller
{
    public class Sistema
    {
        private static string opcaoMenu;

        public static void Menu()
        {
            Console.WriteLine($"    Digite uma opção:\n");
            Console.WriteLine($"    1 - Jogar");
            Console.WriteLine($"    2 - Rank");
            Console.WriteLine($"    3 - Estatísticas do jogador");
            Console.WriteLine($"    4 - Sair");

            opcaoMenu = Console.ReadLine();

            SelecionarMenu(opcaoMenu);
        }

        private static void SelecionarMenu(string opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case "1":
                    // Jogar
                    break;
                case "2":
                    ExibirRank();
                    break;
                case "3":
                    ExibirStatusJogador();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"    Por favor seleciona uma opção válida \n");
                    break;
            }
        }

        private static void ExibirStatusJogador()
        {
            Console.WriteLine($"    Por gentileza digete o ID do jogador");
            int idJogador = int.Parse(Console.ReadLine());
            Console.Write($"\n");

            string jsonString = File.ReadAllText("./data/jogadores.json");
            Jogador[] jogadores = JsonConvert.DeserializeObject<Jogador[]>(jsonString);

            foreach (var jogador in jogadores.Where(player => player.Id == idJogador))
            {
                ArtASCII.ContruirNome(jogador.Nome.ToUpper());

                Console.WriteLine($"    Pontuação: {jogador.Pontuacao}");
                Console.WriteLine($"    Quantidade de Partidas: {jogador.QuantidadePartidas}");
                Console.WriteLine($"    Vitórias: {jogador.Vitorias}");
                Console.WriteLine($"    Derrotas: {jogador.Derrotas}");
                Console.WriteLine($"    Empates: {jogador.Empates}");
                Console.Write($"    Histórico:");

                foreach (var partida in jogador.Historico)
                {
                    Console.Write($" {partida}");
                }
                Console.WriteLine($"\n");
            }
        }

        public static void Iniciar()
        {
            Console.WriteLine($"{ArtASCII.logo}");
        }

        public static void ExibirRank()
        {
            Console.Clear();
            Console.WriteLine($"{ArtASCII.rank}");

            string jsonString = File.ReadAllText("./data/jogadores.json");
            Jogador[] jogadores = JsonConvert.DeserializeObject<Jogador[]>(jsonString);

            foreach (var jogador in jogadores.OrderByDescending(player => player.Pontuacao))
            {
                Console.WriteLine($"    Nome: {jogador.Nome} \t\t Pontuação: {jogador.Pontuacao}");
            }
            Console.Write($"\n");
        }
    }
}