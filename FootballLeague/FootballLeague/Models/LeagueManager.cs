using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FootballLeague
{
    static class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split(' ');
            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    Console.WriteLine("Team successfully added.");
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3], int.Parse(inputArgs[4]), int.Parse(inputArgs[5]));
                    Console.WriteLine("Match successfully added.");
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]), decimal.Parse(inputArgs[4], CultureInfo.InvariantCulture), inputArgs[5]);
                    Console.WriteLine("Player successfully added.");
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
            }
        }

        private static void AddTeam(string name, string nickname, DateTime dateOfFounding)
        {          
            League.AddTeam(new Team(name, nickname, dateOfFounding));
        }

        private static void AddMatch(int id, string hometeam, string awayteam, int home, int away)
        {            
            League.AddMatch(new Match(StringToTeam(hometeam), StringToTeam(awayteam), new Score(home, away), id));
        }

        private static void AddPlayerToTeam(string firstName, string lastName, DateTime dateOfBirth, decimal salary, string team)
        {            
            StringToTeam(team).AddPlayer(new Player(firstName, lastName, dateOfBirth, salary));
        }

        private static void ListTeams()
        {
            foreach (Team team in League.Teams)
            {
                Console.WriteLine(team);
            }
        }

        private static void ListMatches()
        {
            foreach (Match match in League.Matches)
            {
                Console.WriteLine(match);
            }
        }

        private static Team StringToTeam(string teamName)
        {
            foreach (var item in League.Teams)
            {
                if (item.Name == teamName)
                {
                    return item;
                }
            }
            throw new ArgumentException("No such team exists!");
        }
    }
}