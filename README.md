# Narad
A framework for pulling configuration information stored in Azure Cosmos DB. This framework will be typically used in a microservices environment and supports .NET Core 2.0.

# Why Cosmos DB?
Cosmos DB is a highly available database offered by Azure. Most of the applications that use centraized configuration like Spring Cloud Config Server have a single point of failure - the configuration storage. This solves that problem.

# How to use the code?
Narad is now available as a Nuget package. Search for "Narad.Extensions.Configuration.CosmosDBCore" or follow this link - https://www.nuget.org/packages/Narad.Extensions.Configuration.CosmosDBCore/.

Most of the sample code is provided - Program.cs and Startup.cs. You will have to configure the appsettings.json with your Cosmos DB configuration values. The sample code expects this JSON structure to be stored in Cosmos DB as a document.

`{`  
`    "id": "1",`  
`    "Foo": "Andersen",`  
`    "Bar": "WA5",`  
`    "Info": {`  
`        "Description": "This is desc",`  
`        "Url": "https://google.com"`  
`    }`  
`}`  
