# 💧 Habit Logger

A console-based Habit Tracker built with C# and SQLite as part of the
[C# Academy](https://www.thecsharpacademy.com/) curriculum. This project
introduces database-driven development using ADO.NET to perform full
CRUD operations against a real SQLite database.

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [How to Use](#how-to-use)
- [Project Structure](#project-structure)
- [New Concepts Learned](#new-concepts-learned)
- [Technologies Used](#technologies-used)
- [License](#license)

---

## 📖 About the Project

Habit Logger is a C# console application that tracks daily water intake
(glasses of water per day). Every record is stored in a real SQLite
database file that persists between sessions. The app demonstrates full
CRUD functionality — Create, Read, Update, and Delete — using ADO.NET
to communicate directly with the database using raw SQL commands.

---

## ✨ Features

- Log daily water intake by date and quantity
- View all logged habit entries
- Update an existing entry
- Delete an existing entry
- SQLite database created automatically on first run
- All errors handled gracefully — app never crashes
- Follows the DRY (Don't Repeat Yourself) principle

---

## ✅ Requirements

| # | Requirement |
|---|-------------|
| 1 | Log occurrences of a habit tracked by quantity |
| 2 | Users input the date of each occurrence |
| 3 | Data is stored and retrieved from a real SQLite database |
| 4 | Database and table are created automatically on startup |
| 5 | Users can Insert, Delete, Update and View logged habits |
| 6 | All possible errors are handled — app never crashes |
| 7 | Only ADO.NET used — no Entity Framework or Dapper |
| 8 | DRY Principle followed throughout |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Visual Studio Code](https://code.visualstudio.com/) with the
  [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

### Installation

1. Clone the repository:
```bash
   git clone git@github.com:Timothynyezi/HabitLogger.git
```

2. Navigate into the project directory:
```bash
   cd HabitLogger
```

3. Install dependencies:
```bash
   dotnet restore
```

4. Run the application:
```bash
   dotnet run
```

> The SQLite database file `habitlogger.db` is created automatically
> on first run — no setup required.

---

## 💧 How to Use

1. Launch the app with `dotnet run`
2. From the main menu, choose an option:
   - **1** — Log a new water intake entry
   - **2** — View all logged entries
   - **3** — Update an existing entry
   - **4** — Delete an entry
   - **0** — Exit
3. When logging, enter the date and number of glasses consumed
4. When updating or deleting, enter the ID of the record to modify

---

## 📁 Project Structure
```
HabitLogger/
├── Program.cs            # Entry point — starts the app and menu loop
├── DatabaseManager.cs    # All database operations (CRUD via ADO.NET)
├── UserInterface.cs      # All console input and output
├── HabitEntry.cs         # Data model representing one habit record
├── HabitLogger.csproj    # Project configuration and dependencies
├── habitlogger.db        # Auto-generated SQLite database file
└── README.md             # Project documentation
```

---

## 🧠 New Concepts Learned

| Concept | Description |
|---|---|
| SQLite | A lightweight file-based relational database |
| ADO.NET | Built-in C# library for raw database communication |
| SQL `CREATE TABLE` | Define a table structure in the database |
| SQL `INSERT INTO` | Add a new record to a table |
| SQL `SELECT` | Query and retrieve records from a table |
| SQL `UPDATE` | Modify an existing record |
| SQL `DELETE` | Remove a record from the database |
| `SqliteConnection` | Opens a connection to the SQLite database file |
| `SqliteCommand` | Executes a SQL statement against the database |
| `SqliteDataReader` | Reads rows returned from a SELECT query |
| Parameterised queries | Safely pass user input into SQL without SQL injection |

---

## 🛠 Technologies Used

- **Language:** C#
- **Framework:** .NET (Console Application)
- **Database:** SQLite via `Microsoft.Data.Sqlite`
- **Data Access:** ADO.NET (raw SQL — no ORM)
- **IDE:** Visual Studio Code + C# Dev Kit
- **Version Control:** Git & GitHub

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

*Built as part of the [C# Academy](https://www.thecsharpacademy.com/)
— C# Foundation track.*