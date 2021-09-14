using CatalogoProdutos.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Repositories
{
    public class ProdutosSQLServerRepository : IProdutosRepository
    {
        private readonly SqlConnection sqlConnection;

        public ProdutosSQLServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Produtos>> Obter(int pagina, int quantidade)
        {
            var produtos = new List<Produtos>();

            var comando = $"select * from Produtos order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} row only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                produtos.Add(new Produtos
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Gtin = (string)sqlDataReader["Gtin"],
                    Tipo = (Enum.TipoProduto)(int)sqlDataReader["Tipo"],
                    Custo = (double)sqlDataReader["Custo"],
                    Fornecedor = (Enum.Fornecedores)(int)sqlDataReader["Fornecedor"]
                });
            }

            await sqlConnection.CloseAsync();

            return produtos;
        }

        public async Task<List<Produtos>> Obter(string gtin)
        {
            var produtos = new List<Produtos>();

            var comando = $"select * from Produtos where Gtin = '{gtin}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                produtos.Add(new Produtos
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Gtin = (string)sqlDataReader["Gtin"],
                    Tipo = (Enum.TipoProduto)(int)sqlDataReader["Tipo"],
                    Custo = (double)sqlDataReader["Custo"],
                    Fornecedor = (Enum.Fornecedores)(int)sqlDataReader["Fornecedor"]
                });
            }

            await sqlConnection.CloseAsync();

            return produtos;
        }

        public async Task<Produtos> Obter(Guid id)
        {
            Produtos produto = null;

            var comando = $"select * from Produtos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                produto = new Produtos
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Gtin = (string)sqlDataReader["Gtin"],
                    Tipo = (Enum.TipoProduto)(int)sqlDataReader["Tipo"],
                    Custo = (double)sqlDataReader["Custo"],
                    Fornecedor = (Enum.Fornecedores)(int)sqlDataReader["Fornecedor"]
                };
            }

            await sqlConnection.CloseAsync();

            return produto;
        }

        public async Task Inserir(Produtos produto)
        {
            var comando = $"insert Produtos values ('{produto.Id}', '{produto.Nome}', '{produto.Gtin}', '{(int)produto.Tipo}', '{produto.Custo.ToString().Replace(",", ".")}', '{(int)produto.Fornecedor}')";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            await sqlConnection.CloseAsync();
        }


        public async Task Atualizar(Produtos produto)
        {
            var comando = $"update Produtos set Nome = '{produto.Nome}', Gtin = '{produto.Gtin}', Tipo = '{(int)produto.Tipo}', " +
                $"Custo = '{produto.Custo.ToString().Replace(",", ".")}', Fornecedor = '{(int)produto.Fornecedor}' where Id = '{produto.Id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id)
        {
            var comando = $"delete from Produtos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }

    }
}
