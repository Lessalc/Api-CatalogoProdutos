using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Exceptions
{
    public class ProdutoNaoCadastradoException : Exception
    {
        public ProdutoNaoCadastradoException()
            : base("Produto não cadastrado.")
        { }
    }
}
