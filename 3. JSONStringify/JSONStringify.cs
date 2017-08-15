using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class JSONStringify
{
    static void Main()
    {
        var students = new List<Student>();

        var input = Console.ReadLine();

        while (input != "stringify")
        {
            var tokens = input.Split(new[] { ' ', ':', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var grades = tokens.Skip(2).Select(int.Parse).ToList();

            var newStudent = new Student
            {
                Name = name,
                Age = age,
                Grades = grades
            };

            students.Add(newStudent);

            input = Console.ReadLine();
        }

        var result = new StringBuilder();

        result.Append("[");

        foreach (var student in students)
        {
            result.Append($"{{name:\"{student.Name}\",age:{student.Age},grades:[{string.Join(", ", student.Grades)}]}},");
        }
        
        result.Remove(result.Length - 1, 1);
        result.Insert(result.Length, "]", 1);

        Console.WriteLine(result.ToString());
    }
}

class Student
{
    public string Name { get; set; }

    public int Age { get; set; }

    public List<int> Grades { get; set; }
}

