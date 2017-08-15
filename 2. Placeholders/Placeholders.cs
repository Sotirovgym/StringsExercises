using System;
using System.Collections.Generic;
using System.Linq;

class Placeholders
{
    static void Main()
    {
        var input = Console.ReadLine();

        while (input != "end")
        {
            var tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            var text = tokens[0];
            var elements = tokens[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < elements.Length; i++)
            {
                var placeholder = "{" + i + "}";

                if (text.Contains(placeholder))
                {
                    text = text.Replace(placeholder, elements[i]);
                }               
            }

            Console.WriteLine(text);

            input = Console.ReadLine();
        }       
        
    }
}

