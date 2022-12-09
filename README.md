![Generic badge](https://img.shields.io/badge/Infnet-orange)
![Generic badge](https://img.shields.io/badge/.NET%207-purple)

# Store Application


## Aula 4

Levantando banco de dados ```docker-compose up```

* Configurando ef globalmente em sua máquina para rodar o migration
```dotnet tool install --global dotnet-ef```

* Criando migration inicial: ```dotnet ef --startup-project .\Store.Web.Mvc\Store.Web.Mvc.csproj migrations add InitialMigration  --output-dir Migrations --project .\Store.Infra.Data\Store.Infra.Data.csproj --verbose```

* Criando atualizando banco de dados: ```dotnet ef --startup-project .\Store.Web.Mvc\Store.Web.Mvc.csproj database update```

- Obs.: Caso já exista um migration rode apenas o update
- Caso precise atualizar a estrutura do banco de dados, adicione/ atualize o migration

## Aula 5

- Utilizando o fluent validator
- Implementação de testes unitários na camada de Domínio
- Dominios ricos vs dominios anêmicos
- Implementando teste unitário na camada de service usando Bogus, AutoMock e Fixture

## Aula 6

- Criando modelo de resposta genérico
- Utilizando Notification pattern de forma a evitar lançar exceções no código
- Iniciar implementação da camada de API

## Aula 7

- Finalizando camada de API
- Implementando Swagger
- Utilizando Data Annotation
