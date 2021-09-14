using CatalogoProdutos.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.InputModel
{
    public class ProdutosInputModel
    {

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public String Nome { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "GTIN inválido, deve possuir 8, 12, 13 ou 14 dígitos")]
        public String Gtin { get; set; }

        [Required]
        [EnumDataType(typeof(TipoProduto))]
        public TipoProduto Tipo { get; set; }

        [Required]
        [Range(1, 50000, ErrorMessage = "O preço do jogo deve ser de no mínimo R$1,00 e no máximo R$50000,00")]
        public double Custo { get; set; }

        [Required]
        [EnumDataType(typeof(Fornecedores))]
        public Fornecedores Fornecedor { get; set; }
    }
}
