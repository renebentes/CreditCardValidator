# Validador de Cartão de Crédito

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

> [!IMPORTANT]
> Trata-se de um desafio de projeto proposto pela trilha Microsoft 50 Anos - GitHub Copilot promovido pela DIO como forma de exercitar os conteúdos apresentados.

## Sumário

- [Sobre](#sobre)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Funcionalidades](#funcionalidades)
- [Como começar](#como-começar)
- [Exemplos de Números de Cartão Válidos](#exemplos-de-números-de-cartão-válidos)
- [Contribuindo](#contribuindo)
- [Notas de Lançamento](#notas-de-lançamento)
- [Licença](#licença)

## Sobre

Este é um aplicativo de console simples desenvolvido com .NET 9 que valida números de cartões de crédito e identifica suas bandeiras. O aplicativo suporta as seguintes bandeiras de cartão:

- American Express (Amex)
- DinersClub
- Discover
- Elo
- Hipercard
- JCB
- Mastercard
- Visa

> [!WARNING] **Limitação:** Atualmente, apenas essas bandeiras são suportadas.

## Tecnologias Utilizadas

- [.NET](https://dot.net)
- [GitHub Copilot](https://github.com/features/copilot)

## Funcionalidades

- Valida números de cartão de crédito utilizando o algoritmo de Luhn.
- Identifica a bandeira do cartão com base no formato do número.

## Como começar

### Pré-requisitos

- SDK do .NET 9 instalado em sua máquina.

### Executando o Aplicativo

1. Clone o repositório ou baixe o código-fonte.
2. Abra um terminal e navegue até o diretório do projeto.
3. Execute o seguinte comando para compilar o projeto:

   ```sh
   dotnet build
   ```

4. Após compilar, execute o aplicativo com:

   ```sh
   dotnet run
   ```

5. Siga as instruções para digitar um número de cartão de crédito para validação.

## Exemplos de Números de Cartão Válidos

> [!NOTE]
> Estes exemplos são apenas para fins de teste e não representam cartões reais.

- AmericanExpress: `3782 8224 6310 005`
- DinersClub: `3002 6311 7301 20`
- Discover: `6221 2687 5844 4692`
- Elo: `5090 4897 3358 7633`
- Hipercard: `6062 8217 8583 4814`
- JCB: `3589 7195 6365 1155`
- Mastercard: `5500 0000 0000 0004`
- Visa: `4111 1111 1111 1111`

## Autor

[Rene Bentes Pinto](http://github.com/renebentes)

## Contribuindo

Contribuições são bem-vindas!

Se você achar algum problema ou tiver sugestões para melhorias, por favor, abra uma [_Issue_][issues] ou envie uma [_Pull Request (PR)_][pulls] para nosso [repositório][repo].

Você também pode verificar as _Issues_ e _Pull Requests_ existentes com os quais poderia ajudar.

Ao contribuir com este projeto, por favor, siga o estilo de codificação existente, use [conventional commits][] em suas mensagens de commit e submeta suas alterações em uma branch separada.

## Notas de Lançamento

Você pode [ver as notas de lançamento aqui.][changelog]

## Licença

Copyright (c) 2025 Rene Bentes Pinto

Este projeto está sob a licença **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

[repo]: http://github.com/renebentes/CreditCardValidator
[issues]: http://github.com/renebentes/CreditCardValidator/issues
[pulls]: http://github.com/renebentes/CreditCardValidator/pulls
[changelog]: http://github.com/renebentes/CreditCardValidator/commits
[conventional commits]: https://www.conventionalcommits.org/en/v1.0.0/
