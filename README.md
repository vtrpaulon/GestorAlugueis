# 🏠 Gestor de Aluguéis

API REST desenvolvida em .NET para gerenciamento de imóveis para locação.

## 🚀 Tecnologias utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* C#

## 🧱 Arquitetura

O projeto segue uma arquitetura em camadas:

```
Controller → Service → Repository → DbContext
```

* **Controller**: responsável pelas requisições HTTP
* **Service**: regras de negócio
* **Repository**: acesso a dados
* **DbContext**: comunicação com o banco via EF Core

## 📦 Estrutura do projeto

```
/Controllers
/Services
/Repositories
/Entities
/DTOs
/Data
```

## 🔧 Configuração do ambiente

### 1. Clonar o repositório

```bash
git clone https://github.com/vtrpaulon/GestorAlugueis.git
cd GestorAlugueis
```

### 2. Configurar a connection string

No arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=GestorAlugueisDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Aplicar migrations

```bash
dotnet ef database update
```

### 4. Executar a aplicação

```bash
dotnet run
```

---

## 📌 Endpoints

### 🔹 Listar imóveis

```
GET /api/imovel
```

### 🔹 Buscar por ID

```
GET /api/imovel/{id}
```

### 🔹 Criar imóvel

```
POST /api/imovel
```

Exemplo de body:

```json
{
  "endereco": "Rua A, 123",
  "valorAluguel": 1200,
  "disponivel": true
}
```

### 🔹 Atualizar imóvel

```
PUT /api/imovel/{id}
```

### 🔹 Deletar imóvel

```
DELETE /api/imovel/{id}
```

---

## 💡 Boas práticas aplicadas

* Separação de responsabilidades (Controller, Service, Repository)
* Uso de DTOs para entrada e saída de dados
* Injeção de dependência
* Migrations com Entity Framework Core
* Validação de regras de negócio no Service

---

## 📈 Melhorias futuras

* Implementar async/await em toda a aplicação
* Criar interfaces para os repositórios
* Adicionar autenticação e autorização
* Implementar testes automatizados

---

## 👨‍💻 Autor

Desenvolvido por Vitor Paulon
