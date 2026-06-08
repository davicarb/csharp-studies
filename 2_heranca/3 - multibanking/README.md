## multi-banking - console fintech ##

* o programa foi construído utilizando a linguagem C# com o ecossistema de desenvolvimento dotnet.
o objetivo do programa foi aprender mais sobre a funcionalidade da herança e encapsulamento.
(portanto o exercício é mais focado em herança, apesar de também possuir funcionalidades do encapsulamento).

* para o database foi utilizado:
  - ado.net;
  - dbbrowser for SQLITE.

* este foi provavelmente o ultimo projeto console que desenvolvi utilizando ado.net, por se tratar de uma ferramenta
um pouco datada e muito low-level. futuramente meus projetos contarão com o Entity Framework ou Dapper.

a ideia do projeto era ser desenvolvido um sistema de fintech que conta com três tipos de conta:
  -> Bronze;
  -> Prata;
  -> Ouro.

* cada conta herda de uma classe base chamada ContaBancaria. logo, herdam campos, propriedades e métodos desta, como está
descrito no *Classes.cs*.
apesar de herdarem os campos da classe base, cada uma possuem suas próprias características, como limite de conta, e taxa
de anuidade.

* separei os métodos em arquivos para facilitar a evolução do projeto ao longo do tempo.
(apesar de se tratar de um projeto console, planejo implementar mais funcionalidades nele, como hashing das senhas no database
e também compras de produtos utilizando o limite de crédito.)

## como rodar o projeto ##
1. adicione todos os arquivos que estão no repositório numa pasta do seu computador;
2. abra o vscode;
3. abra um novo terminal e digite: *dotnet run*
