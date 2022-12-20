using sistema_bancario;

internal class Program
{
    private static void Main(string[] args)
    {

        //InterfaceDoSistema.CarregarSistema();

        if (true) // InterfaceDoSistema.AutenticarSistema()
        {
            do
            {
                InterfaceDoSistema.SelecionarMenu(InterfaceDoSistema.MostrarMenu());
            } while (true);
        }
    }
}