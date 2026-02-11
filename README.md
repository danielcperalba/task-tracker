# Task Tracker CLI

Um aplicativo de linha de comando simples e eficiente para gerenciar suas tarefas diárias.

## 📋 Sobre o Projeto

Task Tracker CLI é uma ferramenta de gerenciamento de tarefas que roda diretamente no terminal. Desenvolvido em .NET 8 e C#, permite adicionar, atualizar, deletar e organizar suas tarefas de forma rápida e prática, armazenando tudo em um arquivo JSON local.

## ✨ Funcionalidades

- ✅ Adicionar novas tarefas
- ✏️ Atualizar descrição de tarefas existentes
- 🗑️ Deletar tarefas
- 🔄 Marcar tarefas como "em progresso"
- ✔️ Marcar tarefas como "concluídas"
- 📊 Listar todas as tarefas
- 🔍 Filtrar tarefas por status (pendente, em progresso, concluída)

## 🚀 Como Usar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado

### Instalação

1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/task-tracker-cli.git
cd task-tracker-cli
```

2. Compile o projeto
```bash
dotnet build
```

### Comandos Disponíveis

#### Adicionar uma tarefa
```bash
dotnet run add "Comprar mantimentos"
# Output: Task added successfully (ID: 1)
```

#### Atualizar uma tarefa
```bash
dotnet run update 1 "Comprar mantimentos e frutas"
```

#### Deletar uma tarefa
```bash
dotnet run delete 1
```

#### Marcar tarefa como "em progresso"
```bash
dotnet run mark-in-progress 1
```

#### Marcar tarefa como "concluída"
```bash
dotnet run mark-done 1
```

#### Listar todas as tarefas
```bash
dotnet run list
```

#### Listar tarefas por status
```bash
# Listar apenas tarefas pendentes
dotnet run list todo

# Listar apenas tarefas em progresso
dotnet run list in-progress

# Listar apenas tarefas concluídas
dotnet run list done
```

## 📁 Estrutura de Dados

Cada tarefa possui as seguintes propriedades:

- **id**: Identificador único da tarefa
- **description**: Descrição da tarefa
- **status**: Status atual (`todo`, `in-progress`, `done`)
- **createdAt**: Data e hora de criação
- **updatedAt**: Data e hora da última atualização

As tarefas são armazenadas em um arquivo `tasks.json` no diretório do projeto.

## 🛠️ Tecnologias Utilizadas

- .NET 10
- C#
- System.Text.Json (para manipulação de JSON)

## 📝 Exemplo de Uso Completo
```bash
# Adicionar tarefas
dotnet run add "Estudar C#"
dotnet run add "Fazer exercícios"
dotnet run add "Ler documentação .NET"

# Marcar uma tarefa como em progresso
dotnet run mark-in-progress 1

# Marcar uma tarefa como concluída
dotnet run mark-done 2

# Listar todas as tarefas
dotnet run list

# Listar apenas tarefas concluídas
dotnet run list done
```

## 📄 Licença

Este projeto está sob a licença MIT.

## 👨‍💻 Autor

Desenvolvido como projeto de aprendizado em .NET

---

**Projeto baseado no desafio:** [roadmap.sh - Task Tracker](https://roadmap.sh/projects/task-tracker)