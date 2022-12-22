using sistema_bancario;

internal class Program
{
    private static void Main(string[] args)
    {   
        InterfaceDoSistema.CarregarSistema();
        InterfaceDoSistema.AtualizarCredenciais();
        InterfaceDoSistema.AtualizarClientes();
        
        if (InterfaceDoSistema.AutenticarSistema())
        {
            do
            {
                InterfaceDoSistema.SelecionarMenu(InterfaceDoSistema.MostrarMenu());
                
            } while (true);
        }
    }
}