using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Team
{
    private string name;
    private string nickname;
    private DateTime dateFounded;
    private List<Player> players;

    public Team(string name, string nickname, DateTime dateFound)
    {
        this.Name = name;
        this.Nickname = nickname;
        this.DateFounded = dateFounded;
        this.players = new List<Player>();
    }

    public string Name 
    {
        get { return this.name; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException("Name should be at least 5 chars");
            }
            this.name = value;
        }
    }
    public string Nickname 
    {
        get { return this.nickname; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException("Nickname should be at least 5 chars");
            }
            this.nickname = value;
        }
    }

    private const int minimumFoundedYear = 1850;

    public DateTime DateFounded 
    {
        get { return this.dateFounded;  }
        set 
        {
            this.dateFounded = value;                       
        }
    }

    public IEnumerable<Player> Players
    {
        get 
        {
            return this.players;
        }
    }

    private bool CheckIfPlayerExists(Player player)
    {
        return this.players.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName);
    }

    public void AddPlayer(Player player)
    {
        if (CheckIfPlayerExists(player))
        {
            throw new InvalidOperationException("Player exist");
        }
        this.players.Add(player);
    }

    public override string ToString()
    {
        return this.Name + " - " + string.Join(", ", players.Select(z => z.ToString()));
    }
}
