using System;
using System.Collections.Generic;
using System.Linq;

class JSONParse
{
    static void Main()
    {
        var students = new List<Student>();

        var input = Console.ReadLine();

        var tokens = input.Split(new[] { ' ', '[', ']', '{', '}', ':', '"', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var age = 0;
        var name = string.Empty;
        var grades = new List<int>();

        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] == "name")
            {
                name = tokens[i + 1];
            }
            else if (tokens[i] == "age")
            {
                age = int.Parse(tokens[i + 1]);
            }
            else if (tokens[i] == "grades")
            {
                var number = 0;

                if (i < tokens.Count - 1)
                {
                    while (int.TryParse(tokens[i + 1], out number))
                    {
                        grades.Add(number);
                        i++;

                        if (i == tokens.Count - 1)
                        {
                            break;
                        }
                    }
                }              

                var newStudent = new Student
                {
                    Name = name,
                    Age = age,
                    Grades = grades
                };

                students.Add(newStudent);

                age = 0;
                name = string.Empty;
                grades = new List<int>();
            }            
        }

        foreach (var student in students)
        {
            Console.Write($"{student.Name} : {student.Age} -> ");

            if (student.Grades.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", student.Grades)}");
            }
        }
    }
}

class Student
{
    public string Name { get; set; }

    public int Age { get; set; }

    public List<int> Grades { get; set; }
}

