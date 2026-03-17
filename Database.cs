using System;
using System.IO;
using System.Data.SQLite;

public static class Database
{
    public static void CreateDatabase(string dbFile)
    {
        if (!File.Exists(dbFile))
        {
            SQLiteConnection.CreateFile(dbFile);
        }

        using var conn = new SQLiteConnection($"Data Source={dbFile};Version=3;");
        conn.Open();

        string tableCmd = @"
            CREATE TABLE IF NOT EXISTS Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                SecondName TEXT NOT NULL,
                Score INTEGER
            )";

        using var cmd = new SQLiteCommand(tableCmd, conn);
        cmd.ExecuteNonQuery();
    }

    public static void InsertStudent(string dbFile, string firstName, string secondName, int score)
    {
        using var conn = new SQLiteConnection($"Data Source={dbFile};Version=3;");
        conn.Open();

        using var cmd = new SQLiteCommand(conn);
        cmd.CommandText = "INSERT INTO Students (FirstName, SecondName, Score) VALUES (@f, @s, @sc)";
        cmd.Parameters.AddWithValue("@f", firstName);
        cmd.Parameters.AddWithValue("@s", secondName);
        cmd.Parameters.AddWithValue("@sc", score);
        cmd.ExecuteNonQuery();
    }
}