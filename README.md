API desenvolvidA em ASP NET CORE C#, CRUD MVC que faz cadastro de candidato a vagas de emprego. Para testar os métodos GET/POST/PUT/DELETE pode se usar ou Power Shell ou Postman. 
 Seguem os comandos

POST =

{
    "nome" : "",
    "email" : "",
    "telefone" : "",
    "vaga" : "",
    "local" : "",
    "cidade" : "",
    "estado" : ""

}

PUT = 
{
    "candidatoid" : "Nº", ***(Colocar o numero do id do candidato e atualizar as infos necessárias)
    "nome" : "",
    "email" : "",
    "telefone" : "",
    "endereco" : {
    "local" : "",
    "cidade" : "",
    "estado" : ""
    }

}

GET = https://apicandidatos.azurewebsites.net/api/candidatos?incluirendereco=true

DELETE = https://apicandidatos.azurewebsites.net/api/candidatos?id=Nº (Colocar o numero do id do candidato)

LINK API AZURE-
https://apicandidatos.azurewebsites.net/

