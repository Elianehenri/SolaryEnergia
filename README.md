# SolaryEnergia     


Projeto de Cadastro de Unidades Solares utilizando  C# no BackEnd e SQL Server no banco de dados.

<p style="margin-top: 20px">

<h2>🛠️ Tecnologias </h2>  
<ul>
    <li>C#</li>
    <li>dotNet</li>
    <li>SQL Server</li>
</ul>
<p style="margin-top: 20px">
<p>Para executar esse projeto: </p>
<ul>
         <li>Abra o terminal na pasta onde deseja clonar o projeto.</li>
</ul>

```` bash
#clone o repositorio

$ git clone git@github.com:Elianehenri/SolaryEnergia.git 
````
<li>No arquivo <b style="color:#7b9eeb">appsettings.json</b> no projeto API adicione 
a ConnectionString, seguindo o exemplo 👇</li><br>
         
```` bash
     $ "ConnectionStrings": {
    "ConexaoBanco": "Server=localhost\\SQLEXPRESS;Database=SolaryEnergia;Trusted_Connection=True;"
  }
 ````

  <li> Com o SQL Server local conectado , digite no terminal do proejto Infra o comando :</li>
 
   ```bash
   $ dotnet ef database update ou dotnet ef --startup-project ../SolaryEnergia.API/ database update
  ``` 
  <li>Execute o projeto<code></code></li>
  
   ```bash  
    $ dotnet run 
   ```
  <p style="margin-top: 20px"> 
<div align="center" width="100%">
<img class="logo-nav" height="45%" width="90%" src="/imagem.png" alt="img imagem">
<img class="logo-nav" height="45%" width="45%" src="imagem1.png" alt="img imagem1">
 
 <img class="logo-nav" height="22%" width="45%" src="imagem3.png" alt="img imagem3">
 </div>


