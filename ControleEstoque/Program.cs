using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ControleDeEstoque
{
    public class Produto
    {//campo
        int id;
        string nome;
        int quantidade;

        //propriedade
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set
            {

                if (value >= 0)
                {
                    quantidade = value;
                }
                else
                {
                    Console.WriteLine("Não pode digitar valor negativo");
                    return;
                }
            }
        }


        public Produto(int id, string nome, int quantidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Quantidade = quantidade;
        }

    }


    class Program
    {
        public static List <Produto> inventario = new List<Produto> ();

        static void Main(string[] args)
        {

            bool funcionando = true;
            while (funcionando)
            {
                try
                {
                    //texto do menu principal
                    Console.WriteLine("Bem Vindo ao Sistema de Gestão de Estoque.");
                    Console.WriteLine("1 - Adicionar produto.");
                    Console.WriteLine("2 - Remover produto.");
                    Console.WriteLine("3 - Atualizar quantidade.");
                    Console.WriteLine("4 - Exibir estoque.");
                    Console.WriteLine("5 - Sair.");
                    Console.WriteLine("Digite a opção desejada: ");
                    // input acões
                    int resposta = Convert.ToInt32(Console.ReadLine());

                    switch (resposta)
                    {
                        case 1:
                            AdicionarP();
                            break;
                        case 2:
                            RemoverP();
                            break;
                        case 3:
                            AtualizarEstoque();
                            break;
                        case 4:
                            Exibir();
                            break;
                        case 5:
                            funcionando = false;
                            break;
                        default:
                            Console.WriteLine("Opção invalida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ouve um erro, por favor digite as informações corretamente, o nome do erro é: {ex.Message}");
                    continue;
                }
        
            }

        }

        static void  AdicionarP()
        {

            Console.Clear();
            try
            {
                Console.WriteLine("Digite o nome do produto:");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Tudo Pronto?");
                string resposta2 = Console.ReadLine();
                if (resposta2 == "sim" || resposta2 == "Sim" || resposta2 == "s")
                {
                    int id = inventario.Count;
                    Produto produtos = new Produto(id, nome, quantidade);
                    inventario.Add(produtos);
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ouve um erro, por favor digite as informações corretamente, o nome do erro é: {ex.Message}");
                throw;
                
            }
        }

        static void RemoverP()
        {

            
            try
            {
                Console.WriteLine("Digite: ");
                Console.WriteLine("1 - para remover o produto pela Id");
                Console.WriteLine("2 - para exibir o estoque");
                int resposta3 = Convert.ToInt32(Console.ReadLine());
                
                if(resposta3 == 1)
                {
                    Console.WriteLine("Digite o Id do produto que você deseja remover");
                    int resposta4 = Convert.ToInt32(Console.ReadLine());
                    Produto produto = inventario[resposta4];
                    Console.WriteLine($"Esse produto? \n {produto} ");
                    string resposta5 = Console.ReadLine();
                    if(resposta5 == "sim"|| resposta5 == "Sim"|| resposta5 == "s")
                    {
                        inventario.RemoveAt(resposta4);
                    }
                    else
                    {
                        Console.WriteLine("Cancelado com sucesso ou opção invalida");
                        return;
                    }
                }
                if (resposta3 == 2)
                {
                    Exibir();
                    return;
                }
                else
                {
                    Console.WriteLine("Opção invalida");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ouve um erro, por favor digite as informações corretamente, o nome do erro é: {ex.Message}");
                throw;
            }
            
        }

        static void AtualizarEstoque()
        {
            try
            {
                Console.WriteLine("Digite: ");
                Console.WriteLine("1 - para atualizar a quantidade de um produto.");
                Console.WriteLine("2 - para exibir o estoque.");
                int resposta6 = Convert.ToInt32(Console.ReadLine());

                if (resposta6 == 1)
                {
                    Console.WriteLine("Digite o Id do produto");
                    int resposta7 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite  novo valor de quantidade");
                    int resposta8 = Convert.ToInt32(Console.ReadLine());
                    inventario[resposta7].Quantidade = resposta8;
                    Console.WriteLine("Quantidade alterada com sucesso, Produto com a quantidade atual: ");
                    Console.WriteLine(inventario[resposta7]);
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ouve um erro, por favor digite as informações corretamente, o nome do erro é: {ex.Message}");
                throw;
            }

        }

        static void Exibir()
        {

            Console.Clear();
            Console.WriteLine($"Tem {inventario.Count} itens no inventario.");
            foreach( Produto produtos in inventario)
            {
                Console.WriteLine($"Id: {produtos.Id}\nNome: {produtos.Nome}\nQuantidade: {produtos.Quantidade}");
                
            }
        }
    }

}