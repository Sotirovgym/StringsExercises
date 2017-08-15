using System;

class FindTheLetter
{
    static void Main()
    {
        var text = Console.ReadLine();
        var letterAndOccur = Console.ReadLine().Split(' ');

        var letter = letterAndOccur[0];
        var occurrence = int.Parse(letterAndOccur[1]);

        var index = -1;

        for (int i = 0; i < occurrence; i++)
        {
            index = text.IndexOf($"{letter}", index + 1);

            if (index == -1)
            {
                Console.WriteLine("Find the letter yourself!");
                return;
            }
        }

        Console.WriteLine(index);
    }
}

