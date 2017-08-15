using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SentenceSplit
{
    static void Main()
    {
        var input = Console.ReadLine();
        var delimiters = Console.ReadLine();

        var tokens = input.Split(new string[] { delimiters }, StringSplitOptions.None);
        Console.WriteLine($"[{string.Join(", ", tokens)}]");    
    }
}

