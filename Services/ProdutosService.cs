using CatalogoProdutos.Entities;
using CatalogoProdutos.Exceptions;
using CatalogoProdutos.InputModel;
using CatalogoProdutos.Repositories;
using CatalogoProdutos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosService(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

       
        public async Task<List<ProdutosViewModel>> Obter(int pagina, int quantidade)
        {
            var produtos = await _produtosRepository.Obter(pagina, quantidade);

            return produtos.Select(produto => new ProdutosViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Gtin = produto.Gtin,
                Tipo = produto.Tipo,
                Custo = produto.Custo,
                Fornecedor = produto.Fornecedor
            }).ToList();

        }

        public async Task<ProdutosViewModel> Obter(Guid id)
        {
            var produto = await _produtosRepository.Obter(id);

            if (produto == null)
                return null;

            return new ProdutosViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Gtin = produto.Gtin,
                Tipo = produto.Tipo,
                Custo = produto.Custo,
                Fornecedor = produto.Fornecedor
            };
        }
       
        public async Task<ProdutosViewModel> Inserir(ProdutosInputModel produto)
        {
            var entidadeProduto = await _produtosRepository.Obter(produto.Gtin);

            if (entidadeProduto.Count > 0)
                throw new GtniJaCadastradoException();

            var produtoInsert = new Produtos
            {
                Id = Guid.NewGuid(),
                Nome = produto.Nome,
                Gtin = produto.Gtin,
                Tipo = produto.Tipo,
                Custo = produto.Custo,
                Fornecedor = produto.Fornecedor
            };

            await _produtosRepository.Inserir(produtoInsert);
            
            return new ProdutosViewModel
            {
                Id = produtoInsert.Id,
                Nome = produto.Nome,
                Gtin = produto.Gtin,
                Tipo = produto.Tipo,
                Custo = produto.Custo,
                Fornecedor = produto.Fornecedor
            };

        }

        public async Task Atualizar(Guid id, ProdutosInputModel produto)
        {
            var entidadeProduto = await _produtosRepository.Obter(id);
            if (entidadeProduto == null)
                throw new ProdutoNaoCadastradoException();

            var entidadeProdutoGtni = await _produtosRepository.Obter(produto.Gtin); 
            if (entidadeProdutoGtni.Count > 0)
                throw new GtniJaCadastradoException();

            entidadeProduto.Nome = produto.Nome;
            entidadeProduto.Gtin = produto.Gtin;
            entidadeProduto.Tipo = produto.Tipo;
            entidadeProduto.Custo = produto.Custo;
            entidadeProduto.Fornecedor = produto.Fornecedor;

            await _produtosRepository.Atualizar(entidadeProduto);
        }

        public async Task Atualizar(Guid id, double custo)
        {
            var entidadeProduto = await _produtosRepository.Obter(id);
            if (entidadeProduto == null)
                throw new ProdutoNaoCadastradoException();

            entidadeProduto.Custo = custo;

            await _produtosRepository.Atualizar(entidadeProduto);
        }   

        public async Task Remover(Guid id)
        {
            var entidadeProduto = await _produtosRepository.Obter(id);
            if (entidadeProduto == null)
                throw new ProdutoNaoCadastradoException();

            await _produtosRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtosRepository?.Dispose();
        }
    }
}
