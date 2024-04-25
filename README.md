Instruçoes para uso do sistema:

1) Certifique-se de usar o banco de dados SQL Server.

2) Abra o SQL Server, localize o nome do servidor e mude para o servidor local. Em seguida, selecione a opção "Autenticação do Windows" e conecte-se.

3) Depois de conectar, dentro do Visual Studio localize o campo "ConnectionStrings" > "LocalSqlServer" no arquivo appsettings.json e altere-o para as configurações do servidor que você irá utilizar. Para rodar localmente, deve ficar assim:
"Server=<Nome do servidor>;Database=APIGerenciamentoDePacientes;Integrated Security=True;TrustServerCertificate=True;"

4) Ainda dentro do Visual Studio, vá em "Ferramentas" > "Gerenciador de Pacotes NuGet" > "Console do Gerenciador de Pacotes" e execute o comando Update-Database.

5) Se tudo correr bem, a conexão com o banco de dados deve estar funcionando. Execute a API e anote a URL com a porta que será usada posteriormente no próximo passo.

6) Abra a pasta sistema-gerenciamento-pacientes-front no editor de código de sua preferência.

7) Certifique-se de ter o Node.js, o npm e o Vue instalados.

8) Abra o terminal e execute o comando npm install

9) Agora, dentro de App.vue, localize o campo API_ROUTE e substitua a URL pela URL da API que está rodando localmente em seu computador.

10) Use o comando 'npm run dev' para iniciar a aplicação.

11) Anote a URL que está rodando sua aplicação front para o próximo passo.

12) Agora, dentro da API, vá em Program.cs e localize este trecho de código:
build.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();

13) Substitua a URL da aplicação front neste trecho pelo endereço anotado anteriormente.

14) Rode a API novamente e, em seguida, sua aplicação front. Tudo deve estar funcionando normalmente.

