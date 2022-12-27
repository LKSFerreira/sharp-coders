namespace jogo_da_velha.model
{
    public class Jogador
    {   
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public int QuantidadePartidas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public string Historico { get; set; }
        
        public Jogador()
        { }
    }
}