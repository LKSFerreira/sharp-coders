using sistema_bancario;

internal class Program
{
    private static void Main(string[] args)
    {
        //InterfaceDoSistema.LoadSistem();

        if (true)//InterfaceDoSistema.LoginSistem()
        {
            IA.iBank("O que deseja fazer?");

            InterfaceDoSistema.SelectMenu(InterfaceDoSistema.ShowMenu());

        }
    }
}