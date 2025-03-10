using GestorDeProdutos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeProdutos.Classes
{
    class ProdutoFisico : Produto,IProduto
    {
        public double Frete;
        private int estoque;

       

        public ProdutoFisico(string nome,double preco, double frete)
        {
            
            Nome = nome;
            Preco = preco;
            Frete = frete;

        }

        public void Entrada()
        {   
            Console.WriteLine($"Registro de Entradas de Produto {Nome}");
            Console.WriteLine($"Quantidade: ");
            int entrada = Convert.ToInt32(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine($"Entrada adicionada");
            Console.ReadLine();


        }

        public void Exibir()
        {
       
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Preço: {Preco}");
            Console.WriteLine($"Frete: {Frete}");
            Console.WriteLine($"Estoque: {estoque}");
        }

        public void Saida()
        {
            Console.WriteLine($"Registro de saida de Produto {Nome}");
            Console.WriteLine($"Quantidade: ");
            int entrada = Convert.ToInt32(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine($"saida adicionada");
            Console.ReadLine();
        }
    }
}
