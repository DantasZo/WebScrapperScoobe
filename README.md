# Web Scraper para Skoob

Este projeto é um web scraper desenvolvido em C# para coletar informações de livros lidos por um usuário na plataforma Skoob. O scraper automatiza o processo de login, navegação e extração de dados, facilitando a coleta de informações sobre os livros lidos pelo usuário.

## Funcionalidades

- **Login Automático**: Realiza o login na plataforma Skoob usando credenciais fornecidas.
- **Navegação Automática**: Navega até a estante de livros do usuário.
- **Coleta de Dados**: Extrai informações sobre os livros lidos, incluindo títulos e detalhes adicionais.
- **Paginação**: Capaz de navegar por múltiplas páginas da estante de livros.
- **Armazenamento de Dados**: Salva as informações coletadas em um arquivo de texto.

## Pré-requisitos

- .NET Core SDK
- Selenium WebDriver
- ChromeDriver
- HtmlAgilityPack

## Configuração

1. Clone este repositório.
2. Instale as dependências necessárias via NuGet:
   ```
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.WebDriver.ChromeDriver
   dotnet add package HtmlAgilityPack
   ```
3. Configure as seguintes variáveis no código:
   - `email`: Seu email de login no Skoob
   - `pass`: Sua senha de login no Skoob
   - `filePath`: Caminho onde o arquivo de saída será salvo
   - Ajuste o caminho do ChromeDriver conforme necessário

## Uso

1. Execute o programa:
   ```
   dotnet run
   ```
2. O scraper irá:
   - Fazer login no Skoob
   - Navegar até a estante de livros
   - Coletar informações dos livros
   - Salvar os dados em um arquivo de texto

3. Ao finalizar, o programa perguntará se você deseja encerrar ou aguardar.

## Limitações

- O scraper está configurado para coletar dados de até 6 páginas da estante de livros.
- É necessário respeitar os termos de uso do Skoob e não sobrecarregar o servidor com requisições excessivas.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests com melhorias.

## Aviso Legal

Este scraper é destinado apenas para uso pessoal e educacional. Certifique-se de respeitar os termos de serviço do Skoob e as leis de direitos autorais ao utilizar os dados coletados.

---
Resposta do Perplexity: pplx.ai/share
