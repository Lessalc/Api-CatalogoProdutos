using CatalogoProdutos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Entities
{
    public class Produtos
    {
        public Guid Id { get; set; }

        public String Nome{ get; set; }

        public String Gtin{ get; set; }

        public TipoProduto Tipo { get; set; }

        public double Custo { get; set; }

        public Fornecedores Fornecedor{ get; set; }
    }
}
