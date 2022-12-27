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
                    // Estatísticas do jogador
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

        public static void Iniciar()
        {
            Console.WriteLine($"{ArtASCII.logo}");
        }

        public static void ExibirRank()
        {
            Console.Clear();
            Console.WriteLine($"{ArtASCII.rank}");

            string jsonString = File.ReadAllText("./data/rank.json");
            Jogador[] jogadores = JsonConvert.DeserializeObject<Jogador[]>(jsonString);

            foreach (var jogador in jogadores.OrderByDescending(player => player.Pontuacao))
            {
                Console.WriteLine($"    Nome: {jogador.Nome} \t\t Pontuação: {jogador.Pontuacao}");
            }
            Console.Write($"\n");
        }


    }
}