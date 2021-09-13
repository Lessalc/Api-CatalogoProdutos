using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        // Método Get
        [HttpGet("{idProduto:guid}")]
        public async Task<ActionResult<object>> Obter([FromRoute] Guid idProduto)
        {
            return Ok();
        }

        // Método Post
        [HttpPost]
        public async Task<ActionResult<object>> InserirProduto([FromBody] Object obj)
        {
            return Ok();
        }


        // Método Put
        [HttpPut("{idProduto:guid}")]
        public async Task<ActionResult> AtualizarProduto([FromRoute] Guid idProduto, [FromBody] Object obj)
        {
            return Ok();
        }

        // Método Patch
        [HttpPatch("{idProduto:guid}/custo/{custo:double}")]
        public async Task<ActionResult> AtualizarProduto([FromRoute] Guid idProduto, [FromBody] double custo)
        {
            return Ok();
        }

        // Método Delete
        [HttpDelete("{idProduto:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idProduto)
        {
            return Ok();
        }



    }
}
