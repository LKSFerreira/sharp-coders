namespace sistema_bancario
{
    public class InterfaceDoSistema
    {
        private static string cpfCliente = "";
        private static bool acessouDetalhesDaConta = false;
        private static bool acessouTransferenciaPix = false;
        private static string[] credenciais = File.ReadAllLines("./data/credenciais.txt");
        private static string[] clientes = File.ReadAllLines("./data/clientes.txt");
        private static void AtualizarClientes() { clientes = File.ReadAllLines("./data/clientes.txt"); }


        public static bool AutenticarSistema()
        {
            bool usuarioLogado = false;

            do
            {
                IA.iBank("Por gentileza, digite seu usuário:");
                var usuario = Console.ReadLine()!;
                IA.iBank("Agora digite a senha por favor:");
                var senha = LerSenha()!;

                foreach (var linha in credenciais)
                {
                    if (usuario == linha.Split(':')[0] && senha == linha.Split(':')[1])
                    {
                        IA.iBank("Acesso Permitido", ConsoleColor.Green);
                        usuarioLogado = true;
                        break;
                    }
                }
                if (!usuarioLogado) IA.iBank("Usuário ou Senha inválido", ConsoleColor.Red);
            } while (!usuarioLogado);
            return usuarioLogado;
        }
        private static void ListarContas()
        {
            Console.Clear();
            MostrarTitulos(TitlesMenu.clientes, ConsoleColor.DarkMagenta);

            int idConta = clientes.Length - (clientes.Length - 1);
            foreach (var linha in clientes)
            {
                System.Console.WriteLine($"ID: {idConta} | Titular: {linha.Split(':')[0]} | CPF: {linha.Split(':')[1]} | Saldo: {linha.Split(':')[3]:C2}");
                idConta++;
            }
            System.Console.WriteLine();
        }



        private static ContaCliente ListarContas(string cpfCliente)
        {
            Console.Clear();
            MostrarTitulos(TitlesMenu.detalhesDaConta, ConsoleColor.DarkBlue);

            return BuscarCliente(cpfCliente);
        }

        private static ContaCliente BuscarCliente(string cpfCliente)
        {
            int idConta = 1;

            foreach (var linha in clientes)
            {
                if (linha.Contains(cpfCliente))
                {
                    var nomeCliente = linha.Split(':')[0];
                    var CPF = linha.Split(':')[1];
                    var senhaCliente = linha.Split(":")[2];
                    double saldo = double.Parse(linha.Split(":")[3]);

                    if (acessouTransferenciaPix)
                    {
                        System.Console.WriteLine($"Titular: {nomeCliente} | CPF: {CPF}");
                        ContaCliente contaCliente = new ContaCliente(nomeCliente, CPF, senhaCliente, saldo);
                        return contaCliente;
                    }
                    else
                    {
                        System.Console.WriteLine($"ID: {idConta} | Titular: {nomeCliente} | CPF: {CPF} | Saldo: {saldo:C2}");
                        ContaCliente contaCliente = new ContaCliente(nomeCliente, CPF, senhaCliente, saldo);
                        System.Console.WriteLine();
                        return contaCliente;
                    }

                }
                idConta++;
            }
            System.Console.WriteLine();
            return null!;
        }

        private static bool VerificarCPF(string cpfCliente)
        {
            cpfCliente = ValidarCPF(cpfCliente);

            foreach (var linha in clientes)
            {
                if (linha.Split(':')[1].Equals(cpfCliente))
                {
                    IA.iBank("Olha aqui... Encontrei o CPF digitado...\n");

                    if (acessouDetalhesDaConta)
                    {
                        return acessouDetalhesDaConta;
                    }
                    else
                    {
                        MostrarSubMenuAbrirConta();
                    }
                }
            }
            return false;
        }

        private static void NaoEncontrouCPF(bool encontrouCPF)
        {
            if (!encontrouCPF)
            {
                IA.iBank("Vixii, não encontramos o CPF digitado, o que você fará?", ConsoleColor.Red);
                MostrarSubMenuAbrirConta();
            }
            System.Console.WriteLine();
        }

        private static void MostrarSubMenuAbrirConta()
        {
            do
            {
                IA.iBank("O que deseja fazer?\n");

                System.Console.WriteLine("1 - Abrir uma nova para cliente");
                System.Console.WriteLine("2 - Detalhar conta");
                System.Console.WriteLine("3 - Voltar ao Menu Inicial");
                System.Console.WriteLine("0 - Sair do Sistema ByteBank\n");

                IA.iBank("Digite o número da opção:");

                switch (Console.ReadLine())
                {
                    case "1":
                        AbrirConta();
                        break;

                    case "2":
                        DetalharConta();
                        break;

                    case "3":
                        Console.Clear();
                        SelecionarMenu(MostrarMenu());
                        break;

                    case "0":
                        SairSistemaByteBank();
                        break;

                    default:
                        Console.Clear();
                        IA.iBank("Opss, o valor digitado é inválido, por favor selecione uma das opções disponíveis.", ConsoleColor.Red);
                        break;
                }
            } while (!acessouDetalhesDaConta);
        }

        public static void MostrarCapitalByteBank()
        {
            Console.Clear();
            MostrarTitulos(TitlesMenu.capital, ConsoleColor.DarkYellow);

            AtualizarClientes();

            double capitalByteBank = 0;
            foreach (var linha in clientes)
            {
                capitalByteBank += double.Parse(linha.Split(':')[3]);
            }
            IA.iBank($"Nosso Capital de Giro esta acumulado em {capitalByteBank:C2}\n");
        }

        public static int MostrarMenu()
        {

            MostrarTitulos(TitlesMenu.opcaoMenu, ConsoleColor.White);

            IA.iBank("O que deseja fazer?\n");

            System.Console.WriteLine("1 - Abrir uma nova conta para cliente");
            System.Console.WriteLine("2 - Listar todas as contas registradas");
            System.Console.WriteLine("3 - Acessar uma conta");
            System.Console.WriteLine("4 - Consultar Capital de Giro do ByteBank");
            System.Console.WriteLine("5 - Realizar uma operação de Saque/Deposito ou Transferência");
            System.Console.WriteLine("0 - Sair do Sistema ByteBank\n");

            IA.iBank("Digite o número da opção:");

            string entradaUsuario = Console.ReadLine()!;

            if (int.TryParse(entradaUsuario, out int opcaoMenu))
                return opcaoMenu;
            else return -1;
        }

        public static void AbrirConta()
        {
            Console.Clear();
            InterfaceDoSistema.MostrarTitulos(TitlesMenu.novaConta, ConsoleColor.DarkGreen);
            acessouDetalhesDaConta = false;

            IA.iBank("OK, vamos abrir uma nova conta\n");

            AtualizarClientes();

            IA.iBank("Por gentileza, digite o CPF do titular da conta:");
            string cpfCliente = Console.ReadLine()!;
            
            if (!VerificarCPF(cpfCliente))
            {
                if (acessouDetalhesDaConta) return;

                cpfCliente = ValidarCPF(cpfCliente);

                IA.iBank("Obrigado, agora digite o nome completo do titular.");
                string nomeCliente = Console.ReadLine()!.ToUpper().Trim();
                
                while (!VerificarNomeCliente(nomeCliente))
                {
                    IA.iBank("Eii, isso não me parece um nome válido, por gentileza digite seu nome de verdade por completo.", ConsoleColor.Red);
                    nomeCliente = Console.ReadLine()!.ToUpper();
                }
                System.Console.WriteLine();

                IA.iBank("Muito bom!! xD, e para finalizar...");

                string senhaCliente = "";
                string confirmaSenha = "";

                do
                {
                    IA.iBank("digite uma senha com no mínimo 6 caracteres.");
                    senhaCliente = LerSenha()!;


                    while (!VerificarSenha(senhaCliente))
                    {
                        IA.iBank("Opa, por questões de segurança é melhor adicionarmos outra senha:", ConsoleColor.Red);
                    }

                    IA.iBank("Repita a senha para confirmar.");
                    confirmaSenha = LerSenha()!;

                    if (senhaCliente != confirmaSenha) IA.iBank("Bahhh Tchee, as senhas não conferem", ConsoleColor.Magenta);

                } while (senhaCliente != confirmaSenha);

                System.Console.WriteLine();

                IA.iBank("Digite o valor do seu primeiro depósito, caso não queira digite 0");
                string valorDeposito = Console.ReadLine()!;

                while (!ValidarDeposito(valorDeposito))
                {
                    IA.iBank("Eita, alguma coisa deu errado, digite um valor válido.", ConsoleColor.DarkRed);
                    valorDeposito = Console.ReadLine()!;
                }

                ContaCliente contaCliente = new ContaCliente(nomeCliente, cpfCliente, senhaCliente, double.Parse(valorDeposito));

                StreamWriter clientesStream = new StreamWriter("./data/clientes.txt", true);

                if (clientes.Length > 0)
                {
                    clientesStream.WriteLine();
                    clientesStream.Write($"{contaCliente.Titular}:{contaCliente.Cpf}:{contaCliente.Senha}:{contaCliente.Saldo:F2}");
                }
                else
                {
                    clientesStream.Write($"{contaCliente.Titular}:{contaCliente.Cpf}:{contaCliente.Senha}:{contaCliente.Saldo:F2}");
                }
                clientesStream.Close();

                IA.iBank("Abertura de conta realizada com sucesso\n", ConsoleColor.Green);

                MostrarSubMenuAbrirConta();
            }
        }

        private static string ValidarCPF(string cpfCliente)
        {
            while (!IsCPF(cpfCliente))
            {
                IA.iBank("Humm, CPF inválido, por favor digite um CPF real.", ConsoleColor.Red);
                cpfCliente = Console.ReadLine()!;
            }

            return cpfCliente;
        }

        private static bool ValidarDeposito(string valorDeposito)
        {
            if (!double.TryParse(valorDeposito, out _)) return false;

            double valor = double.Parse(valorDeposito);

            if (double.IsNegativeInfinity(valor)) return false;

            if (double.IsNegative(valor)) return false;

            if (double.IsNaN(valor)) return false;

            return true;
        }

        private static bool VerificarSenha(string senhaCliente)
        {
            if (senhaCliente.Length < 6) return false;

            if (string.IsNullOrEmpty(senhaCliente)) return false;

            return true;
        }

        private static bool VerificarNomeCliente(string nomeCliente)
        {
            if (nomeCliente.Length < 8) return false;

            if (string.IsNullOrEmpty(nomeCliente)) return false;

            if (!nomeCliente.Contains(" ")) return false;

            return true;
        }

        private static bool IsCPF(string cpfCliente)
        {
            // Remove os caracteres de formatação
            cpfCliente = cpfCliente.Replace(".", "").Replace("-", "");

            // Caso seja nulo ou vazio
            if (string.IsNullOrEmpty(cpfCliente)) return false;

            // Verifica se o CPF tem 11 dígitos
            if (cpfCliente.Length != 11) return false;

            // Verifica se comtem apenas números no CPF
            if (!long.TryParse(cpfCliente, out _)) return false;

            // Verifica se todos os digitos são iguais
            for (int i = 0; i < 10; i++)
            {
                if (new string(cpfCliente[i], 11) == cpfCliente) return false;
            }

            int somaDoCPF = 0;

            for (int i = 0; i < 9; i++)
            {
                somaDoCPF += int.Parse((cpfCliente[i]).ToString()) * (10 - i);
            }

            int primeiroDigito = somaDoCPF % 11;
            primeiroDigito = primeiroDigito < 2 ? 0 : 11 - primeiroDigito;

            // Se o valor que calculamos que esta armazenado na variavel primeiroDigito for != do priemeiro fornecido pelo usario retorne falso
            if (int.Parse(cpfCliente[9].ToString()) != primeiroDigito) return false;

            somaDoCPF = 0;

            for (int i = 0; i < 10; i++)
            {
                somaDoCPF += int.Parse(cpfCliente[i].ToString()) * (11 - i);
            }

            int segundoDigito = somaDoCPF % 11;
            segundoDigito = segundoDigito < 2 ? 0 : 11 - segundoDigito;

            if (int.Parse(cpfCliente[10].ToString()) != segundoDigito) return false;

            return true;
        }

        public static void SelecionarMenu(int opcaoMenu)
        {
            switch (opcaoMenu)
            {
                case 1:
                    AbrirConta();
                    break;
                case 2:
                    ListarContas();
                    SelecionarMenu(MostrarMenu());
                    break;
                case 3:
                    DetalharConta();
                    break;
                case 4:
                    MostrarCapitalByteBank();
                    SelecionarMenu(MostrarMenu());
                    break;
                case 5:
                    System.Console.WriteLine("Realizou uma operacao");
                    break;
                case 0:
                    SairSistemaByteBank();
                    break;
                default:
                    Console.Clear();
                    IA.iBank("Opss, o valor digitado é inválido, por favor selecione uma das opções disponíveis.\n", ConsoleColor.Red);
                    SelecionarMenu(MostrarMenu());
                    break;
            }
        }

        private static void SairSistemaByteBank()
        {
            Console.Clear();

            IA.iBank("Obrigado por utilizar nossos serviços.", ConsoleColor.Magenta);

            MostrarTitulos(TitlesMenu.logo, ConsoleColor.DarkCyan);

            Thread.Sleep(1500);
            Environment.Exit(0);
        }

        public static void CarregarSistema()
        {
            IA.iBank("Olá, eu sou o iBank, seu assiste virtual, serei o responsável por ajuda-lo a utilizar nosso sistema. Seja Bem-Vindo ao");
            MostrarTitulos(TitlesMenu.logo, ConsoleColor.DarkCyan);
        }

        private static void MostrarTitulos(string title, ConsoleColor color)
        {
            string[] logoString = title.Split(Environment.NewLine);

            Console.ForegroundColor = color;

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(logoString[i]);
                Thread.Sleep(100 - i * 6);
            }

            Console.ResetColor();
        }

        public static string LerSenha()
        {
            List<char> senha = new List<char>();
            while (true)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (tecla.Key == ConsoleKey.Backspace)
                {
                    int posicaoX = Console.CursorLeft;
                    int posicaoY = Console.CursorTop;

                    if (senha.Count() > 0)
                    {
                        Console.SetCursorPosition(posicaoX - 1, posicaoY);
                        Console.Write(" ");
                        Console.SetCursorPosition(posicaoX - 1, posicaoY);
                        Console.Write("");
                        senha.RemoveAt(senha.Count() - 1);
                    }
                }
                else
                {
                    senha.Add(tecla.KeyChar);
                    Console.Write("*");
                }
            }
            System.Console.WriteLine();
            return string.Join("", senha);
        }

        private static void DetalharConta()
        {
            Console.Clear();
            AtualizarClientes();
            acessouDetalhesDaConta = true;

            IA.iBank(@"Digite o CPF do titular da conta, ~/ Per Favore \~");

            cpfCliente = ValidarCPF(Console.ReadLine()!);

            if (!VerificarCPF(cpfCliente))
            {
                Console.Clear();
                IA.iBank("Vixii, não encontramos o CPF digitado...", ConsoleColor.Red);
                MostrarSubMenuAbrirConta();
            }
            var contaCliente = ListarContas(cpfCliente);
            MostrarSubMenuContaDetalhada(contaCliente);
            AtualizarConta(contaCliente);
        }

        private static void MostrarSubMenuContaDetalhada(ContaCliente contaCliente)
        {
            do
            {
                IA.iBank("O que deseja fazer?\n");

                System.Console.WriteLine("1 - Sacar");
                System.Console.WriteLine("2 - Depositar");
                System.Console.WriteLine("3 - Transferir via Pix");
                System.Console.WriteLine("4 - Voltar ao Menu Inicial");
                System.Console.WriteLine("0 - Sair do Sistema ByteBank\n");

                IA.iBank("Digite o número da opção:");

                switch (Console.ReadLine())
                {
                    case "1":
                        IA.iBank("Sacar uma quantia, entendi, para isso digite um valor:");
                        contaCliente.Sacar(double.Parse(Console.ReadLine()!));
                        IA.BarraCarregamento(200);
                        IA.iBank("Saque efetuado com sucesso !!\n", ConsoleColor.Green);
                        break;

                    case "2":
                        IA.iBank("Perfeito, qual o valor deseja depositar?");
                        contaCliente.Depositar(double.Parse(Console.ReadLine()!));
                        IA.BarraCarregamento(200);
                        IA.iBank("Depósito realizado com sucesso !!\n", ConsoleColor.Green);
                        break;

                    case "3":
                        IA.iBank("Muito bom, para realizar um pix preciso de algumas informações...");
                        TranferirViaPix(contaCliente);
                        break;

                    case "4":
                        Console.Clear();
                        SelecionarMenu(MostrarMenu());
                        break;

                    case "0":
                        SairSistemaByteBank();
                        break;

                    default:
                        Console.Clear();
                        IA.iBank("Opss, o valor digitado é inválido, por favor selecione uma das opções disponíveis.\n", ConsoleColor.Red);
                        break;
                }
            } while (!acessouDetalhesDaConta);
        }

        private static void TranferirViaPix(ContaCliente contaCliente)
        {
            AtualizarClientes();
            acessouTransferenciaPix = true;

            IA.iBank("Digite o CPF do beneficiado");
            string cpfBeneficiado = ValidarCPF(Console.ReadLine()!);
            ContaCliente contaBeneficiado = BuscarCliente(cpfBeneficiado);

            if (!VerificarCPF(cpfBeneficiado))
            {
                Console.Clear();
                do
                {
                    IA.iBank("Vixii, não encontramos o CPF digitado...\n", ConsoleColor.Red);
                    System.Console.WriteLine("1 - Tentar transferência em outra conta");
                    System.Console.WriteLine("2 - Voltar ao menu da sua conta");
                    System.Console.WriteLine("0 - Sair do Sistema ByteBank");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            TranferirViaPix(contaCliente);
                            break;

                        case "2":
                            MostrarSubMenuContaDetalhada(contaCliente);
                            break;

                        case "0":
                            SairSistemaByteBank();
                            break;

                        default:
                            IA.iBank("Opss, o valor digitado é inválido, por favor selecione uma das opções disponíveis.", ConsoleColor.Red);
                            acessouDetalhesDaConta = false;
                            break;
                    }
                } while (!acessouDetalhesDaConta);
            }

            IA.iBank("Digite o valor da transferência");
            string valorTransferencia = Console.ReadLine()!;
            double valorTransferido = 0;

            while (!double.TryParse(valorTransferencia, out valorTransferido))
            {
                IA.iBank("Alguma coisa de errada, não esta certo, por gentileza, digite um valor válido ou 0 para cancelar", ConsoleColor.Red);

                if (valorTransferido == 0)
                {
                    MostrarMenu();
                }
            }

            contaCliente.Sacar(valorTransferido);
            AtualizarConta(contaCliente);
            contaBeneficiado.Depositar(valorTransferido);
            AtualizarConta(contaBeneficiado);

            IA.BarraCarregamento(100);

            IA.iBank("Tranferência Realizada com sucesso", ConsoleColor.Green);
            MostrarSubMenuContaDetalhada(contaCliente);
        }

        private static void AtualizarConta(ContaCliente contaCliente)
        {

            // String na qual faremos a verificação das linhas do registro
            string? registro = "";

            // Criação dos objeto que iremos manipular
            StreamReader clientesRegistrado = new StreamReader("./data/clientes.txt");
            StreamWriter clientesAtualizado = new StreamWriter("./data/temporario.txt");

            // Enquanto ouver linhas para ler no clientesRegistrado ele efetuara o loop
            while ((registro = clientesRegistrado.ReadLine()) != null)
            {

                // Se linha do registro conter o CPF do cliente
                if (registro.Contains(contaCliente.Cpf))
                {
                    // Reescrevera o registro
                    registro = $"{contaCliente.Titular}:{contaCliente.Cpf}:{contaCliente.Senha}:{contaCliente.Saldo:F2}";
                }

                // Continua reescrevendo os registro que não foram alterados
                if (clientesRegistrado.EndOfStream)
                {
                    clientesAtualizado.Write(registro);
                }
                else
                {
                    clientesAtualizado.WriteLine(registro);
                }

            }
            // Salva os arquivos
            clientesAtualizado.Close();
            clientesRegistrado.Close();

            // Exclui o registro antigo
            File.Delete("./data/clientes.txt");

            // Renomeia o arquivo temporario
            File.Move("./data/temporario.txt", "./data/clientes.txt");

            //Remove a ultima linha            
            AtualizarClientes();

            MostrarSubMenuContaDetalhada(contaCliente);
        }

    }
}