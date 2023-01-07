# Teste prático - Dev BackEnd II

## Sistema FaleMais

Sistema tem como objetivo realizar o cálculo do custo de chamadas em determinados planos fornecidos.

## Tecnologias

* Front
  * [Angular 13+](https://angular.io)
  * [NgZorro](https://ng.ant.design/docs/introduce/en)
  * [Jasmin](https://jasmine.github.io/)
  * [Karma](https://karma-runner.github.io/latest/index.html)

* Back
  * [.NET 6](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
  * [EF Core](https://docs.microsoft.com/pt-br/ef/core/)
  * [JwtBearer](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer?view=aspnetcore-6.0)
  * [SQLite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/#supportedframeworks-body-tab)

* Infra
  * [Docker](https://www.docker.com/get-started/)


## Front

### Pré Requisitos

1. Instalar o  [Node.js](https://nodejs.org)
2. Instalar o Angular:
  ```bash
  npm i -g @angular/cli
  ```
3. Dentro da pasta **FaleMaisFront**, instalar as dependências:
  ```bash
  npm i
  ```

## Executando a aplicação

Para fazer o build:

```bash
npm run build
```

Para executar a aplicação:

```bash
npm run start
```

Para visualizar a aplicação em execução acesse a URL http://localhost:4200/

Pode ser necessário alterar a porta da API do back-end, acessando o arquivo presente em
```src/environments/environment.prod.ts``` e alterando a propriedade **api** para ```'https://localhost:{{NovaPorta}}'```.

Para executar os testes:

```bash
npm run test
```

Para gerar o relatório de cobertura de testes:

```bash
npm run test-coverage
```

Para visualizar o relatório gerado em HTML acesse o arquivo ```FaleMaisFront/coverage/fale-mais-front/index.html```

Para gerar o relatório com a descrição dos testes:

```bash
npm run test-junit
```

Para visualizar o relatório gerado em XML acesse o arquivo com o nome iniciado em ```'TESTS-Chrome_Headless...'``` presente na pasta ```FaleMaisFront```

## Sobre a aplicação

### Acessos
A Aplicação possui um controle de acesso com os seguintes níveis:
| Tipo Acesso   | Visualização  |
| ------------- | ------------- |
| Administrador | Total         |
| Cliente       | Parcial       |

Onde o tipo de usuário **Cliente** visualiza somente a tela para realizar os cálculos e visualizar os planos após efetuar seu login. Somente a tela de login fica disponível sem nenhum tipo de autenticação necessária na aplicação.

Esse controle é feito por meio de 2 guards de rotas, que podem ser para administrador ou somente para cliente(usuário comum logado), além de um interceptor que além de preencher as requisições com o token exibe notificações de erros caso sejam recebidos da API.

Usuários previamente cadastrados:
| Usuário       | Senha         |
| ------------- | ------------- |
| Administrador | 12345678      |
| Cliente       | 12345678      |

### Páginas
* Login
  * Contém o formulário para que o usuário possa inserir seus dados de acesso
  * Não precisa de autenticação

* Calcular
  * Contém o formulário para que o usuário possa inserir a origem, destino e quantidade de minutos que precisa falar para verificar o melhor plano disponível
  * Acessível para usuário logado

* Tarifas
  * Contém a listagem das tarifas cobradas por minuto de acordo com a combinação do DDD
  * É possível excluír,alterar e cadastrar registros
  * Acesso somente de administrador

* DDD
  * Contém a listagem dos DDDs disponíveis
  * É possível excluír,alterar e cadastrar registros
  * Acesso somente de administrador

* Usuários
  * Contém os usuários da aplicação, com nome, tipo e data de criação.
  * É possível excluír,alterar e cadastrar registros
  * Acesso somente de administrador

* Nosso Planos
  * Contém os cards com os planos cadastrados
  * Acessível para usuário logado

## Back

### Pré Requisitos

[SDK do .NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Executando a aplicação

Para executar a aplicação, Dentro da pasta **FaleMais**:

```bash
dotnet run --project FaleMais --urls=https://localhost:7238/
```

*Porta pode ser alterada, somente sendo necessário alterar também na aplicação front-end para permitir a comunicação*

Para executar os testes, Dentro da pasta **FaleMais/FaleMaisTestes**:

```bash
  dotnet test -v q
  ```
O parâmetro ```-v``` está definindo a verbosidade do comando

O parâmetro ```q``` está definindo a verbosidade como quiet

## Sobre a aplicação

### Acessos

A Aplicação possui uma autenticação de token Bearer JWT.
A chave privada pode ser alterada no arquivo ```'FaleMais/FaleMais/appsettings.json'``` na propriedade **secretKey**
O token por padrão expira em 2h

### Documentação

A aplicação conta com o **Swagger** para documentar seus endpoints, para acessá-lo basta ir até a URL https://localhost:7238/swagger/index.html

## Containers
Para testar a aplicação utilizando o docker basta baixar as imagens [fale-mais-front](https://hub.docker.com/r/douglasaugustojunior/fale-mais-front) e [falemaisback](https://hub.docker.com/r/douglasaugustojunior/falemaisback)
* ```docker pull douglasaugustojunior/falemaisback```
* ```docker pull douglasaugustojunior/fale-mais-front```

Após isso suba o back-end na porta **5000** com o comando

 ```docker run --rm -p 5000:80 douglasaugustojunior/falemaisback```

 e o front na porta **81** com o comando

 ```docker run --env API_URL="http://localhost:5000" --rm -p 81:80 douglasaugustojunior/fale-mais-front```

 Acesse a aplicação no endereço **localhost:81** e a documentação no endereço **localhost:5000/swagger**.