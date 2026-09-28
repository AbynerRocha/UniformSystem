# UniformSystem API

API REST para gerir uniformes, funcionários, utilizadores e entregas de uniformes. O projeto usa ASP.NET Core, Entity Framework Core e PostgreSQL.

## Tecnologias

- .NET 10 / ASP.NET Core
- Entity Framework Core 10
- PostgreSQL com Npgsql
- Mapster para projeção de entidades em DTOs
- JWT Bearer para autenticação
- Scalar para explorar a API em desenvolvimento

## Requisitos

- .NET SDK 10
- PostgreSQL

## Configuração local

Na pasta que contém `UniformSystem.csproj`, configure a connection string e os parâmetros JWT com User Secrets. Não coloque senhas ou chaves JWT no repositório.

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=uniform_system;Username=postgres;Password=SUA_SENHA"
dotnet user-secrets set "Jwt:Key" "SUBSTITUA_POR_UMA_CHAVE_SECRETA_FORTE"
dotnet user-secrets set "Jwt:Issuer" "http://localhost:5283"
dotnet user-secrets set "Jwt:Audience" "http://localhost:5173"
```

Crie/atualize o banco aplicando as migrations:

```bash
dotnet ef database update
```

Inicie a API:

```bash
dotnet run --launch-profile http
```

A API ficará disponível em `http://localhost:5283`. No ambiente `Development`, a documentação interativa do Scalar fica em `http://localhost:5283/docs` e o documento OpenAPI em `http://localhost:5283/openapi/v1.json`.

## Endpoints implementados

| Método | Rota | Descrição |
| --- | --- | --- |
| `GET` | `/api/User/{id}` | Consulta utilizador por ID |
| `GET` | `/api/User?email={email}` | Consulta utilizador por e-mail |
| `POST` | `/api/User` | Cria utilizador |
| `GET` | `/api/Employees` | Lista funcionários |
| `GET` | `/api/Employees/{id}` | Consulta funcionário por ID |
| `POST` | `/api/Employees` | Cria funcionário |
| `GET` | `/api/Uniforms` | Lista uniformes; aceita filtros definidos em `UniformFilterRequestDto` |
| `GET` | `/api/Uniforms/{id}` | Consulta uniforme por ID |
| `GET` | `/api/Uniforms/{reference}` | Consulta uniforme por referência |
| `POST` | `/api/Uniforms` | Cria uniforme |
| `DELETE` | `/api/Uniforms/{id}` | Remove uniforme |
| `GET` | `/api/Delivery/{id}` | Consulta entrega por ID |
| `POST` | `/api/Delivery` | Regista entrega de uniforme |

## Exemplo: registar entrega

```http
POST http://localhost:5283/api/Delivery
Content-Type: application/json

{
  "deliveredById": 1,
  "deliveredToEmployeeId": 1,
  "uniformId": 1,
  "amount": 1
}
```

`deliveredAt` é opcional no DTO e recebe o valor UTC atual quando omitido. Se for enviado, deve ser uma data ISO 8601 válida, por exemplo `"2026-09-28T12:00:00Z"`.

## Exemplo: consultar entrega

```http
GET http://localhost:5283/api/Delivery/1
Accept: application/json
```

A resposta inclui os dados da entrega e resumos relacionados (ID e nome do funcionário e utilizador; ID, nome, categoria, tamanho e sexo do uniforme). A API projeta para DTOs, evitando serializar diretamente as navegações circulares das entidades do EF Core.

## Estrutura do projeto

- `Features/`: controllers, serviços, repositórios e DTOs organizados por funcionalidade.
- `Entities/`: entidades persistidas no banco.
- `Data/Configurations/`: mapeamento das entidades para PostgreSQL.
- `Migrations/`: migrations do Entity Framework Core.
- `Maps/MappingConfig.cs`: configurações Mapster.
- `Security/`: autenticação e autorização por permissões.

## Observações

- O CORS está configurado para permitir a origem `http://localhost:5173`; ajuste-a para a origem do frontend usado no seu ambiente.
- Scalar e OpenAPI são habilitados apenas no ambiente `Development`.
- O projeto configura JWT Bearer. Configure `Jwt:Key`, `Jwt:Issuer` e `Jwt:Audience` antes de executar a aplicação.
- Os endpoints não devem ser considerados protegidos apenas por essa configuração: associe políticas `[Authorize]` às rotas que precisarem exigir autenticação/permissões.
