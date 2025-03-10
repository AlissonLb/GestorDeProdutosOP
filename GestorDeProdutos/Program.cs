using GestorDeProdutos.Classes;
using GestorDeProdutos.Interfaces;
using System.Text.Json;

class Program
{
    public static List<IProduto> produtos = new List<IProduto>();

    public static void Main(string[] args)
    {
  
        bool sair = false;
        Console.WriteLine("Gestor De Produtos");
        Console.WriteLine("Quer Cadastrar Um Produto?");
        Console.WriteLine("1-Sim\n2-Não");
        string option = Console.ReadLine();
        int option2 = Convert.ToInt32(option);
        if (option2 == 1)
        {
            Cadastro();
        }
        else
        {
            sair = true;
        }
    }

    static void Cadastro()
    {
        Carregar();
        bool sair = false;
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("Cadastro De Produtos");
            Console.WriteLine("OPÇÃO:\n1-Produto Fisico\n2-Produto Online\n3-Lista De Produtos\n4-Registrar Entradas\n5-Registrar Saida\n6-Deletar Produto\n7-Sair");
            int opt = Convert.ToInt32(Console.ReadLine());

            if (opt < 1 || opt > 7)
            {
                Console.WriteLine("Digite Uma Opção valida");
                continue;
            }

            switch (opt)
            {
                case 1:
                    ProdutoFisico();
                    break;

                case 2:
                    ProdutoOnline();
                    break;

                case 3:
                    ListarProdutos();
                    break;

                case 4:
                    RegistrarEntrada();
                    break;

                case 5:
                    RegistrarSaida();
                    break;
                case 6:
                    DeletarProduto();
                    break;
                case 7:
                    sair = true;
                    break;
            }
        }
    }

    static void ProdutoFisico()
    {

        Console.WriteLine("Cadastro De Produto Fisico");
        Console.WriteLine("Nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Preço: ");
        double preco = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Estoque");
        int estoque = Convert.ToInt32(Console.ReadLine());
        ProdutoFisico prodFisico = new ProdutoFisico(nome, preco, estoque);
        produtos.Add(prodFisico);
        Salvar();

    }

    static void ProdutoOnline()
    {
        Console.WriteLine("Cadastro De Produto Online");
        Console.WriteLine("Nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Preço: ");
        double preco = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Autor");
        string autor = Console.ReadLine();
        ProdutoOnline prodOnline = new ProdutoOnline(nome, preco, autor);
        produtos.Add(prodOnline);
        Salvar();
    }

    static void RegistrarEntrada()
    {
        ListarProdutos();
        Console.WriteLine("Digite id do Produto que quer adicionar");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id >= 0 && id < produtos.Count)
        {
            produtos[id].Entrada();
            Salvar();
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void RegistrarSaida()
    {
        ListarProdutos();
        Console.WriteLine("Digite id do Produto que quer registrar saida");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id >= 0 && id < produtos.Count)
        {
            produtos[id].Saida();
            Salvar();
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void ListarProdutos()
    {
        if (produtos.Count > 0)
        {
            Console.WriteLine("LISTA DE PRODUTOS");
            Console.WriteLine("-----------------");
            int id = 0;
            // Exibe todos os produtos com o ID e detalhes
            foreach (IProduto produto in produtos)
            {
                Console.WriteLine($"ID: {id}");
                produto.Exibir();
                Console.WriteLine();
                id++;
            }
        }
        else
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        Console.ReadKey();
    }
    static void DeletarProduto()
    {
        ListarProdutos();
        Console.WriteLine("Digite Id Do Produto para remover");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id <=0 && id < produtos.Count)
        {
            produtos.RemoveAt(id);
            Console.WriteLine("Produto removido com sucesso !!!");
            Salvar();
            
        }
        
    }

    static void Salvar()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("produtos.txt"))
            {
                foreach (var produto in produtos)
                {
                    if (produto is ProdutoFisico prodFisico)
                    {
                    
                        writer.WriteLine($"{prodFisico.Nome};{prodFisico.Preco};{prodFisico.Frete}");
                    }
                    else if (produto is ProdutoOnline prodOnline)
                    {
                        // Salva como uma linha: Nome;Preço;Autor
                        writer.WriteLine($"{prodOnline.Nome};{prodOnline.Preco};{prodOnline.Autor}");
                    }
                }
            }

            Console.WriteLine("Produtos salvos com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar produtos: {ex.Message}");
        }
    }




    static void Carregar()
    {
        try
        {
            if (File.Exists("produtos.txt"))
            {
                string[] linhas = File.ReadAllLines("produtos.txt");

                produtos.Clear(); // Limpar a lista de produtos antes de adicionar os novos produtos

                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');

                    if (dados.Length == 3) // ProdutoFisico
                    {
                        string nome = dados[0];
                        double preco = Convert.ToDouble(dados[1]);
                        int estoque = Convert.ToInt32(dados[2]);
                        ProdutoFisico prodFisico = new ProdutoFisico(nome, preco, estoque);
                        produtos.Add(prodFisico);
                    }
                    else if (dados.Length == 3) // ProdutoOnline
                    {
                        string nome = dados[0];
                        double preco = Convert.ToDouble(dados[1]);
                        string autor = dados[2];
                        ProdutoOnline prodOnline = new ProdutoOnline(nome, preco, autor);
                        produtos.Add(prodOnline);
                    }
                }

                Console.WriteLine("Produtos carregados com sucesso!");
                Console.WriteLine($"Total de produtos carregados: {produtos.Count}");
                foreach (var produto in produtos)
                {
                    produto.Exibir();  // Exibe os produtos carregados
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar arquivo: {ex.Message}");
        }
    }
}