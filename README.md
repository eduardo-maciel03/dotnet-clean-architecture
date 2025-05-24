# TaskManager.CleanArch

Projeto ASP.NET Core que implementa Clean Architecture com foco em organização em camadas, autenticação baseada em cookies, endpoints minimalistas, testes automatizados com xUnit e FluentAssertions. Ideal para demonstrar boas práticas em APIs escaláveis, seguras e testáveis.

## 🔧 Tecnologias

- **ASP.NET Core 8**
- **Minimal APIs**
- **Autenticação via Cookie**
- **Clean Architecture (Domain, Application, Infrastructure, Presentation)**
- **xUnit + FluentAssertions** (testes)
- **Swagger/OpenAPI**

---

## 🧱 Estrutura do Projeto
TaskManager/
├── Domain/ → Entidades e interfaces do domínio
├── Application/ → Casos de uso e DTOs
├── Infrastructure/ → Repositórios (mock/in-memory)
├── WebAPI/ → Endpoints, autenticação e configuração
├── Tests/ → Testes unitários com xUnit

---

## ✅ Funcionalidades

- ✅ Criação de tarefas com título e descrição
- ✅ Listagem de tarefas
- ✅ Autenticação com cookie (login/logout)
- ✅ Proteção de rotas para usuários autenticados
- ✅ Testes unitários para casos de uso
- ✅ Swagger UI para documentação

---

## 🔐 Autenticação

O sistema utiliza **autenticação baseada em cookies** com identidade simulada para fins demonstrativos.

### Login

```http
POST /api/authentication/login
Content-Type: application/json

{
  "email": "admin@admin.com",
  "password": "123456"
} 
```

Retorna um cookie de autenticação válido para usar nas rotas protegidas.

## 📦 Endpoints principais

```http
GET /api/tasks — listar tarefas (requer autenticação)
POST /api/tasks — criar tarefa (requer autenticação)
```

## 🧪 xUnit

Em TaskManager.Tests, rode: dotnet test
