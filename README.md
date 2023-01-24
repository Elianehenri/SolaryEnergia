# SolaryEnergia     

Projeto de Cadastro de Unidades Solares utilizando  C# no BackEnd e SQL Server no banco de dados.
#
<h4>Estou fazendo o back do projeto SolaryEnergia, o front foi feito com Angular( ```` bash git: git@github.com:Elianehenri/SolaryEnergiaFront.git ````)</4>
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


