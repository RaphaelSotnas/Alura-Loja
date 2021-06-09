using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //PegarProdutoPorId(1);
            //EditarProduto(2);
            DeletarProduto(1);
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Pedra Filosofal";
            p.Categoria = "DVD";
            p.Preco = 58.887;

            ProdutoContext produtoContext = new ProdutoContext();

            produtoContext.Produtos.Add(p);
            produtoContext.SaveChanges();
            
        }

        private static Produto PegarProdutoPorId(int id)
        {
            ProdutoContext produtoContext = new ProdutoContext();

            Produto produto = produtoContext.Produtos.FirstOrDefault(p => p.Id == id);
            Console.WriteLine(produto.Nome);
            Console.ReadLine();
            return produto;
        }
        private static void EditarProduto(int id)
        {
            ProdutoContext produtoContext = new ProdutoContext();

            var produto = produtoContext.Produtos.FirstOrDefault(p => p.Id == id);

            Console.WriteLine(produto.Nome);
            Console.WriteLine(produto.Categoria);
            Console.WriteLine("/////////--------//////////");
            produto.Categoria = "Livro";

            produtoContext.Produtos.Update(produto);
            produtoContext.SaveChanges();

            Console.WriteLine(produto.Nome);
            Console.WriteLine(produto.Categoria);
            Console.ReadLine();
        }
        public static void DeletarProduto(int id)
        {
            ProdutoContext produtoContext = new ProdutoContext();

            var produtoRecuperadoDoBanco = PegarProdutoPorId(id);

            produtoContext.Produtos.Remove(produtoRecuperadoDoBanco);
            produtoContext.SaveChanges();
        }


    }
}
