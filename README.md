#  Move API ASP.NET Core 3.0

API desenvolvida em ASP.NET Core 3.0 para obter os próximos filmes a serem lançados no cinema.


#  Exemplo de requisição

Opcionalmente você pode especificar uma pagina usando o parâmetro **page**, como é exibido no exemplo a baixo. Caso não seja feito o uso do parâmetro **page**, API retornara apenas 20 filmes.
  - Com **page**
>https://localhost:44309/api/movie/upcoming?page=1

|                |          |                     |                             |
|----------------|----------|---------------------|-----------------------------|
|page            |int       |default:  1          |Opcional                     |

- Sem **page**
>https://localhost:44309/api/movie/upcoming


##  Especificações técnicas

Foi utilizada a estrutura  padrão do ASP.NET Core Web Application e criadas as seguintes camadas:
> Services
- Responsável por fazer a conexão com a API themoviedb;
> Models
- Responsável por receber os dados da requisição feita a API themoviedb.
> ViewModels 
- Responsável por receber os dados modelados para a exibição no json da API.

## Bibliotecas utilizadas

> HttpClient
 - Para o HttpClient foi utilizada o padrão singleton, onde foi criada uma instancia do HttpClient para que fosse possível a utilização em diversos lugares.
> MemoryCache
 - O MemoryCache foi utilizado para realizar o cacheamento dos dados de gêneros por 1 hora, assim evitando requisições excessivas a API themoviedb. 

## Ferramenta utilizada

> Visual Studio 2019 Community
