using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Exceptions
{
    public class GtniJaCadastradoException : Exception
    {
        public GtniJaCadastradoException()
            : base("O GTNI deve ser único.")
        {}
    }
}
