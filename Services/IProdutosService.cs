using CatalogoProdutos.InputModel;
using CatalogoProdutos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Services
{
    public interface IProdutosService : IDisposable
    {
        Task<List<ProdutosViewModel>> Obter(int pagina, int quantidade);

        Task<ProdutosViewModel> Obter(Guid id);

        Task<ProdutosViewModel> Inserir(ProdutosInputModel produto);

        Task Atualizar(Guid id, ProdutosInputModel produto);

        Task Atualizar(Guid id, double custo);

        Task Remover(Guid id);

    }
}
