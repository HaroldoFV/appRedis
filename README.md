# appRedis Project

## Descrição

Este projeto é uma API .NET 8 para gerenciamento de produtos, utilizando Entity Framework Core com um banco de dados em memória e caching com Redis. O projeto é configurado para rodar em contêineres Docker.

## Estrutura do Projeto

- **.NET 8.0**: Framework utilizado para construir a aplicação.
- **Entity Framework Core**: ORM para acesso a dados.
- **Redis**: Utilizado como serviço de cache.
- **Docker**: Utilizado para containerizar a aplicação e seus serviços.

## Como Executar

### Pré-requisitos

- Docker instalado.

### Passos

1. Clone o repositório:
   ```sh
   git clone https://github.com/HaroldoFV/appRedis
   cd appRedis

2. Execute os contêineres:

   ```sh
   docker-compose up --build
   
3. Acesse a aplicação em http://localhost:8080.


### Observações
O Redis estará acessível na porta 6379.