using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private string firstName;
    private string lastName;
    private DateTime dateOfBirth;
    private decimal salary;
    private Team team;

    public Player(string firstName, string lastName, DateTime dateOfBirth, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Salary = salary;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("First name should be at least 3 chars");
            }
            this.firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("Last name should be at least 3 chars");
            }
            this.lastName = value;
        }
    }

    private const int MinimumYear = 1980;

    public DateTime DateOfBirth
    {
        get
        {
            return this.dateOfBirth;
        }
        set
        {
            if (value.Year < MinimumYear)
            {
                throw new ArgumentException("Date of birth cannot be earlyer than " + MinimumYear);                
            }
            this.dateOfBirth = value;
        }
    }
    
    public decimal Salary
    {
        get 
        {
            return this.salary;
        }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            this.salary = value;
        }
    }

    public Team Team
    {
        get
        {
            return this.team;
        }
        set
        {
            team = value;
        }
    }

    public override string ToString()
    {
        return this.FirstName + " " + this.LastName;
    }
}

