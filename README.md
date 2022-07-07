# Sistema Escolar - projeto final do curso ofericido pelas empresas Blue e RDI.

[![NPM](https://img.shields.io/npm/l/react)](https://github.com/susanassilva/projetoFinal/blob/main/LICENCE) 

# Sobre o projeto

http://sistemaescolarapi.azurewebsites.net/api/ {digite turma ou aluno após "api/", a depender do que você deseja verificar}

Sistema Escolar é uma API REST desenvolvida em .NET C# que opera com as quatro operações do CRUD (CREATE, READ, UPDATE, DELETE), usando o banco de dados relacional em T-SQL e com deploy na AZURE. Basicamente, a aplicação realiza ações de inclusão, atualização, leitura e exclusão nas Classes Aluno e Turma.

Seguem as funcionalidades da API:
- a. Consultar Todas as Turmas;
- b. Consultar Turma pelo ID;
- c. Consultar todos os alunos;
- d. Consultar aluno pelo ID
- e. Incluir Turmas
- f. Incluir Alunos
- g. Excluir Turmas
- h. Excluir Alunos
- i. Atualizar Turmas
- j. Atualizar Alunos

Além dessas funcionalidades acima, a API tem as seguintes restrições (que foram exigidas como parte da avaliação final):
- a. Um aluno não pode ser incluído sem uma turma.
- b. Uma turma só pode ser excluída se não tiverem alunos cadastrados nela.
- c. Um aluno pode ser movido de turma.
- d. A consulta por turmas (ou alunos) deve obedecer uma regra que é: só retornar alunos cuja condição é ativa(o). No caso desta aplicação, apenas será retornada a condição de aluno ativo ao efetuar a consulta por turmas.


## Diagrama ER 
![Diagrama]()

# Tecnologias utilizadas

- .NET C#
- Azure
- Postman
- Swagger
- NuGet
- Entity FrameworkCore
- Entity FrameworkCore.Proxies
- Entity FrameworkCore.Tools
- Banco de dados: T-SQL

# Como executar o projeto

## Apenas acesso pela web

``` acessar o site
http://sistemaescolarapi.azurewebsites.net/api/

``` digitar a entidade a ser acessada
http://sistemaescolarapi.azurewebsites.net/api/turma
http://sistemaescolarapi.azurewebsites.net/api/aluno
```

## Clonando repositório

```bash
# Clonar repositório
git clone https://github.com/susanassilva/projetoFinal

# Acessar aa pasta do projeto
cd projetoFinal/sistema_escolar

# Instalar Dependências no VisualStudio (caso queira modificá-lo e rodar em sua máquina)
- NuGet
- Entity FrameworkCore
- Entity FrameworkCore.Proxies
- Entity FrameworkCore.Tools

```

# Autora

Susana Santos Silva

https://www.linkedin.com/in/susanassilva

