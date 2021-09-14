using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Exceptions
{
    public class ProdutoJaCadastradoException : Exception
    {
        public ProdutoJaCadastradoException()
            : base("Produto já cadastrado")
        { }
    }
}
