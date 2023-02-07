![alt text](./doc/label.png)
# [dotnet] Lab Arquitetura 2023
<br />

## Executar os projetos
```bash
# Keycloak - Na pasta bin do keycloac
sh ./kc.sh start-dev --features=declarative-user-profile

# Frontend Angular - Na pasta do angular
ng serve

# Frontend API - Na pasta da api do frontend
## Roda os testes, se não falhar, sobe a API
dotnet test && dotnet run
```

## Referências
- [dotnet core WebAPI](https://learn.microsoft.com/en-us/aspnet/core/web-api/?WT.mc_id=dotnet-35129-website&view=aspnetcore-7.0)
- [Angular](https://angular.io/)
- [Bootstrap](https://getbootstrap.com/docs/5.3/getting-started/introduction/)
- [gRPC](https://grpc.io/)
- [Documentação do Keycloak](https://www.keycloak.org/docs)
- [Testes unitários NUnit](https://www.devmedia.com.br/teste-unitario-com-nunit/41236)
- [Microsserviços](https://learn.microsoft.com/fr-fr/azure/architecture/guide/architecture-styles/microservices)
- [JSON:API - A specification for building APIs in JSON](https://jsonapi.org/)