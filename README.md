# DotNetAI API

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 
![.NET Core](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat&logo=visual-studio&logoColor=white)
![Git](https://img.shields.io/badge/GIT-F05032?style=flat&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat&logo=github&logoColor=white)
![Docker](https://img.shields.io/badge/docker-2496ED?style=flat&logo=docker&logoColor=white)


## 🎯 Desafio Target - API

Este projeto foi desenvolvido como parte de uma avaliação prática para a vaga de Desenvolvedor Backend. O objetivo é demonstrar proficiência em tecnologias e boas práticas de desenvolvimento web com .NET 8, indo além dos requisitos propostos no teste.

A solução implementa uma API RESTful robusta para:
- Gestão de comissões
- Controle de estoque
- Cálculos financeiros


## 🎯 Desafio Target - UI

Não foi solicitado uma interface para esse projeto, mas para agregar optei por desenvolver uma solução com Angular, disponível no link abaixo:

* **[FrontEnd Angular](https://github.com/marcelogmoura/desafioTarget.UI)**



## 📋 Requisitos e Documentação

Os requisitos completos do teste técnico (prova) estão detalhados no documento oficial:
* **[Enunciado](https://github.com/marcelogmoura/desafioTarget.API/blob/main/Pdf/desafio_dev.pdf)**


## 🚀 Visão Geral do Projeto/Teste

O projeto segue os princípios da **Clean Architecture** e **DDD (Domain-Driven Design)**, garantindo desacoplamento entre as camadas de domínio, aplicação, infraestrutura e apresentação. A aplicação está totalmente containerizada, pronta para execução em qualquer ambiente via Docker.

### Funcionalidades Principais

- **Cálculo de Comissões:** Processamento automático de listas de vendas com cálculo baseado em faixas de valores isoladas das regras de negócio.
- **Gestão de Estoque:** Carga inicial de produtos e controle transacional com validação de saldo.
- **Cálculo de Juros:** Endpoint para cálculo de juros compostos (multa diária) sobre boletos vencidos.


## 🛠️ Tecnologias Utilizadas

- **[C# .NET 8](https://dotnet.microsoft.com/):** Plataforma de desenvolvimento de alta performance.
- **[Entity Framework Core](https://learn.microsoft.com/ef/):** ORM para acesso a dados e mapeamento objeto-relacional.
- **[SQL Server 2022](https://www.microsoft.com/sql-server):** Banco relacional robusto.
- **[Docker & Docker Compose](https://www.docker.com/):** Orquestração de containers e padronização do ambiente.
- **[xUnit](https://xunit.net/):** Framework para testes unitários.
- **[Swagger / OpenAPI](https://swagger.io/):** Documentação viva e interativa da API.


## Regras de Negócio (Domínio)

As regras centrais estão encapsuladas na camada `Domain`, garantindo que a lógica não vaze para controladores ou banco de dados:

- **Comissões:**  
  - Venda < R$ 100,00: 0%  
  - Venda < R$ 500,00: 1%  
  - Venda >= R$ 500,00: 5%  
- **Juros:** Multa fixa de 2.5% ao dia (juros simples sobre o valor original) para pagamentos após o vencimento.


## 🏗️ Arquitetura do Projeto

A solução está dividida em 4 camadas (projetos):

- **API (`desafioTarget.API`):** Controllers, DI e Swagger
- **Application (`desafioTarget.Application`):** Serviços, DTOs e Casos de Uso
- **Domain (`desafioTarget.Domain`):** Entidades, Interfaces, Enums, Serviços de Domínio
- **Infra (`desafioTarget.Infra`):** Repositórios, EF Core Context/Maps, Migrations


## 📂 Estrutura do Projeto

```bash
desafioTarget.API/
├── 📂 desafioTarget.API           # Camada de Apresentação (Controllers)
├── 📂 desafioTarget.Application   # Camada de Aplicação (Services, DTOs)
├── 📂 desafioTarget.Domain        # Camada de Domínio (Entities, Interfaces)
├── 📂 desafioTarget.Infra         # Camada de Infraestrutura (Data Context, Repos)
├── 📂 desafioTarget.Tests         # Testes Unitários
├── 📜 docker-compose.yml          # Orquestração de Containers
└── 📜 README.md                   # Documentação
```


## ⚙️ Como Executar

### Pré-requisitos

- Docker e Docker Compose instalados


### Passo a Passo

1. Clone o repositório e acesse a pasta raiz  

2. Crie um arquivo `.env` na raiz (onde está `docker-compose.yml`) e defina a senha do banco: 


```
SA_PASSWORD=SenhaForte!123
``` 

3. Execute para compilar a API, criar o banco e iniciar os serviços:  

```
docker-compose up -d --build
```


4. Quando os containers estiverem rodando, acesse:  

- **Swagger UI (Documentação):** http://localhost:8080/swagger  
- **API Base:** http://localhost:8080/api  


## 📚 Endpoints Disponíveis

| Método   | Rota                        | Descrição                                    |
| -------- | --------------------------- | --------------------------------------------|
| `POST`   | `/api/comissao/calcular`    | Calcula comissões de uma lista de vendas     |
| `POST`   | `/api/estoque/carga-inicial`| Realiza carga inicial de produtos no banco  |
| `POST`   | `/api/estoque/movimentar`   | Registra entrada/saída e atualiza saldo     |
| `GET`    | `/api/financeiro/calculajuros` | Calcula juros baseados na data de vencimento |

Você pode testá-las diretamente pelo Swagger.

## 📚 Exemplos de requisições e respostas

Cálculo de Comissão

![Cálculo](https://i.postimg.cc/qMLS2w07/calcular-comissao.png)

Movimentação de Estoque

![Movimentação](https://i.postimg.cc/y885jRY7/movimentar.png)

Carga Inicial de Produtos

![Carga](https://i.postimg.cc/tC5wFkyY/carga-inicial.png)


Containers Docker em Execução

![Docker](https://i.postimg.cc/wjjP2NTg/container.png)


## 🧪 Testes Automatizados

Execute na raiz do projeto para rodar a suíte de testes unitários focados nas regras de negócio:

```
dotnet test
```

👨‍💻 **Autor:** Marcelo Moura 

📧 **Email:** [mgmoura@gmail.com](mailto:mgmoura@gmail.com)   
📧 **Email:** [admin@allriders.com.br](mailto:admin@allriders.com.br)   
🐱 **GitHub:** [github.com/marcelogmoura](https://github.com/marcelogmoura)   
🔗 **LinkedIn:** [linkedin.com/in/marcelogmoura](https://www.linkedin.com/in/marcelogmoura/)   
