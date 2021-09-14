# Criação de uma API para Catalogo de Produtos

## Sobre o projeto

- Criada uma API REST para um catálogo de Produtos
- Aqui poderíamos ter como cliente uma API, um projeto em Front-end, Angular, etc
- Usaremos JSON para request e response
- O principal objetivo é criar uma API usando ASP.NET Core Web API

## Particularidades do Projeto

- Foi criado um catálogo de produtos, com as principais informações:
  - Nome, GTIN, Tipo, Custo e Fornecedor
  - Tipo e Fornecedor foram usados Enums, de forma que podemos evoluir com o Projeto criando mais entidades no futuro e usando o conceito de Banco de Dados Relacionais.
- Além disso foi criada uma verificação para o GTIN considerando que deve ser um valor único para cada produto.

## Criando o Database e alimentando uma tabela

- Foi criado um DataBase chamado CatalogoProdutos no SQL Server e o código abaixo criou a tabela Produtos e alimentou com algumas dados.

- ```sql
  use CatalogoProdutos;
  
  create table Produtos(
  	Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
  	Nome Varchar(100) not null,
  	Gtin Varchar(14) not null,
  	Tipo Int not null,
  	Custo Float,
  	Fornecedor Int not null
  	);
  
  insert Produtos values (default,'TV 50polegadas', '81052152', 3, 2500.00, 0)
  insert Produtos values (default,'Iphone 11', '81982582', 4, 3500.00, 0)
  insert Produtos values (default,'Calça Jeans Masculina T-42 Gr001', '56842152', 0, 35.00, 1)
  insert Produtos values (default,'Cadeira AAA', '63885479', 2, 56.00, 4)
  insert Produtos values (default,'Fogão Brastemp 5bocas', '32697465', 3, 325.00, 3)
  
  select * from Produtos;
  ```

## Repositório Mockado

- Temos um repositório mockado para caso deseje rodar o programa localmente sem abrir conexão com o banco de dados.

- Para isso basta ir em **Startup.cs**, tirar o comentário da linha 32 e comentar a linha 33

- ```csharp
  // SITUAÇÃO ATUAL
  //services.AddScoped<IProdutosRepository, ProdutosRepository>();
  services.AddScoped<IProdutosRepository, ProdutosSQLServerRepository>();
  
  // ALTERAÇÃO PARA RODAR LOCALMENTE NO REPOSITÓRIO MOCKADO
  services.AddScoped<IProdutosRepository, ProdutosRepository>();
  //services.AddScoped<IProdutosRepository, ProdutosSQLServerRepository>();
  ```

