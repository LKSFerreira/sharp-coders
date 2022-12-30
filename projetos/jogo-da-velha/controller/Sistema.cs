using jogo_da_velha.model;
using jogo_da_velha.view;
using Newtonsoft.Json;
using jogo_da_velha.controller;


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
            Console.WriteLine($"    0 - Sair");

            opcaoMenu = Console.ReadLine();

            SelecionarMenu(opcaoMenu);
        }

        private static void SelecionarMenu(string opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case "1":
                    JogoDaVelha.SelecionarJogadores();
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
        private static string pathJogadores = "./data/jogadores.json";
        static string jsonJogadores = File.ReadAllText(pathJogadores);
        public static List<Jogador> AtualizarJogadores()
        {
            jsonJogadores = File.ReadAllText(pathJogadores);
            List<Jogador> jogadores = JsonConvert.DeserializeObject<List<Jogador>>(jsonJogadores);
            return jogadores;
        }
        public static void AdicionarJogador(Jogador jogador)
        {
            var novoJogadores = AtualizarJogadores();
            novoJogadores.Add(jogador);

            jsonJogadores = JsonConvert.SerializeObject(novoJogadores);

            File.WriteAllText(pathJogadores, jsonJogadores);
        }

        private static void ExibirStatusJogador()
        {
            Console.WriteLine($"    Por gentileza digete o ID do jogador");
            int idJogador = int.Parse(Console.ReadLine());

            Console.Clear();

            var jogadores = AtualizarJogadores();

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

        public static Jogador BuscarJogadorPorID(int idJogador)
        {
            var jogadores = AtualizarJogadores();

            Jogador novoJogador = new Jogador();

            foreach (var jogador in jogadores.Where(player => player.Id == idJogador))
            {
                ArtASCII.ContruirNome(jogador.Nome);

                Console.WriteLine($"    Pontuação: {jogador.Pontuacao}");
                Console.WriteLine($"    Vitórias: {jogador.Vitorias}");

                Console.Write($"\n");

                return jogador;
            }
            return novoJogador;
        }

        public static void Iniciar()
        {
            Console.WriteLine($"{ArtASCII.logo}");
        }

        public static void ExibirRank()
        {
            Console.Clear();
            Console.WriteLine($"{ArtASCII.rank}");

            string jsonString = File.ReadAllText(pathJogadores);
            Jogador[] jogadores = JsonConvert.DeserializeObject<Jogador[]>(jsonString);

            foreach (var jogador in jogadores.OrderByDescending(player => player.Pontuacao))
            {
                Console.WriteLine($"    Nome: {jogador.Nome} \t\t Pontuação: {jogador.Pontuacao}");
            }
            Console.Write($"\n");
        }

        public static Jogador[] SortearJogador(Jogador player1, Jogador player2)
        {
            Random random = new Random();
            int i = 0;
            for (i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    ArtASCII.ContruirNome(player1.Nome);
                    Thread.Sleep(350);
                    Console.Clear();
                }
                else
                {
                    ArtASCII.ContruirNome(player2.Nome);
                    Thread.Sleep(350);
                    Console.Clear();
                }
            }

            if (random.Next(0, 2) % 2 == 0)
            {
                ArtASCII.ContruirNome(player1.Nome);
                Jogador[] jogadores = { player1, player2 };
                return jogadores;
            }
            else
            {
                ArtASCII.ContruirNome(player2.Nome);
                Jogador[] jogadores = { player2, player1 };
                return jogadores;
            }
        }
        static IDictionary<string, int> coordTabuleiro = new Dictionary<string, int>
    {
        {"A1",146},
        {"B1",152},
        {"C1",158},
        {"A2",92},
        {"B2",98},
        {"C2",104},
        {"A3",38},
        {"B3",44},
        {"C3",50}
    };

        public static Tuple<int, string> RealizarJogada(string tabuleiro, string coordenada, string X_ou_O)
        {
            int coord = int.Parse(coordenada);

            switch (coord)
            {
                case 1:
                    coordenada = "A1";
                    break;
                case 2:
                    coordenada = "B1";
                    break;
                case 3:
                    coordenada = "C1";
                    break;
                case 4:
                    coordenada = "A2";
                    break;
                case 5:
                    coordenada = "B2";
                    break;
                case 6:
                    coordenada = "C2";
                    break;
                case 7:
                    coordenada = "A3";
                    break;
                case 8:
                    coordenada = "B3";
                    break;
                case 9:
                    coordenada = "C3";
                    break;
                default:
                    Console.WriteLine($"    Coordenada inválida");
                    break;
            }
            tabuleiro = tabuleiro.Remove(coordTabuleiro[coordenada], 1).Insert(coordTabuleiro[coordenada], X_ou_O);
            return Tuple.Create(coordTabuleiro[coordenada], tabuleiro);
        }

        public static bool CondicionalVitoria(string tabuleiro, string jogador_X_ou_O)
        {
            char valor = jogador_X_ou_O[0];

            foreach (var letra in tabuleiro)
            {
                if (letra == valor)
                {
                    if ((tabuleiro.ElementAt(146) == valor && tabuleiro.ElementAt(92) == valor && tabuleiro.ElementAt(38) == valor) ||
                        (tabuleiro.ElementAt(152) == valor && tabuleiro.ElementAt(98) == valor && tabuleiro.ElementAt(44) == valor) ||
                        (tabuleiro.ElementAt(158) == valor && tabuleiro.ElementAt(104) == valor && tabuleiro.ElementAt(50) == valor) ||
                        (tabuleiro.ElementAt(146) == valor && tabuleiro.ElementAt(152) == valor && tabuleiro.ElementAt(158) == valor) ||
                        (tabuleiro.ElementAt(92) == valor && tabuleiro.ElementAt(98) == valor && tabuleiro.ElementAt(104) == valor) ||
                        (tabuleiro.ElementAt(38) == valor && tabuleiro.ElementAt(44) == valor && tabuleiro.ElementAt(50) == valor) ||
                        (tabuleiro.ElementAt(146) == valor && tabuleiro.ElementAt(98) == valor && tabuleiro.ElementAt(50) == valor) ||
                        (tabuleiro.ElementAt(38) == valor && tabuleiro.ElementAt(98) == valor && tabuleiro.ElementAt(158) == valor))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}