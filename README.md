# 🚗 Gerenciamento de Consórcios

Aplicação web completa para **cadastrar, listar, atualizar e excluir consórcios** de veículos, imóveis e maquinários. Ideal para estudos e prática com APIs REST, JavaScript puro e uso do ORM Dapper com ASP.NET Core.

---

## ✨ Funcionalidades

- 📝 Cadastro de consórcios com:
  - Descrição
  - Valor
  - Parcelas
  - Categoria (Veículos, Imóveis, Maquinários)
  - Data de criação
- 📋 Listagem de todos os consórcios cadastrados
- 🔎 Filtro por categoria
- 🗑️ Exclusão de consórcios
- ✅ Validação de campos obrigatórios (FluentValidation)

---

## 📁 Estrutura do Projeto

GerenciamentoConsorcio/
├── WebApi/ # Backend ASP.NET Core (API REST)
│ ├── Controllers/
│ ├── Models/
│ ├── Repositories/
│ ├── Services/
│ └── appsettings.json # Configuração de conexão MySQL
└── FrontEndConsórcio/
└── consorcio/
├── index.html # Página principal
├── style.css # Estilo da aplicação
└── app.js # Requisições para a API

yaml
Copiar
Editar

---

## ▶️ Como Executar

### 🔧 Backend (.NET)

1. Configure o banco de dados MySQL.
2. Ajuste a string de conexão no arquivo:
GerenciamentoConsorcio/WebApi/appsettings.json

arduino
Copiar
Editar
3. Execute o backend com o comando:
```bash
cd GerenciamentoConsorcio/WebApi
dotnet run
A API estará disponível em:

https://localhost:7089

http://localhost:5245

🌐 Frontend (HTML/CSS/JS)
Abra o arquivo:

bash
Copiar
Editar
FrontEndConsórcio/consorcio/index.html
Certifique-se de que a API está rodando.

Se necessário, ajuste a URL da API no arquivo app.js.

🛠️ Tecnologias Utilizadas
Backend: ASP.NET Core 7

Banco de Dados: MySQL

ORM: Dapper

Validação: FluentValidation

Frontend: HTML, CSS, JavaScript puro

🧪 Testes
O projeto ainda não possui testes automatizados.
Para testes manuais, recomenda-se o uso de ferramentas como Postman ou Insomnia.

📌 Observações
O frontend é uma SPA simples que consome a API REST com fetch.

Segue uma arquitetura limpa com separação em camadas: Controller, Service, Repository.

Para desenvolvimento local, utilize appsettings.Development.json para configurações.

📄 Licença
Este projeto foi desenvolvido apenas para fins educacionais e institucionais.
Sinta-se livre para estudar, modificar e reutilizar. 🚀

👨‍💻 Desenvolvido por
Abel
Desenvolvido como prática com ASP.NET Core e frontend estático em HTML/CSS/JS.