using CatalogoProdutos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {

        private static Dictionary<Guid, Produtos> produtos = new Dictionary<Guid, Produtos>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Produtos{Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                Nome = "TV 50polegadas", Gtin="81052152", Tipo = Enum.TipoProduto.Eletronico, Custo = 2500, Fornecedor = Enum.Fornecedores.Fornecedor1} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Produtos{Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"),
                Nome = "Iphone 11", Gtin="81982582", Tipo = Enum.TipoProduto.CelularesESmartphones, Custo = 3500, Fornecedor = Enum.Fornecedores.Fornecedor1} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Produtos{Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"),
                Nome = "Calça Jeans Masculina T-42 Gr001", Gtin="56842152", Tipo = Enum.TipoProduto.Vestuario, Custo = 35, Fornecedor = Enum.Fornecedores.Fornecedor2} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Produtos{Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"),
                Nome = "Cadeira AAA", Gtin="63885479", Tipo = Enum.TipoProduto.Mobiliario, Custo = 56, Fornecedor = Enum.Fornecedores.Fornecedor5} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Produtos{Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"),
                Nome = "Fogão Brastemp 5bocas", Gtin="32697465", Tipo = Enum.TipoProduto.Eletronico, Custo = 325, Fornecedor = Enum.Fornecedores.Fornecedor4 } }
        };

        public Task<List<Produtos>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(produtos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Produtos> Obter(Guid id)
        {
            if (!produtos.ContainsKey(id))
                return null;
            return Task.FromResult(produtos[id]);
        }

        // Não podemos ter um produto cadastrado com o mesmo gtin
        public Task<List<Produtos>> Obter(string gtin)
        {
            return Task.FromResult(produtos.Values.Where(prod => prod.Gtin.Equals(gtin)).ToList());
        }

        public Task Inserir(Produtos produto)
        {
            produtos.Add(produto.Id, produto);
            return Task.CompletedTask;
        }

        public Task Atualizar(Produtos produto)
        {
            produtos[produto.Id] = produto;
            return Task.CompletedTask;
        }
      
        public Task Remover(Guid id)
        {
            produtos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
