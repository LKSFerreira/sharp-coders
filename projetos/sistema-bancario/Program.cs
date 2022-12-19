using sistema_bancario;

internal class Program
{
    private static void Main(string[] args)
    {
        
        InterfaceDoSistema.CarregarSistema();

        if (InterfaceDoSistema.AutenticarSistema())
        {
            InterfaceDoSistema.SelecionarMenu(InterfaceDoSistema.MostrarMenu());
        }
    }
}