using GestorDeProdutos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeProdutos.Classes
{
    class ProdutoOnline : Produto,IProduto
    {
        public string Autor;
        private double _vendas;

        public ProdutoOnline(string nome, double preco, string autor)
        {
            
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }

        public void Entrada()
        {

            Console.WriteLine($"Registro de Venda de Produto {Nome}");
            Console.WriteLine($"Quantidade: ");
            int entrada = Convert.ToInt32(Console.ReadLine());
            _vendas += entrada;
            Console.WriteLine($"Produto Registrado!!!");
            Console.ReadLine();
        }

        public void Exibir()
        {

            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Preço: {Preco}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Vendas: {_vendas}");
        }

        public void Saida()
        {
            Console.WriteLine($"Registro de venda de Produto {Nome}");
            Console.WriteLine($"Quantidade: ");
            int entrada = Convert.ToInt32(Console.ReadLine());
            _vendas -= entrada;
            Console.WriteLine($"venda registrada");
            Console.ReadLine();
        }
    }
}
