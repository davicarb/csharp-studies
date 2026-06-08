# 🏦 MultiBanking — Console Fintech

> Sistema de fintech em console desenvolvido com **C#** e **.NET**, focado na prática de **herança** e **encapsulamento**.

---

## 📌 Sobre o projeto

O programa foi construído utilizando a linguagem C# com o ecossistema de desenvolvimento .NET.
O objetivo foi aprender mais sobre a funcionalidade da herança e encapsulamento — portanto o exercício é mais focado em herança, apesar de também possuir funcionalidades do encapsulamento.

O sistema conta com **três tipos de conta**:

| Tier | Conta |
|------|-------|
| 🥉 | Bronze |
| 🥈 | Prata |
| 🥇 | Ouro |

Cada conta herda de uma classe base chamada `ContaBancaria`, herdando seus campos, propriedades e métodos — conforme descrito em `Classes.cs`. Apesar disso, cada uma possui suas próprias características, como **limite de conta** e **taxa de anuidade**.

---

## 🗄️ Database

- **ADO.NET** — acesso e manipulação de dados
- **DB Browser for SQLite** — visualização e gerenciamento do banco

> Este foi provavelmente o último projeto console desenvolvido com ADO.NET, por se tratar de uma ferramenta um pouco datada e muito _low-level_. Futuramente os projetos contarão com **Entity Framework** ou **Dapper**.

---

## 🗂️ Estrutura

Os métodos foram separados em arquivos distintos para facilitar a evolução do projeto ao longo do tempo.

---

## 🚀 Como rodar

1. Adicione todos os arquivos do repositório numa pasta do seu computador
2. Abra o **VS Code**
3. Abra um novo terminal e execute:

```bash
dotnet run
```

---

## 🔮 próximos passos

- Hashing de senhas no database
- Compras de produtos utilizando o limite de crédito
