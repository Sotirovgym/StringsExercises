using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class CapitalizeWords
{
    static void Main()
    {
        var input = Console.ReadLine();

        var result = new List<string>();
        var finalResult = new List<string>();

        while (input != "end")
        {
            var tokens = input.Split(new[] { ' ', ',', '.', '/', '\\', '[', ']', '{', '}', ':', ';'
                , '"', '-', '>', '_', '=', '|', '%', '@', '$', '*', '!', '?', '<', '#', '^', '&', '(', ')', '~', '+' }
            , StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                string word = tokens[i].ToLower();
                string firstLetter = word[0].ToString().ToUpper();
                word = firstLetter + word.Substring(1);

                result.Add(word);
            }

            finalResult.Add(string.Join(", ", result));
            result.Clear();
            

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(Environment.NewLine, finalResult));
    }
}

