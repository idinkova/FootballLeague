using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class League
{
    private static List<Team> teams = new List<Team>();
    private static List<Match> matches = new List<Match>();
    public static List<Team> Teams
    {
        get { return teams; }
    }

    public static List<Match> Matches
    {
        get { return matches; }
    }


    public static void AddMatch(Match match)
    {
        if (MatchAddCheck(match))
        {
            throw new InvalidOperationException("Match already exists in the league!");
        }
        Matches.Add(match);
    }

    private static bool MatchAddCheck(Match match)
    {
        return Matches.Any(m => m.Id == match.Id);
    }

    public static void AddTeam(Team team)
    {
        if (TeamAddCheck(team))
        {
            throw new InvalidOperationException("Team already exists in the league!");
        }

        Teams.Add(team);
    }

    private static bool TeamAddCheck(Team team)
    {
        return Teams.Any(t => t.Name == team.Name);
    }
}
