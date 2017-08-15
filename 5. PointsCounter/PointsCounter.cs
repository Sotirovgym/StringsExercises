using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PointsCounter
{
    static void Main()
    {
        var input = Console.ReadLine();

        var teams = new Dictionary<string, List<Player>>();

        while (input != "Result")
        {
            var tokens = input.Split('|');

            var teamName = string.Empty;
            var playerName = string.Empty;
            var points = int.Parse(tokens[2]);

            if (IsTeam(tokens[0]))
            {
                teamName = tokens[0];
                playerName = tokens[1];
            }
            else
            {
                teamName = tokens[1];
                playerName = tokens[0];
            }

            teamName = Unpollute(teamName);
            playerName = Unpollute(playerName);

            if (! teams.ContainsKey(teamName))
            {
                teams.Add(teamName, new List<Player>());
            }

            var currentPlayer = new Player(playerName, points);

            if (teams[teamName].Contains(currentPlayer))
            {
                var index = teams[teamName].IndexOf(currentPlayer);
                teams[teamName][index].Points = points;
            }
            else
            {
                teams[teamName].Add(currentPlayer);
            }
            
            input = Console.ReadLine();
        }

        var orderTeams = teams
            .OrderByDescending(x => x.Value.Sum(p => p.Points));

        foreach (var team in orderTeams)
        {
            var teamName = team.Key;
            var players = team.Value;

            var totalPoints = players.Sum(p => p.Points);
            var bestPlayer = players.OrderByDescending(p => p.Points).First();

            Console.WriteLine($"{teamName} => {totalPoints}");
            Console.WriteLine($"Most points scored by {bestPlayer.Name}");
        }

    }
    static bool IsPollutedChar(char symbol)
    {
        return symbol == '$' || symbol == '%' || symbol == '@' || symbol == '*';
    }

    static string Unpollute(string name)
    {
        var result = new StringBuilder();

        foreach (char symbol in name)
        {
            if (!IsPollutedChar(symbol))
            {
                result.Append(symbol);
            }
        }

        return result.ToString();
    }

    static bool IsTeam(string name)
    {
        return !name.Any(ch => char.IsLower(ch));
    }
}

class Player
{
    public string Name { get; set; }

    public int Points { get; set; }

    public Player(string name, int points)
    {
        this.Name = name;
        this.Points = points;
    }

    public override bool Equals(object obj)
    {
        if (obj is Player)
        {
            var other = (Player)obj;

            return this.Name == other.Name;
        }

        return false;
    }
}

