using CatalogoProdutos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Repositories
{
    public interface IProdutosRepository : IDisposable
    {
        Task<List<Produtos>> Obter(int pagina, int quantidade);

        Task<Produtos> Obter(Guid id);

        Task<List<Produtos>> Obter(string gtin);

        Task Inserir(Produtos produto);

        Task Atualizar(Produtos produto);

        Task Remover(Guid id);

    }
}
