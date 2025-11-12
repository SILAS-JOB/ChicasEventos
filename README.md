# Chicas Eventos - Plataforma Web de E-commerce

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

## 1. Visão Geral

**Chicas Eventos** é uma aplicação web de e-commerce robusta e completa, desenvolvida como um projeto para clientes. A plataforma é um sistema real para uma empresa de organização de eventos, permitindo que os clientes explorem um catálogo de serviços, montem um carrinho de compras personalizado e enviem um pedido de orçamento detalhado, que é automaticamente encaminhado por e-mail para a equipe de vendas.

O projeto foi construído utilizando a stack de tecnologias da Microsoft, com **ASP.NET Core MVC**, e foi totalmente containerizado com **Docker**, demonstrando práticas modernas de desenvolvimento e deployment.

## 2. Funcionalidades Principais

-   **Catálogo de Serviços Dinâmico:** Apresentação de diferentes categorias de serviços (Buffet, Cerimonial, Audiovisual, RH) com páginas de detalhes para cada item.
-   **Carrinho de Compras Interativo:** Os usuários podem adicionar, remover e visualizar serviços e pacotes em um carrinho de compras persistente na sessão, construído com JavaScript e atualizações parciais via Razor Views.
-   **Formulário de Orçamento:** Um formulário de múltiplos passos onde o cliente preenche suas informações de contato e detalhes do evento.
-   **Notificação por E-mail:** Ao submeter um orçamento, o sistema utiliza a biblioteca **MailKit** para formatar e enviar um e-mail transacional via SMTP, contendo todos os detalhes do pedido para a equipe comercial.
-   **Design Responsivo:** Interface construída com Bootstrap, garantindo uma experiência de usuário consistente em desktops e dispositivos móveis.

## 3. Arquitetura e Destaques Técnicos

A aplicação foi projetada com uma arquitetura limpa e desacoplada, seguindo as melhores práticas de desenvolvimento de software.

-   **Padrão MVC (Model-View-Controller):** A estrutura do projeto segue o padrão MVC do ASP.NET Core, garantindo uma separação clara de responsabilidades:
    -   `Models`: Contém os ViewModels (`OrderFormViewModel`, `CartItemModel`, etc.) que estruturam os dados para as views e para a transferência de informações.
    -   `Views`: Páginas Razor (`.cshtml`) que compõem a UI, com forte uso de Partials para componentização e reutilização de código (ex: `_CartItemsListPartial.cshtml`).
    -   `Controllers`: Orquestram o fluxo de requisições, manipulam a lógica de negócio e interagem com os serviços.

-   **Injeção de Dependência (DI):** O sistema de DI nativo do ASP.NET Core é utilizado para gerenciar o ciclo de vida de serviços, como o `EmailService`, promovendo baixo acoplamento e alta testabilidade.

-   **Camada de Serviço:** A lógica de envio de e-mails e o acesso a dados estáticos são abstraídos em serviços (`EmailService`, `StaticDataServices`), isolando as responsabilidades e tornando os controllers mais enxutos.

-   **Containerização com Docker:** O projeto inclui um `Dockerfile` configurado para construir uma imagem otimizada da aplicação ASP.NET Core. Isso demonstra proficiência em práticas de DevOps, facilitando o deployment, a escalabilidade e a portabilidade da aplicação em qualquer ambiente que suporte Docker.

-   **Configuração Centralizada:** As configurações da aplicação, como os dados do servidor SMTP (`EmailSettings`), são gerenciadas através do `appsettings.json`, permitindo fácil alteração entre ambientes (desenvolvimento, produção) sem a necessidade de recompilar o código.

## 4. Stack de Tecnologias

| Categoria     | Tecnologia                                                                   |
| :------------ | :--------------------------------------------------------------------------- |
| **Backend**   | ASP.NET Core 6+ (MVC), C#                                                    |
| **Frontend**  | HTML5, CSS3, JavaScript (ES6), Razor Views, Bootstrap 5, jQuery              |
| **Email**     | MailKit (Biblioteca .NET para SMTP)                                          |
| **DevOps**    | Docker                                                                       |
| **Servidor**  | Kestrel                                                                      |

## 5. Como Executar o Projeto

Existem duas maneiras principais de executar a aplicação em um ambiente local.

### 5.1. Usando Docker (Recomendado)

Este é o método mais simples e rápido, pois abstrai todas as dependências do ambiente.

**Pré-requisitos:**
-   Docker Desktop instalado e em execução.

**Passos:**
1.  Clone o repositório.
2.  Abra um terminal na raiz do projeto.
3.  Construa a imagem Docker:
    ```bash
    docker build -t chicaseventos .
    ```
4.  Execute o container:
    ```bash
    docker run --rm -p 8080:80 chicaseventos
    ```
5.  Acesse a aplicação em seu navegador: `http://localhost:8080`.

### 5.2. Usando o .NET SDK

**Pré-requisitos:**
-   .NET SDK 6.0 ou superior.

**Passos:**
1.  Clone o repositório.
2.  Configure as credenciais de SMTP no arquivo `appsettings.Development.json` para que a funcionalidade de envio de e-mail funcione. Crie o arquivo se ele não existir, seguindo a estrutura do `EmailSettings.cs`:
    ```json
    {
      "EmailSettings": {
        "SmtpServer": "seu-servidor-smtp",
        "Port": 587,
        "Username": "seu-email",
        "Password": "sua-senha",
        "SenderName": "Chicas Eventos",
        "SenderEmail": "seu-email"
      }
    }
    ```
3.  Abra um terminal na raiz do projeto.
4.  Restaure as dependências:
    ```bash
    dotnet restore
    ```
5.  Execute a aplicação:
    ```bash
    dotnet run
    ```
6.  Acesse a aplicação no endereço indicado no terminal (geralmente `http://localhost:5000` ou `https://localhost:5001`).
