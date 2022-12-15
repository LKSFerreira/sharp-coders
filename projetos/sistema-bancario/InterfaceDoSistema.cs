namespace sistema_bancario
{
    public class InterfaceDoSistema
    {
        private static string[] credenciais = File.ReadAllLines("credenciais.txt");
        public static bool LoginSistem()
        {
            bool usuarioLogado = false;

            do
            {

                IA.iBank("Por gentileza, digite seu usuário:");
                var usuario = Console.ReadLine()!;
                IA.iBank("Agora digite a senha por favor:");
                var senha = Console.ReadLine()!;

                foreach (var linha in credenciais)
                {
                    if (usuario == linha.Split(':')[0] && senha == linha.Split(':')[1])
                    {
                        IA.iBank("Logado com sucesso");
                        usuarioLogado = true;
                        break;
                    }
                }

                if (!usuarioLogado) IA.iBank("Usuário ou Senha inválido");

            } while (!usuarioLogado);

            return usuarioLogado;
        }

        public static int ShowMenu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Abrir uma nova conta para um cliente");
            System.Console.WriteLine("2 - Listar todas as contas registradas");
            System.Console.WriteLine("3 - Acessar uma conta");
            System.Console.WriteLine("4 - Consultar Capital de Giro do ByteBank");
            System.Console.WriteLine("5 - Realizar uma operação de Saque/Deposito ou Transferência");
            System.Console.WriteLine("0 - Sair do Sistema ByteBank");
            System.Console.WriteLine();
            IA.iBank("Digite o número da opção");

            return int.Parse(Console.ReadLine()!);
        }

        public static void SelectMenu(int opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case 1:
                    System.Console.WriteLine("Abriu conta cliente");
                    break;
                case 2:
                    System.Console.WriteLine("Listou contas registrada");
                    break;
                case 3:
                    System.Console.WriteLine("Acessou uma conta");
                    break;
                case 4:
                    System.Console.WriteLine("Consultou o capital de giro");
                    break;
                case 5:
                    System.Console.WriteLine("Realizou uma operacao");
                    break;
                case 0: 
                    System.Console.WriteLine();
                    IA.iBank("Obrigado por utlizar nossos serviços");
                    LogoByteBank();
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                    break;
                default:
                    IA.iBank("Opss, o valor digitado é inválido, por favor selecione uma das opções disponíveis.");
                    SelectMenu(ShowMenu());
                    break;
            }
        }

        public static void LoadSistem()
        {
            IA.iBank("Olá, eu sou o iBank, seu assiste virtual, serei o responsável por ajuda-lo a utilizar nosso sistema, por tanto Seja Bem-Vindo ao");

            LogoByteBank();
        }

        public static void LogoByteBank()
        {
            System.Console.WriteLine(@"
            ____        _       ____              _    
            |  _ \      | |     |  _ \            | |   
            | |_) |_   _| |_ ___| |_) | __ _ _ __ | | __
            |  _ <| | | | __/ _ \  _ < / _` | '_ \| |/ /
            | |_) | |_| | ||  __/ |_) | (_| | | | |   < 
            |____/ \__, |\__\___|____/ \__,_|_| |_|_|\_\
                    __/ |                               
                   |___/");
        }
    }
}