# LeilaoApp

# BackEnd

- CRUD de um sistema de leilões, com listagem dos itens cadastrado e login e autenticação de usuários.
- Desenvolvido em ASP.NET CORE 3.1 e EF CORE utilizando o padrão CQRS.
Esse padrão irá segregar a API em leitura e escrita, utilizando na parte de domínio conceitos como commands, handlres e queries. Outros conceitos importantêntes utilizados na API foram repositories, domain notifications, desing by contracts, SOLID e clean code.

Testes - é possível a realização de testes em todas as camadas da API: teste de entrada, teste sobre queries, fake repository, fail fast validation...

Na parte de infra foi utilizado o migrations do EF CORE 3.1 para gerar a base de dados, e é possível utilizar a API acionando a base de dados local (localDb) ou banco de dados em memória.
- Para usar a aplicação utilizando o banco em memória, descomentar a linha 28 do Startup.cs e comentar a linha 29.

A autorização e autenticação da API foi feito com o login do Google e token, pelo Firebase.

Antes de rodar a API:
dotnet restore

Para utilizar o migrations com banco local:
- acessar Leilao.Infra executar o comando > dotnet ef migrations add Initial --startup-project ..\Leilao.Api\ 
e depois > dotnet ef database update --startup-project ..\Leilao.Api\

Para testar o requisito de usuário ativo e inativo:
Desativar usuário
com a API rodando, acessar pelo Postman chamando a requisição GET > https://localhost:44378/v1/leiloes/user/all
serão retornados os usuários cadastrados no sistema (se houver algum)
em seguida pegue o Id e o User retornado do usuário que deseja desativar e coloque no body da requisição de PUT > https://localhost:44378/v1/leiloes/user/disable 
Para habilitar faça o mesmo processo chamando https://localhost:44378/v1/leiloes/user/enable

# FrontEnd
SPA constituída em Angular 10 e estilo do bootstrap 4.
Utilizando conceitos de rotas e subscribe para efeturar requisições http, 

-Login e autenticação do Goggle pelo Firebase

Antes de rodar o frontend:
npm i
Para executar:
ng serve -o


