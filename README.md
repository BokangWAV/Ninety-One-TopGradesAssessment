---

# TopGradesApp

## Overview

**TopGradesApp** is a simple C# console application that:

* Reads student scores from a CSV/txt file.
* Displays the top score(s) alphabetically if multiple students share the same score.
* Stores all scores in a local SQLite database (`students.db`).
* Provides a simple for a REST API with endpoints to add new scores and retrieve scores.

In this project I used **C# OOP, file I/O, database integration, and basic sorting**.

---

## Features

1. **CSV Reading & Validation**

   * Reads `TestData.csv` (format: `First Name,Second Name,Score`).
   * Validates that each row has correct data types.

2. **Top Scores**

   * Sorts students by score descending.
   * Handles multiple top scorers and displays them alphabetically.

3. **Database Storage**

   * Creates `students.db` if it doesn’t exist.
   * Stores all student scores in a `Students` table.

4. **Potential(Simple) API Endpoints**

   * `POST /scores` → Add a new student score.
   * `GET /student?firstName=&secondName=` → Retrieve a specific student's score.
   * `GET /top-scores` → Retrieve all top scorers.

5. **Security** (for API)

   * Endpoints could be secured using **API keys**.

6. **Cloud Deployment** (optional)

   * API hosted on **Azure App Service**.
   * Database hosted on **Azure SQL Database**.
   * UI built with **React**.

---

## Getting Started

### Requirements

* [.NET 10 SDK](https://dotnet.microsoft.com/)
* `Microsoft.Data.Sqlite` NuGet package
* macOS / Windows / Linux (cross-platform)

### Setup

1. Clone the repository:

```bash
git clone https://github.com/yourusername/TopGradesApp.git
cd TopGradesApp
```

2. Restore dependencies:

```bash
dotnet restore
```

3. Run the program:

```bash
dotnet run
```

* The program reads `TestData.csv`, displays the top scorers in the console, and stores all entries in `students.db`.

---

## CSV Format Example

```
First Name,Second Name,Score
Dee,Moore,56
Sipho,Lolo,78
Noosrat,Hoosain,64
George,Of The Jungle,78
```

---

## Project Structure

```
TopGradesApp/
├─ Program.cs       # Main program
├─ Database.cs      # SQLite helper methods
├─ TestData.csv     # Example data
├─ ExampleData.csv     # To test it is not working for only provided data
├─ students.db      # SQLite database (generated)
├─ TopGradesApp.csproj
└─ README.md
```

---

---

## Author

Bokang Molepo
