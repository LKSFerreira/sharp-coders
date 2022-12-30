namespace jogo_da_velha.view
{
    public struct ArtASCII
    {
        public static string logo = @"
         ██╗ ██████╗  ██████╗  ██████╗     ██████╗  █████╗     ██╗   ██╗███████╗██╗     ██╗  ██╗ █████╗ 
         ██║██╔═══██╗██╔════╝ ██╔═══██╗    ██╔══██╗██╔══██╗    ██║   ██║██╔════╝██║     ██║  ██║██╔══██╗
         ██║██║   ██║██║  ███╗██║   ██║    ██║  ██║███████║    ██║   ██║█████╗  ██║     ███████║███████║
    ██   ██║██║   ██║██║   ██║██║   ██║    ██║  ██║██╔══██║    ╚██╗ ██╔╝██╔══╝  ██║     ██╔══██║██╔══██║
    ╚█████╔╝╚██████╔╝╚██████╔╝╚██████╔╝    ██████╔╝██║  ██║     ╚████╔╝ ███████╗███████╗██║  ██║██║  ██║
     ╚════╝  ╚═════╝  ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝  ╚═╝      ╚═══╝  ╚══════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝
     ";
        public static string tabuleiroDaVelha = @"
      ╔═════╦═════╦═════╗
    3 ║     ║     ║     ║
      ╠═════╬═════╬═════╣
    2 ║     ║     ║     ║
      ╠═════╬═════╬═════╣
    1 ║     ║     ║     ║
      ╚═════╩═════╩═════╝
         A     B     C";


        public static string rank = @"
    ██████╗  █████╗ ███╗   ██╗██╗  ██╗
    ██╔══██╗██╔══██╗████╗  ██║██║ ██╔╝
    ██████╔╝███████║██╔██╗ ██║█████╔╝ 
    ██╔══██╗██╔══██║██║╚██╗██║██╔═██╗ 
    ██║  ██║██║  ██║██║ ╚████║██║  ██╗
    ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝
    ";

        private static string A = @"   
╔═╗
╠═╣
╩ ╩";
        private static string B = @"   
╔╗ 
╠╩╗
╚═╝";

        private static string C = @"   
╔═╗
║  
╚═╝";
        private static string D = @"   
╔╦╗
 ║║
═╩╝";
        private static string E = @"   
╔═╗
║╣ 
╚═╝";
        private static string F = @"   
╔═╗
╠╣ 
╚  ";
        private static string G = @"   
╔═╗
║ ╦
╚═╝";

        private static string H = @"   
╦ ╦
╠═╣
╩ ╩";
        private static string I = @"   
╦
║
╩";
        private static string J = @"   
 ╦
 ║
╚╝";

        private static string K = @"   
╦╔═
╠╩╗
╩ ╩";
        private static string L = @"   
╦  
║  
╩═╝";
        private static string M = @"   
╔╦╗
║║║
╩ ╩";
        private static string N = @"   
╔╗╔
║║║
╝╚╝";
        private static string O = @"   
╔═╗
║ ║
╚═╝";
        private static string P = @"   
╔═╗
╠═╝
╩  ";
        private static string Q = @"   
╔═╗ 
║═╬╗
╚═╝╚";
        private static string R = @"   
╦═╗
╠╦╝
╩╚═";
        private static string S = @"   
╔═╗
╚═╗
╚═╝";
        private static string T = @"   
╔╦╗
 ║ 
 ╩ ";
        private static string U = @"   
╦ ╦
║ ║
╚═╝";
        private static string V = @"   
╦  ╦
╚╗╔╝
 ╚╝ ";
        private static string X = @"   
═╗ ╦
╔╩╦╝
╩ ╚═";
        private static string W = @"   
╦ ╦
║║║
╚╩╝";
        private static string Y = @"   
╦ ╦
╚╦╝
 ╩ ";
        private static string Z = @"   
══╗
╔═╝
╚══";
        private static string SPACE = @"   
  
  
  ";
        private static string TAB = @"   
    
    
    ";
        private static string cara = @"
     .----------------. 
    | .--------------. |
    | |  ____  ____  | |
    | | |_   ||   _| | |
    | |   | |__| |   | |
    | |   |  __  |   | |
    | |  _| |  | |_  | |
    | | |____||____| | |
    | |              | |
    | '--------------' |
    '------------------' ";
        private static string coroa = @"
     .----------------. 
    | .--------------. |
    | |  _________   | |
    | | |  _   _  |  | |
    | | |_/ | | \_|  | |
    | |     | |      | |
    | |    _| |_     | |
    | |   |_____|    | |
    | |              | |
    | '--------------' |
     '----------------' ";

        private static IDictionary<char, string> dicionario = new Dictionary<char, string>
        {
            {'A', A},
            {'B', B},
            {'C', C},
            {'D', D},
            {'E', E},
            {'F', F},
            {'G', G},
            {'H', H},
            {'I', I},
            {'J', J},
            {'K', K},
            {'L', L},
            {'M', M},
            {'N', N},
            {'O', O},
            {'P', P},
            {'Q', Q},
            {'R', R},
            {'S', S},
            {'T', T},
            {'U', U},
            {'V', V},
            {'X', X},
            {'W', W},
            {'Y', Y},
            {'Z', Z},
            {' ', SPACE}
        };

        public static void ContruirNome(string nome)
        {
            nome = nome.ToUpper();
            string[] linhaDasLetras = new string[4];

            foreach (char letra in nome.Insert(0, "  "))
            {
                string[] temporaria = ArtASCII.dicionario[letra].Split(Environment.NewLine);
                for (int i = 0; i < 4; i++)
                {
                    linhaDasLetras[i] += temporaria[i];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{linhaDasLetras[i]}");
            }
        }
    }





}