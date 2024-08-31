# CatalogService

O **CatalogService** é um microserviço dentro do projeto OrbitCore responsável pela gestão do catálogo de produtos. Este serviço lida com operações relacionadas a produtos, incluindo a criação, leitura, atualização e exclusão de informações de produtos no catálogo.

## Funcionalidades

- **Listar Produtos**: Obtém uma lista de todos os produtos no catálogo.
- **Adicionar Produto**: Adiciona um novo produto ao catálogo.
- **Atualizar Produto**: Atualiza as informações de um produto existente.
- **Excluir Produto**: Remove um produto do catálogo.
- **Buscar Produto por ID**: Obtém detalhes de um produto específico com base em seu ID.

## Tecnologias

- .NET 8
- AWS Lambda
- AWS SQS
- AWS DynamoDB
- Docker

## Estrutura do Projeto

O projeto é dividido em várias pastas para uma organização clara:

- `src/`: Contém o código-fonte do serviço.
  - `CatalogService/`: Código principal do serviço de catálogo.
  - `CatalogService.Tests/`: Testes automatizados para o serviço de catálogo.
- `docker-compose.yml`: Arquivo para configuração do Docker Compose.
- `samconfig.toml`: Configuração do SAM CLI para implantação com o LocalStack.

## Configuração

### Requisitos

- .NET 8 SDK
- AWS CLI
- Docker
- LocalStack (para desenvolvimento local)

### Configuração Local

1. **Clone o Repositório**:

    ```bash
    git clone https://github.com/seu-usuario/orbitcore-catalog-service.git
    cd orbitcore-catalog-service
    ```

2. **Restaurar Pacotes**:

    ```bash
    dotnet restore
    ```

3. **Executar Localmente**:

    ```bash
    dotnet run --project src/CatalogService
    ```

4. **Executar Testes**:

    ```bash
    dotnet test
    ```

### Implantação

1. **Construir e Empacotar a Função Lambda**:

    ```bash
    sam build
    ```

2. **Implantar com LocalStack**:

    ```bash
    sam deploy --guided
    ```

## APIs

### Listar Produtos

- **Endpoint**: `GET /api/products`
- **Descrição**: Obtém uma lista de todos os produtos.

### Adicionar Produto

- **Endpoint**: `POST /api/products`
- **Descrição**: Adiciona um novo produto ao catálogo.
- **Request Body**:
    ```json
    {
        "name": "Nome do Produto",
        "description": "Descrição do Produto",
        "price": 100.00
    }
    ```

### Atualizar Produto

- **Endpoint**: `PUT /api/products/{id}`
- **Descrição**: Atualiza as informações de um produto existente.
- **Request Body**:
    ```json
    {
        "name": "Nome Atualizado",
        "description": "Descrição Atualizada",
        "price": 120.00
    }
    ```

### Excluir Produto

- **Endpoint**: `DELETE /api/products/{id}`
- **Descrição**: Remove um produto do catálogo.

### Buscar Produto por ID

- **Endpoint**: `GET /api/products/{id}`
- **Descrição**: Obtém detalhes de um produto específico.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
