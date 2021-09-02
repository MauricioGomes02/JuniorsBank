<h1 align="center">Junior's Bank</h1>
<p align="center">Trata-se de um sistema simples com o intuito de 
replicar a funcionalidade de uma Conta Corrente.</p>

Tabela de conteúdos
=================
<!--ts-->
* [Nome do Projeto](#nomeProjeto)
* [Sobre](#sobre)
* [Como utilizar](#utilizacao)
* [Arquitetura](#arquitetura)
* [Tecnologias Utilizadas](#tecnologias)
* [Referências Utilizadas](#referencias)  
* [Autor](#autor)
<!--te-->
<h1 align="left" id="nomeProjeto">Junior's Bank</h1>
<h1 align="left" id="sobre">Sobre</h1>
<p align="left">Trata-se de um sistema simples com o intuito de 
replicar a funcionalidade de uma Conta Corrente.</p>
<h1 align="left" id="utilizacao">Como Utilizar</h1>
<p>Primeiramente, será necessário clonar o projeto em sua máquina. 
Para isso, navegue até a pasta que deseja baixar o projeto e rode
o seguinte comando (importante ter o <a href="https://git-scm.com/downloads">git</a> 
baixado).</p>
```
git clone https://github.com/MauricioGomes02/JuniorsBank.git
```
<p>Em seguida, navegue até a pasta do projeto web 'JuniorsBank.API' e
rode o seguinte comando em seu terminal (importante ter as 
<a href="https://dotnet.microsoft.com/download/dotnet/3.1">
ferramentas para utilização do Asp.Net Core 3.1</a>).</p>
```
dotnet run
```
<p>Você irá precisar agora ir até a pasta do projeto angular 'Frontend/JuniorsBank'.</p>
<p>Rode o seguinte comando para baixar as dependência necessárias 
(importante o <a href="https://nodejs.org/pt-br/download/">node</a> estar baixado).</p>
```
npm i
```
<p>ou</p>
```
npm install
```
<p>Após finalizado o processo de download das dependências, execute o comando</p>
```
ng serve
```
<p>Abra seu navegador e acesse o link <a href="http://localhost:4200">http://localhost:4200</a></p>
<p>A aplicação já possui dois usuários criados com suas respectivas contas
e com valores depositados.</p>
<p>Dados para acesso:</p>
- email: mauricioandradegomes@gmail.com
  password: 123
  (saldo de R$1000,00)
- email: warren@warren.com.br
  password: 123
  (saldo de R$100000,00)

<h1 id="arquitetura">Arquitetura</h1>
<p>A arquitetura foi dividida em camadas, buscando respeitar os princípios
do modelo DDD e da arquitetura limpa</p>

<h1 id="tecnologias">Tecnologias utilizadas</h1>
- Angular 11
- .Net Core 3.1
- ASP.NET WebApi Core
- Entity Framework Core 3.1
- AutoMapper

<h1 id="referencias">Referências Utilizadas</h1>
- <a href="http://www.linhadecodigo.com.br/artigo/3347/trabalhando-com-repositorio-generico-no-entity-framework.aspx">Tipos Genéricos EF</a>
- <a href="https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt">Autentcação com JWT Bearer</a>
- <a href="https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice">Um pouco sobre o conceito de DDD</a>
- <a href="http://www.macoratti.net/20/07/aspnc_ucddd1.htm">Aplicando DDD</a>
- <a href="http://www.macoratti.net/20/08/efc_migration1.htm">Migration</a>
- <a href="https://docs.microsoft.com/pt-br/ef/core/modeling/">Modelagem EF</a>
- <a href="https://www.luisdev.com.br/2020/08/17/automapper-e-asp-net-core-mapeamento-entre-objetos-parte-1/">AutoMapper</a>
- <a href="http://rsamorim.azurewebsites.net/2017/11/20/mapeando-suas-entidades-com-entity-framework-core-2-0/">Mapeamento EF</a>
- <a href="http://www.macoratti.net/14/04/mvc_crud.htm">Padrão Repository</a>
- <a href="https://www.entityframeworktutorial.net/efcore/one-to-many-conventions-entity-framework-core.aspx">Convenções EF (relacionamento um para muitos)</a>
- <a href="https://www.entityframeworktutorial.net/efcore/update-data-in-entity-framework-core.aspx">Atualização de dados EF</a>
- <a href="https://www.entityframeworktutorial.net/efcore/delete-data-in-entity-framework-core.aspx">Deletar dados EF</a>
- <a href="https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx">Fluent API EF</a>
- <a href="https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx">Configuração relacionamento um para muitos</a>
- <a href="https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx">Configuração relacionamento um para um</a>
- <a href="https://www.entityframeworktutorial.net/efcore/querying-in-ef-core.aspx">Consulta EF</a>
- <a href="https://referbruv.com/blog/posts/top-10-linq-methods-we-use-in-our-everyday-csharp-development">Métodos Linq</a>
- <a href="https://www.devmedia.com.br/angular-cli-como-criar-e-executar-um-projeto-angular/38246">Criar projeto Angular</a>
- <a href="https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/">Setar dados iniciais in memory EF</a>
- <a href="https://jasonwatmore.com/post/2020/07/09/angular-10-jwt-authentication-example-tutorial">Autenticação Angular</a>

<h1 id="autor">Autor</h1>
<p>Maurício Andrade Gomes <a href="https://www.linkedin.com/in/mauricioandradegomes">Linkedin</a></p>
