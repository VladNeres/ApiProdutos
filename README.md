# ApiProdutos

<p>O Projeto APIProdutos, é um projeto de controle de estoque que desenvolvi para aplicar os conhecimentos e praticar novas tecnologias</p>

<ul>
  <li> O Projeto desenvolvido na linguagem C# em .Net 6 tem com arquitetura o padrão MVC + DDD </li>
</ul>
  
## Tecnologias:  
<ul>
  <li> Microsoft.EntityFrameWorkCore para relacionamento de entidades</li>
  <li>Dapper para comunicação com banco de dados Sql Server</li>
  <li>XUnit para realização de testes unitarios, realizando o mock com o NSubstitute</li>
</ul>


   ## WORK FLow  
  <p> Para organização do projeto escolhi trabalhar com os fundamentos do Git flow, visando organização e maior controle do fluxo de trabalho <br>
   </p>

   ![gitflow_completo](https://github.com/VladNeres/ApiProdutos/assets/92832133/16d2c286-9999-4393-a6a9-52a0ceef28a3)


# Como executar a aplicação.

<ol>
<li> Baixe o docker desktop </li>
<li> Baixe o git em sua maquina </li>
<li> Crie uma nova pasta em sua maquina.</li>
<li> Dentro dessa pasta abra um cmd de sua preferencia e clone os projetos a baixo </li>
<li> APIs, (<a href="https://github.com/VladNeres/ApiProdutos"> APIProduto </a>) e a (<a href="https://github.com/VladNeres/ApiEstoque"> APIEstoque</a>) </li>
<li> Abra um cmd de sua preferencia e navegue até a pasta onde voce clonou as APIs e entre em uma das duas pastas (ApiProdutos, ApiEstoque)</li>
<li> Agora que voce esta dentro da pasta de uma das duas apis e com o aplicativo do docker descktop aberto digite em seu cmd (docker-compose up)</li>
</ol>
