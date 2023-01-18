# SolaryEnergia     

Projeto de Cadastro de Unidades Solares utilizando  C# no BackEnd e SQL Server no banco de dados.
#
<h4>Estou fazendo o back desse projeto, o front foi feito com Angular(git: )</4>
#
<ul>
<li>Para executar esse projeto: 
         abra o terminal na pasta onde deseja clonar o projeto.</li>
</ul>

```` bash
#clone este repsoitorio

$ git clone git@github.com:Elianehenri/SolaryEnergia.git 
````
<li>No arquivo <b style="color:#7b9eeb">appsettings.json</b> no projeto API adicione 
a ConnectionString, seguindo o exemplo 👇<br>
         ```bash
         "ConnectionStrings": {
    "ConexaoBanco": "Server=localhost\\SQLEXPRESS;Database=SolaryEnergia;Trusted_Connection=True;"
  }
  ```

  <li> Com o SQL Server local conectado , digite no terminal o comando 
  <code> dotnet ef database update ou dotnet ef --startup-project ../SolaryEnergia.API/ database update <code></li>
  <li>Execute o projeto<code> dotnet run </code></li>

<h3> Tabelas</h3>
<li>  ![image](https://user-images.githubusercontent.com/91481509/213174898-530ec974-0b16-4993-8357-42b57dc0e445.png)
</li>
