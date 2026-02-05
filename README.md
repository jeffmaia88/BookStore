# BookStore API

API REST desenvolvida como **prova técnica/acadêmica** para gerenciamento de uma livraria, com emprestimos e relatorios.

---
## Objetivos

Demonstrar conhecimentos em:
* ASP.NET Core Web API
* Entity Framework Core
* Arquitetura em camadas
* Desacoplamento
* Persistência de dados
* regras de negócio

---

## Tecnologias Utilizadas

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* Swagger (OpenAPI)
* Git / GitHub
* Postman

---

## Arquitetura do Projeto

Desenvolvi o projeto  utizando separações de responsabilidades e utilizando o Modelo MVC, embora não tenha nesse projeto implementado Views.
Separei as camadas da seguinte forma para melhor entendimento e desacomplamento:

- **Entities** – camada de modelos do meu projeto, onde estão as classes que representam as tabelas do banco de dados, e suas propriedades.
- **Data** : Camada de acesso a dados utilizando Entity Framework Core. Dentro dela, utilizei FluentMaps para melhor configurar o Banco de Dados
- **Repositories** – Minha camada de Acesso a dados, que se comunica com a camada Data, e é responsável por realizar as operações de CRUD e consultas específicas
- **Services** – Regras de negócio, essa camada se comunica com a camada Repositories, mas recebe as validações necessárias vindas da DTO, para que ela fique o maximo enxuta.
- **DTOs** – essa camada realiza a Entrada e saída de dados, Nela há os Requests que vem do Endpoint e os Responses que serão exibidos ao usuario., Há também uma classe de Result, que padroniza as respoatas
- ** Converters** - Essa camada, eu removi as validações de entrada da Service, separei nessa camada, para limpara a Service.
- **Controllers** – Exposição dos endpoints da API
- **Relatorios** – Camada dedicada para consultas e relatórios
- **Database** – Backup do banco de dados (`.bak`)
- ** Configurations** - Nessa camada, eu removi as configurações de injeção de dependencia que sobrecarregavam a Program, e coloquei os builders nela.


---

## Funções da API

### Livros
- CRUD completo
- Controle de estoque através do campo Quantidade
- Validação de quantidade maior ou igual a zero

### Empréstimos
- Criação de empréstimos com múltiplos livros
- Verificação de disponibilidade em estoque
- Baixa automática de estoque após empréstimo
- Consulta por ID e código

---

## Relatórios

- **Livros com baixo estoque** (quantidade < 3)
- **Empréstimos realizados por período**
- **Relatório geral do acervo**
- **Livros indisponíveis para empréstimo** (quantidade = 0)

---

## Endpoints Principais

### Livros

- **GET** /v1/livros
- **GET** /v1/livros?page={page}&pageSize={pageSize}
- **POST** /v1/livros
- **PUT** /v1/livros/{id}
- **DELETE** /v1/livros/{id}

### Empréstimos

- **GET** /v1/livros
- **GET** /v1/livros?page={page}&pageSize={pageSize}
- **POST** /v1/livros
- **PUT** /v1/livros/{id}
- **DELETE** /v1/livros/{id}

### Relatórios

- GET /v1/relatorios/livros/estoque
- GET /v1/relatorios/livros/acervo
- GET /v1/relatorios/livros/indisponiveis
- GET /v1/relatorios/emprestimos/periodo?inicio=YYYY-MM-DD&fim=YYYY-MM-DD


## Observações

Removi o Password da ConnectionString, para não haver problemas com o Github


--- Projeto Realizado pelo Aspirante a Vaga de Analista de Sistema - JEfferson dos Reis Maia -
