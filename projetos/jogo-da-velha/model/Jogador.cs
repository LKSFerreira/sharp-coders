using jogo_da_velha.controller;

namespace jogo_da_velha.model
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public int QuantidadePartidas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public List<string> Historico { get; set; }

        public Jogador()
        { }

        public Jogador(string nome)
        {
            Id = Sistema.AtualizarJogadores().Count() + 1;
            this.Nome = nome;
            Pontuacao = 0;
            QuantidadePartidas = 0;
            Vitorias = 0;
            Derrotas = 0;
            Empates = 0;
        }


    }
}