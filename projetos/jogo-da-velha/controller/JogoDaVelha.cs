using jogo_da_velha.model;
using jogo_da_velha.view;

namespace jogo_da_velha.controller;

public class JogoDaVelha
{
    private string[][] tabuleiro;
    private static Jogador player01 = new Jogador();
    private static Jogador player02 = new Jogador();



    public static Jogador PvP()
    {
        int idJogador = 0;
        Jogador jogador = new Jogador();

        Console.WriteLine($"    Digite o ID do jogador ou digite um nome para uma novo jogador");
        string idOuNomeJogador = Console.ReadLine();

        if (int.TryParse(idOuNomeJogador, out idJogador))
        {
            jogador = Sistema.BuscarJogadorPorID(idJogador);
            if (jogador is null)
            {
                Console.WriteLine($"    Jogador não encontrado.");
                return jogador = CriarJogador();
            }
            return jogador;
        }
        else
        {
            jogador = new Jogador(idOuNomeJogador);
            Sistema.AdicionarJogador(jogador);
            Sistema.BuscarJogadorPorID(jogador.Id);
            return jogador;
        }
    }

    public static void SelecionarJogadores()
    {
        player01 = PvP();
        player02 = PvP();
        Console.WriteLine($"    {player01.Nome} pronto(a)! Para o adversário(a)\n");
        Console.WriteLine($"    {player02.Nome} preparado(a) para começar!\n ");
        Thread.Sleep(3000);

        Console.Clear();

        ArtASCII.ContruirNome($"{player01.Nome} VS {player02.Nome}");

        IniciarPartida(player01, player02);
    }
    public static void IniciarPartida(Jogador player01, Jogador player02)
    {
        Console.WriteLine($"    Sorteando primeira jogada... ");
        Thread.Sleep(3000);
        Console.Clear();

        var jogadorDaVez = Sistema.SortearJogador(player01, player02);

        var tabuleiro = ArtASCII.tabuleiroDaVelha;
        Console.WriteLine($"    {tabuleiro}\n");

        int numeroDeJogadas = 0;
        Random random = new Random();

        HashSet<int> numerosSorteados = new();
        //HashSet<int> numerosSorteados = new HashSet<int> { 1, 2, 4, 5, 7, 8 };
        HashSet<int> jogadasPlayer01 = new();
        HashSet<int> jogadasPlayer02 = new();

        while (numerosSorteados.Count < 9)
        {
            int numeroAleatorio = random.Next(1, 10);
            numerosSorteados.Add(numeroAleatorio);
        }

        int posicao = 0, jogada = 1;
        string jogadorX = "X", jogadorO = "O";

        do
        {

            Console.WriteLine($"    {jogada}\u00aa jogada de: {jogadorDaVez[0].Nome}");
            var realizadaJogada = Sistema.RealizarJogada(tabuleiro, numerosSorteados.ElementAt(posicao).ToString(), jogadorX);
            tabuleiro = realizadaJogada.Item2;
            jogadasPlayer01.Add(realizadaJogada.Item1);

            posicao++;
            jogada++;
            numeroDeJogadas++;

            Console.WriteLine($"    {tabuleiro}\n");

            if (Sistema.CondicionalVitoria(tabuleiro, jogadorX))
            {
                ArtASCII.ContruirNome($"{jogadorDaVez[0].Nome} Venceu");
                return;
            }

            Thread.Sleep(1000);

            if (posicao == 9) break;

            Console.WriteLine($"    {jogada}\u00aa jogada de: {jogadorDaVez[1].Nome}");

            realizadaJogada = Sistema.RealizarJogada(tabuleiro, numerosSorteados.ElementAt(posicao).ToString(), jogadorO);
            tabuleiro = realizadaJogada.Item2;
            jogadasPlayer02.Add(realizadaJogada.Item1);

            posicao++;
            jogada++;
            numeroDeJogadas++;
            Console.WriteLine($"    {tabuleiro}\n");

            if (Sistema.CondicionalVitoria(tabuleiro, jogadorO))
            {
                ArtASCII.ContruirNome($"{jogadorDaVez[0].Nome} Venceu");
                return;
            }
            Thread.Sleep(1000);
        } while (numeroDeJogadas < 9);

    }

    public static Jogador CriarJogador()
    {
        Console.WriteLine($"    Digite o nome do Jogador: ");
        string nome = Console.ReadLine();
        Jogador jogador = new Jogador(nome);
        return jogador;
    }
}
