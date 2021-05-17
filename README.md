# Execução #

1. Para execucao e necessário, copiar o arquivo input-routes.csv para pasta C:\temp.
2. Para executar o console, e necessário setar o projeto brivva.teste.console como inicializacao.
3. Para executar a api, e necessário  setar o projeto brivva.teste.api como inicializacao.

## Input Example Console##
```
GRU-BRC
BRC-SCL
GRU-CDG
```

## Input Example API ## 
{
  "origin": "GRU",
  "destiny": "BRC",
  "stops": [
    "SCL",
     "CDG"
  ],
  "value": 70
}

### Estrutura do programa ###
A aplicacao esta estruturada em uma unica solução, onde o console esta no projeto brivva.teste.console e api no brivva.teste.api.
O core esta as entidades, servicos e validacoes.
No data esta as conexoes externas, no caso com o arquivo csv.
No infrastructure esta a injecao de dependencia, e generico.
tdd esta os teste unitarios da service, mockando as conexoes externas.


