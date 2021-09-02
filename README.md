#Junior's Bank

##Sobre
Trata-se de um sistema simples com o intuito de 
replicar a funcionalidade de uma Conta Corrente.

## Como Utilizar
Primeiramente, será necessário clonar o projeto em sua máquina. 
Para isso, navegue até a pasta que deseja baixar o projeto e rode
o seguinte comando (importante ter o [git](https://git-scm.com/downloads) 
baixado)
``` bash
git clone https://github.com/MauricioGomes02/JuniorsBank.git
```
Em seguida, navegue até a pasta do projeto web `JuniorsBank.API` e
rode o seguinte comando em seu terminal 
(importante ter as ferramentas para utilização do [Asp.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)).
``` bash
dotnet run
```
Você irá precisar agora ir até a pasta do projeto angular `Frontend/JuniorsBank`.
Rode o seguinte comando para baixar as dependência necessárias 
(importante o [node](https://nodejs.org/pt-br/download/) estar baixado).
```
npm i
```
ou
```
npm install
```
Após finalizado o processo de download das dependências, execute o comando
```
ng serve
```
Abra seu navegador e acesse o link [http://localhost:4200](http://localhost:4200).

A aplicação já possui dois usuários criados com suas respectivas contas
e com valores depositados.

Dados para acesso:
- email: mauricioandradegomes@gmail.com
  password: 123
  (saldo de R$1000,00)
- email: warren@warren.com.br
  password: 123
  (saldo de R$100000,00)

## Arquitetura
A arquitetura foi dividida em camadas, buscando respeitar os princípios
do modelo DDD e da arquitetura limpa.

## Tecnologias utilizadas
- Angular 11
- .Net Core 3.1
- ASP.NET WebApi Core  
- JWT Bearer (ASP.NET Core)
- Entity Framework Core 3.1
- AutoMapper

##Referências Utilizadas
- [Tipos Genéricos EF](http://www.linhadecodigo.com.br/artigo/3347/trabalhando-com-repositorio-generico-no-entity-framework.aspx)
- [Autentcação com JWT Bearer](https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt)
- [Um pouco sobre o conceito de DDD](https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
- [Aplicando DDD](http://www.macoratti.net/20/07/aspnc_ucddd1.htm)
- [Migration](http://www.macoratti.net/20/08/efc_migration1.htm)
- [Modelagem EF](https://docs.microsoft.com/pt-br/ef/core/modeling/)
- [AutoMapper](https://www.luisdev.com.br/2020/08/17/automapper-e-asp-net-core-mapeamento-entre-objetos-parte-1/)
- [Mapeamento EF](http://rsamorim.azurewebsites.net/2017/11/20/mapeando-suas-entidades-com-entity-framework-core-2-0/)
- [Padrão Repository](http://www.macoratti.net/14/04/mvc_crud.htm)
- [Convenções EF (relacionamento um para muitos)](https://www.entityframeworktutorial.net/efcore/one-to-many-conventions-entity-framework-core.aspx)
- [Atualização de dados EF](https://www.entityframeworktutorial.net/efcore/update-data-in-entity-framework-core.aspx)
- [Deletar dados EF](https://www.entityframeworktutorial.net/efcore/delete-data-in-entity-framework-core.aspx)
- [Fluent API EF](https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx)
- [Configuração relacionamento um para muitos](https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx)
- [Configuração relacionamento um para um](https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx)
- [Consulta EF](https://www.entityframeworktutorial.net/efcore/querying-in-ef-core.aspx)
- [Métodos Linq](https://referbruv.com/blog/posts/top-10-linq-methods-we-use-in-our-everyday-csharp-development)
- [Criar projeto Angular](https://www.devmedia.com.br/angular-cli-como-criar-e-executar-um-projeto-angular/38246)
- [Setar dados iniciais in memory EF](https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/)
- [Autenticação Angular](https://jasonwatmore.com/post/2020/07/09/angular-10-jwt-authentication-example-tutorial)

## Autor
Maurício Andrade Gomes [Linkedin](https://www.linkedin.com/in/mauricioandradegomes)
