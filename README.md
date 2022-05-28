# Atividade Final: Projeto de Desenvolvimento de Sistemas de Informação

### Instruções
Os alunos, organizados em equipes de até 7 integrantes, devem desenvolver um sistema com arquitetura definida e seguindo os critérios elencados abaixo. Esse sistema pode ser desenvolvido para qualquer finalidade ou domínio, sendo permitido o uso da linguagem de programação e do Framework que a equipe julgar mais adequado. A entrega deve ser o link de um vídeo, de até 10 minutos, postado em alguma plataforma de streaming, o link do repositório Git do projeto com seu código fonte (o link do repositório Git pode ser substituído pelo código fonte da aplicação compactado em um arquivo ZIP) e um breve relatório (entregue no formato PDF) apontando como o sistema desenvolvido atende aos requisitos elencados.

### Requisitos:

* Deve-se utilizar a arquitetura MVC ou N-Camadas ou Microsserviços (com APIs)
* O Sistema deve conter ao menos 3 entidades completas
* Essas entidades devem possuir, entre elas, ao menos um relacionamento “1-N” e um relacionamento “N-N”.
* Deve-se haver ao menos duas regras de negócios modeladas no sistema.
* Deve haver interação com um banco de dados

## Sobre o Projeto:

* Desenvolvido em .Net na versão 5.0.407 utilizando a arquiterura MVC com Razor Pages.
* Para o cumprimento dos requisitos foram implementados:
  * Arquitetura MVC
  * 4 Entitades completas, sendo elas
    * Carro
    * Proprietário
    * Serviço
    * Agendamento
  * Relação 1-N:
    * 1 Proprietário pode ter N Carros.
  * Relação N-N:
    * N Carros podem ter N Serviços dentro de um agendamento.
  * Para as regras de negócio:
    * Um proprietário não pode ter menos de 18 anos.
    * Um carro não pode ter 2 serviços agendados no mesmo dia.
  * Todos os dados do projeto estão em um banco de dados SQLite.

## Integrantes:

| Nome                            | RA     |
| ------------------------------- | ------ |
| Fernando Hiibner Pinoti Affonso | 608599 |
| Igor Rafael de Sousa            | 607568 |
| Pedro Joaquin Dos Santos Britto | 604038 |
| Renan Kawamoto Da Rocha         | 600997 |
