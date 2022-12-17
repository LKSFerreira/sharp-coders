using sistema_bancario;

internal class Program
{
    private static void Main(string[] args)
    {
        //IA.BarraCarregamento();
        InterfaceDoSistema.LoadSistem();

        if (true)//InterfaceDoSistema.LoginSistem()
        {
            InterfaceDoSistema.SelectMenu(InterfaceDoSistema.ShowMenu());
        }
    }
}