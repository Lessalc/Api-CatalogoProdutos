using CatalogoProdutos.Exceptions;
using CatalogoProdutos.InputModel;
using CatalogoProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }


        // Método Get
        [HttpGet]
        public async Task<ActionResult<object>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1,
           [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var produtos = await _produtosService.Obter(pagina, quantidade);

            if (produtos.Count() == 0)
                return NoContent();
            return Ok(produtos);
        }

        // Método Get
        [HttpGet("{idProduto:guid}")]
        public async Task<ActionResult<object>> Obter([FromRoute] Guid idProduto)
        {
            var produto = await _produtosService.Obter(idProduto);
            
            if (produto == null)
                return NoContent();
            return Ok(produto);
        }

        // Método Post
        [HttpPost]
        public async Task<ActionResult<object>> InserirProduto([FromBody] ProdutosInputModel produtoInputModel)
        {
            try
            {
                var produto = await _produtosService.Inserir(produtoInputModel);

                return Ok(produto);
            }
            catch (ProdutoJaCadastradoException)
            {
                return UnprocessableEntity("Produto já cadastrado");
            }
        }


        // Método Put
        [HttpPut("{idProduto:guid}")]
        public async Task<ActionResult> AtualizarProduto([FromRoute] Guid idProduto, [FromBody] ProdutosInputModel produtoInputModel)
        {
            try
            {
                await _produtosService.Atualizar(idProduto, produtoInputModel);

                return Ok();
            }
            catch (ProdutoNaoCadastradoException)
            {
                return NotFound("Produto não cadastrado");
            }
        }

        // Método Patch
        [HttpPatch("{idProduto:guid}/custo/{custo:double}")]
        public async Task<ActionResult> AtualizarProduto([FromRoute] Guid idProduto, [FromRoute] double custo)
        {
            try
            {
                await _produtosService.Atualizar(idProduto, custo);

                return Ok();
            }
            catch (ProdutoNaoCadastradoException)
            {
                return NotFound("Produto não cadastrado");
            }
        }

        // Método Delete
        [HttpDelete("{idProduto:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idProduto)
        {
            try
            {
                await _produtosService.Remover(idProduto);

                return Ok();
            }
            catch (ProdutoNaoCadastradoException)
            {
                return NotFound("Produto não cadastrado");
            }
        }



    }
}
