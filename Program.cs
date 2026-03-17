// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; // Required for LINQ extension methods
using System.Data.SQLite;


// A student class to store each entry as an object
    class Student
{
    public string FirstName {get; set;}
    public string SecondName {get; set;}
    public int Score {get; set;}

    public Student(string firstName, string secondName, int score)
    {
        FirstName = firstName;
        SecondName = secondName;
        Score = score;
    }

    public string FullName()
    {
        return FirstName + " " + SecondName;
    }

    public void Display()
    {
        Console.WriteLine($"{FirstName} {SecondName} : {Score}");
    }

}



class Program {


    // Read the file txt or csv

    static Student ParseStudent(string line)
    {
        string[] students = line.Split(",");
        //In the event that there isnt the FirstName, SecondName & Score provided
        if(students.Length != 3)
        {
            Console.WriteLine("InSufficent Information Provided: Data must be First Name, Second Name & Score");
            return null;
        }

        if(!int.TryParse(students[2], out int score))
        {
            Console.WriteLine("Incorrect type for score: Should be INT");
            return null;
        }

        return new Student(students[0], students[1], score);

    }

    static List<Student> storeStudents(string[] lines)
    {
        //Store each student in list 
        List<Student> students = new List<Student>();

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            Student s = ParseStudent(lines[i]);

            if (s != null)
            {
                students.Add(s);
            }
        }
        return students;
    }


    static void displayHighestScore(List<Student> students)
    {
        students = students.OrderByDescending(student => student.Score).ToList();
        int maxScore = students[0].Score;
        List<Student> topStudents = new List<Student>();
        foreach(Student s in students)
        {
            if(s.Score == maxScore)
            {
                topStudents.Add(s);
            }
        }

        topStudents.Sort((a, b) => a.FullName().CompareTo(b.FullName()));

        // Step 4: Display
        foreach (Student s in topStudents)
        {
            Console.WriteLine(s.FullName());
        }
        Console.WriteLine($"Score: {maxScore}");
    }

    static void createDatabase(string[] lines)
    {
        string dbFile = "students.db";

        Database.CreateDatabase(dbFile);
        
        for (int i = 1; i < lines.Length; i++) // skip header
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length != 3) continue;
            if (!int.TryParse(parts[2], out int score)) continue;

            Database.InsertStudent(dbFile, parts[0], parts[1], score);
        }

        Console.WriteLine("CSV data inserted into the database successfully!");
    }


    
    static void Main() {

        string[] lines = File.ReadAllLines("TestData.csv");
        if(lines.Length == 0)
        {
            Console.WriteLine("No data provided");
            return;
        }

        List<Student> allStudents = storeStudents(lines);
        // we sort our list by the score here

        displayHighestScore(allStudents);

        // Database create
        createDatabase(lines);
    }
}