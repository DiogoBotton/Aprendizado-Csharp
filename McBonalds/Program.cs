﻿using System;
using System.Collections.Generic;
using McBonalds.Models;

namespace McBonalds {
    class Program {
        static void Main (string[] args) {
            //FEITO: Sistema de coleções para cadastro de clientes (mais de um)

            //TODO: Login ADM, classe PRODUTOS que terá hamburgueres e shakes, que terão seus subprodutos (hamburguer vegano, shake de chocolate, etc), e classe pedidos(?)
            //PROBLEMA: Se o programa for salvo em csv, sempre vai acrescentar à lista de clientes mais uma conta ADMIN.
            List<Cliente> listClientes = new List<Cliente> () { new Cliente ("admin", "admin") };
            //TODO: Pergunta: o ADM pode estar na lista de CLIENTES??
            Queue<Pedido> pedidos = new Queue<Pedido> ();

            int indexList = 0;
            bool querSair = false;
            bool fezLogin = false;
            do {
                Console.Clear ();

                System.Console.WriteLine ("Bem Vindo á Hamburgueria McBonalds!!!");
                System.Console.WriteLine ("Digite uma das opções abaixo:");
                System.Console.WriteLine ("1 - Criar Cadastro.");
                System.Console.WriteLine ("2 - Fazer Login");
                System.Console.WriteLine ("3 - Visualizar produtos.");
                System.Console.WriteLine ("0 - Sair.");
                string opcao = Console.ReadLine ();

                switch (opcao) {
                    case "1":
                        CriarCadastro (listClientes);
                        break;

                    case "2":
                        fezLogin = FazerLogin (listClientes, out indexList);
                        //TODO: Visualização de pedidos.
                        if (fezLogin) {
                            //*Provaveis problemas futuros na gravação do programa em arquivo CSV nesta condição.
                            if (indexList != 0 && indexList > 0) {
                                #region Menu Cliente Logado.

                                Cliente usuario = listClientes[indexList];
                                Pedido pedidosUsuario = new Pedido (usuario);

                                List<Pedido> listPedidoUsuario = new List<Pedido> ();

                                bool saiuDaConta = false;
                                bool repetirProcesso = false;
                                do {
                                    Console.Clear ();

                                    System.Console.WriteLine ($"Olá, {usuario.Nome}! Seja Bem Vindo ");
                                    System.Console.WriteLine ("Escolha uma das opções abaixo:");
                                    System.Console.WriteLine ("1 - Fazer um pedido.");
                                    System.Console.WriteLine ("2 - Adicionar saldo na carteira.");
                                    System.Console.WriteLine ("0 - Sair da Conta.");
                                    string opcoesLogado = Console.ReadLine ();

                                    int opcoesPedido = 0;
                                    bool compraConcluida = false;
                                    switch (opcoesLogado) {
                                        case "1":
                                            do {
                                                do {

                                                    Console.Clear ();
                                                    System.Console.WriteLine ("O que você deseja pedir? Digite o código.");
                                                    System.Console.WriteLine ("1- Pedir Hamburgueres.");
                                                    System.Console.WriteLine ("2- Pedir Shakes.");
                                                    opcoesPedido = Convert.ToInt32 (Console.ReadLine ());
                                                } while (opcoesPedido < 1 || opcoesPedido > 2);
                                                //TODO PERGUNTA: COMO IRÁ PEDIR MAIS DE UM PRODUTO POR PEDIDO?
                                                //TODO: ACRESCENTAR + UM PEDIDO CASO CLIENTE DESEJAR MAIS ALGUM PRODUTO.
                                                compraConcluida = FazerPedido (opcoesPedido, usuario, pedidosUsuario, out repetirProcesso);
                                            } while (repetirProcesso);

                                            if (compraConcluida) {
                                                Console.Clear ();

                                                System.Console.WriteLine ("Sua compra foi realizada com sucesso!");
                                                ExibirPedido (pedidosUsuario);
                                                System.Console.WriteLine ($"Seu novo saldo na carteira é: R$ {usuario.Carteira}.");
                                                Console.ReadLine ();
                                                listPedidoUsuario.Add (pedidosUsuario);
                                            } else {
                                                Console.Clear ();

                                                System.Console.WriteLine ("Não foi possível realizar a compra, você não possúi saldo suficiente na carteira McBonalds.");
                                                System.Console.WriteLine ($"Seu saldo na carteira: R$ {usuario.Carteira}.");
                                                Console.ReadLine ();
                                            }
                                            //TODO: ZERAR variavel QTD em todos os hamburgueres e shakes.

                                            pedidosUsuario.FinalizarPedido ();
                                            break;

                                        case "2":
                                            Console.Clear ();

                                            bool depositoRealizado = false;

                                            System.Console.Write ("Digite o valor que será depositado na carteira McBonalds: ");
                                            double valor = Convert.ToInt32 (Console.ReadLine ());

                                            depositoRealizado = usuario.AdcSaldoCarteira (valor);

                                            if (depositoRealizado) {
                                                System.Console.WriteLine ($"Foi depositado [R$ {valor}] na sua carteira.");
                                                System.Console.WriteLine ($"Seu novo saldo na carteira é: R$ {usuario.Carteira}.");

                                                Console.ReadLine ();
                                            } else {
                                                System.Console.WriteLine ("Não foi possível fazer o deposito na carteira McBonalds.");
                                                System.Console.WriteLine ("Verifique se você utilizou de números negativos ou nulos.");

                                                Console.ReadLine ();
                                            }

                                            break;

                                        case "0":
                                            System.Console.WriteLine ($"Até mais {usuario.Nome}, volte sempre!");
                                            System.Console.WriteLine ("Você deslogou.");
                                            Console.ReadLine ();

                                            saiuDaConta = true;
                                            break;

                                        default:
                                            System.Console.WriteLine ("Comando Inválido.");
                                            break;
                                    }

                                } while (!saiuDaConta);
                                #endregion
                            } else {
                                #region Menu ADMIN

                                Cliente admin = listClientes[indexList];

                                bool saiuDaConta = false;

                                do {
                                    Console.Clear ();
                                    //Ideias: possibilidade de acrescentar à lista um novo lanche ou Shake.,
                                    //Enviar ao cliente uma MSG (nos meus pedidos) se foi aceito ou não.
                                    //Perguntas: Como que irá aceitar um pedido?
                                    System.Console.WriteLine ($"Conta ADMIN:[{admin.Nome}], DashBoard ADM. ");
                                    System.Console.WriteLine ("Escolha uma das opções abaixo:");
                                    System.Console.WriteLine ("1 - Pedidos.");
                                    System.Console.WriteLine ("2 - Visualizar lista de clientes");
                                    System.Console.WriteLine ("3 - .");
                                    System.Console.WriteLine ("0 - Sair da Conta.");
                                    string opcoesAdm = Console.ReadLine ();

                                    switch (opcoesAdm) {
                                        case "1":
                                            break;

                                        case "2":
                                            break;

                                        case "0":
                                            saiuDaConta = true;
                                            break;

                                        default:
                                            System.Console.WriteLine ("Comando Inválido.");
                                            break;
                                    }
                                } while (!saiuDaConta);
                                #endregion
                            }
                        }
                        break;

                    case "3":
                        #region Menu de visualização de produtos.

                        bool sairViewProdutos = false;
                        do {
                            Console.Clear ();

                            System.Console.WriteLine ("Escolha uma das opções abaixo:");
                            System.Console.WriteLine ("1 - Hamburgueres.");
                            System.Console.WriteLine ("2 - Shakes.");
                            System.Console.WriteLine ("0 - Sair do menu de visualização.");
                            string opcaoView = Console.ReadLine ();
                            switch (opcaoView) {
                                case "1":
                                    ExibirMenuHamburgueres (out int HamburguerCount);
                                    System.Console.WriteLine ("Para comprar algum produto, você deve estar cadastrado e logado.");
                                    Console.ReadLine ();

                                    break;

                                case "2":
                                    ExibirMenuShakes (out int ShakeCount);
                                    System.Console.WriteLine ("Para comprar algum produto, você deve estar cadastrado e logado.");
                                    Console.ReadLine ();

                                    break;

                                case "0":
                                    sairViewProdutos = true;
                                    break;

                                default:
                                    System.Console.WriteLine ("Comando Inválido.");
                                    break;
                            }
                        } while (!sairViewProdutos);

                        #endregion
                        break;

                    case "0":
                        querSair = true;
                        break;

                    default:
                        System.Console.WriteLine ("Comando Inválido.");
                        break;
                }

            } while (!querSair);

        }
        public static void CriarCadastro (List<Cliente> listClientes) {
            bool nomeJaExiste = false;
            string nome = "";

            do {
                Console.WriteLine ("Digite seu nome:");
                nome = Console.ReadLine ();

                foreach (Cliente item in listClientes) {

                    if (item.Nome == nome) {
                        System.Console.WriteLine ("Este nome já existe, tente novamente.");
                        nomeJaExiste = true;
                        break;
                    } else {
                        nomeJaExiste = false;
                    }

                }
            } while (nomeJaExiste);

            Console.WriteLine ("Digite sua data de nascimento:");
            DateTime data = Convert.ToDateTime (Console.ReadLine ());
            Console.WriteLine ("Digite seu endereço:");
            string endereco = Console.ReadLine ();
            Console.WriteLine ("Digite seu telefone:");
            int tel = Convert.ToInt32 (Console.ReadLine ());
            Console.WriteLine ("Digite seu email:");
            string email = Console.ReadLine ();
            Console.WriteLine ("Digite seu CPF/CNPJ:");
            int cpf = Convert.ToInt32 (Console.ReadLine ());

            Cliente cliente = new Cliente (nome, tel, email, cpf);
            cliente.dataNascimento = data;
            cliente.Endereco = endereco;

            bool trocouSenha = false;

            do {
                Console.WriteLine ("Digite uma senha:");
                string senha = Console.ReadLine ();
                trocouSenha = cliente.TrocarSenha (senha);

                if (!trocouSenha) {
                    System.Console.WriteLine ("Digite uma senha entre 6 e 16 caracteres.");
                } else {
                    System.Console.WriteLine ("Sua conta foi cadastrada com sucesso.");
                    Console.ReadLine ();
                }
            } while (!trocouSenha);

            listClientes.Add (cliente);

        }
        public static bool FazerLogin (List<Cliente> listClientes, out int indexList) {
            bool nomeExiste = false;
            bool validacaoSenha = false;
            bool contaAdmin = false;
            int index = 0;

            System.Console.Write ("Digite seu nome: ");
            string nome = Console.ReadLine ();

            foreach (Cliente item in listClientes) {
                if (item.Nome == nome) {
                    nomeExiste = true;
                    if (item.Nome == "admin") {
                        contaAdmin = true;
                    } else {
                        contaAdmin = false;
                    }
                    break;
                } else {
                    nomeExiste = false;
                }
                index++;
            }

            System.Console.Write ("Digite sua senha: ");
            string senha = Console.ReadLine ();

            foreach (Cliente item in listClientes) {
                if (item.Senha == senha) {
                    validacaoSenha = true;
                    break;
                } else {
                    validacaoSenha = false;
                }
            }

            if (!contaAdmin) {
                if (nomeExiste && validacaoSenha) {
                    Cliente conta = listClientes[index];
                    System.Console.WriteLine ($"Olá, {conta.Nome}! Você logou com sucesso!");
                    System.Console.WriteLine ($"Você tem R${conta.Carteira} de saldo na sua carteira McBonalds. ");
                    indexList = index;
                    Console.ReadLine ();
                    return true;
                } else {
                    System.Console.WriteLine ("Nome ou senha inválidos.");
                    indexList = -1;
                    Console.ReadLine ();
                    return false;
                }
            } else {
                if (validacaoSenha) {

                    System.Console.WriteLine ("Você entrou com uma Conta ADMIN.");
                    indexList = index;
                    Console.ReadLine ();
                    return true;
                } else {
                    System.Console.WriteLine ("Senha ADMIN incorreta.");
                    indexList = -1;
                    Console.ReadLine ();
                    return false;
                }
            }

        }
        public static void ExibirMenuHamburgueres (out int HamburguerCount) {
            Console.Clear ();
            var hamburgueres = Produto.listHamburgueres;
            int codigo = 1;

            System.Console.WriteLine ("################################");
            System.Console.WriteLine ("#                            #");
            System.Console.WriteLine ("#        Hambúrgueres        #");
            System.Console.WriteLine ("#                            #");
            System.Console.WriteLine ("################################");

            foreach (var hbg in hamburgueres.Values) {
                System.Console.WriteLine ($"  {codigo++}.{hbg.MostrarProduto()}");
            }
            HamburguerCount = hamburgueres.Count;
        }
        public static void ExibirMenuShakes (out int ShakeCount) {
            Console.Clear ();
            var shakes = Produto.listShakes;
            int codigo = 1;

            System.Console.WriteLine ("################################");
            System.Console.WriteLine ("#                            #");
            System.Console.WriteLine ("#           Shakes           #");
            System.Console.WriteLine ("#                            #");
            System.Console.WriteLine ("################################");

            foreach (var shk in shakes.Values) {
                System.Console.WriteLine ($"  {codigo++}.{shk.MostrarProduto()}");
            }
            ShakeCount = shakes.Count;
        }
        public static void ExibirPedido (Pedido pedidosUsuario) {
            foreach (Produto item in pedidosUsuario.produtos) {
                var produto = item;
                if (item.Equals (typeof (HamburguerBacon))) {
                    HamburguerBacon HB = (HamburguerBacon) produto;
                    double preco = HB.Preco * HB.Qtd;
                    System.Console.WriteLine ($"{HB.Nome} [{HB.Qtd}] R$ {preco} ");
                } else if (item.Equals (typeof (HamburguerFurioso))) {
                    HamburguerFurioso HF = (HamburguerFurioso) produto;
                    double preco = HF.Preco * HF.Qtd;
                    System.Console.WriteLine ($"{HF.Nome} [{HF.Qtd}] R$ {preco} ");
                } else if (item.Equals (typeof (HamburguerVegano))) {
                    HamburguerVegano HV = (HamburguerVegano) produto;
                    double preco = HV.Preco * HV.Qtd;
                    System.Console.WriteLine ($"{HV.Nome} [{HV.Qtd}] R$ {preco} ");
                } else if (item.Equals (typeof (ShakeChocolate))) {
                    ShakeChocolate SC = (ShakeChocolate) produto;
                    double preco = SC.Preco * SC.Qtd;
                    System.Console.WriteLine ($"{SC.Nome} [{SC.Qtd}] R$ {preco} ");
                } else if (item.Equals (typeof (ShakeMorango))) {
                    ShakeMorango SM = (ShakeMorango) produto;
                    double preco = SM.Preco * SM.Qtd;
                    System.Console.WriteLine ($"{SM.Nome} [{SM.Qtd}] R$ {preco} ");
                } else if (item.Equals (typeof (ShakeNutella))) {
                    ShakeNutella SN = (ShakeNutella) produto;
                    double preco = SN.Preco * SN.Qtd;
                    System.Console.WriteLine ($"{SN.Nome} [{SN.Qtd}] R$ {preco} ");
                }
                System.Console.WriteLine ($"Total Pago: R$ {pedidosUsuario.totalPago}.");
            }

        }
        public static bool FazerPedido (int opcoesPedido, Cliente usuario, Pedido pedidosUsuario, out bool repetirProcesso) {
            bool compraConcluida = false;
            bool finalizarAcao = false;
            repetirProcesso = false;
            double precoTotal = 0;
            //List<Produto> listPedidoProdutos = new List<Produto> ();
            do {

                switch (opcoesPedido) {
                    case 1:
                        Console.Clear ();
                        int HamburguerCount = 0;

                        int codigoH = 0;
                        do {
                            ExibirMenuHamburgueres (out HamburguerCount);

                            System.Console.WriteLine ("Digite o código do hambúrguer desejado.");
                            codigoH = Convert.ToInt32 (Console.ReadLine ());
                            if (codigoH <= 0 || codigoH > HamburguerCount) {
                                System.Console.WriteLine ("Código Inválido.");
                                Console.ReadLine ();

                            }
                        } while (codigoH <= 0 || codigoH > HamburguerCount);

                        int qtdH = 0;
                        do {

                            System.Console.Write ("Digite a Quantidade: ");
                            qtdH = Convert.ToInt32 (Console.ReadLine ());
                            if (qtdH < 1) {
                                System.Console.WriteLine ("Digite um valor válido.");
                                Console.ReadLine ();
                            }
                        } while (qtdH < 1);

                        var hbg = Produto.listHamburgueres[codigoH];

                        System.Console.WriteLine ("Deseja mais alguma coisa? Responda s / n");
                        string maisPedidosH = Console.ReadLine ();

                        switch (maisPedidosH) {
                            case "s":
                                pedidosUsuario.AdicionarProduto(hbg, qtdH);

                                finalizarAcao = true;
                                repetirProcesso = true;
                                continue;
                            case "n":
                                pedidosUsuario.AdicionarProduto(hbg, qtdH);

                                precoTotal = pedidosUsuario.CalcularPedido ();

                                compraConcluida = usuario.ComprarProduto (precoTotal);

                                finalizarAcao = true;
                                repetirProcesso = false;
                                break;
                            default:
                                System.Console.WriteLine ("Comando Inválido.");
                                break;
                        }
                        break;

                    case 2:
                        Console.Clear ();
                        int ShakeCount = 0;
                        int codigoS = 0;
                        do {
                            ExibirMenuShakes (out ShakeCount);
                            System.Console.WriteLine ("Digite o código do shake desejado.");
                            codigoS = Convert.ToInt32 (Console.ReadLine ());

                            if (codigoS <= 0 || codigoS > ShakeCount) {
                                System.Console.WriteLine ("Código Inválido.");
                                Console.ReadLine ();

                            }
                        } while (codigoS <= 0 || codigoS > ShakeCount);

                        int qtdS = 0;
                        do {

                            System.Console.Write ("Digite a Quantidade: ");
                            qtdS = Convert.ToInt32 (Console.ReadLine ());
                            if (qtdS < 1) {
                                System.Console.WriteLine ("Digite um valor válido.");
                                Console.ReadLine ();
                            }
                        } while (qtdS < 1);

                        var shk = Produto.listShakes[codigoS];

                        System.Console.WriteLine ("Deseja mais alguma coisa? Responda s / n");
                        string maisPedidosSHK = Console.ReadLine ();

                        switch (maisPedidosSHK) {
                            case "s":
                                pedidosUsuario.AdicionarProduto(shk, qtdS);

                                finalizarAcao = true;
                                repetirProcesso = true;
                                continue;
                            case "n":
                                pedidosUsuario.AdicionarProduto(shk, qtdS);

                                precoTotal = pedidosUsuario.CalcularPedido ();

                                compraConcluida = usuario.ComprarProduto (precoTotal);

                                finalizarAcao = true;
                                repetirProcesso = false;
                                break;
                            default:
                                System.Console.WriteLine ("Comando Inválido.");
                                break;
                        }
                        break;
                    default:
                        System.Console.WriteLine ("Comando Inválido.");
                        break;

                }
            } while (!finalizarAcao);
            return compraConcluida;
        }

    }
}