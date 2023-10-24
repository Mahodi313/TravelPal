using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.User_Models;

public class Admin : IUser
{
    public string Firstname { get; set;}
    public string Lastname { get; set; }
    public string Fullname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Country Location { get; set; }
    public DateTime Birthday { get; set; }
    public int Age { get; set; }

    public Admin(string firstname, string lastname, string username, string email, string password, Country location, DateTime birthday)
    {
        Firstname = firstname;
        Lastname = lastname;
        Username = username;
        Email = email;
        Password = password;
        Location = location;
        Fullname = Firstname + " " + Lastname;
        Birthday = birthday;
        Age = CalculateAge();
    }

    private int CalculateAge()
    {
        DateTime currentDate = DateTime.Now;

        int age = currentDate.Year - Birthday.Year;

        // Check if the birthday has occurred this year
        if (Birthday.Date > currentDate.Date.AddYears(-age))
        {
            age--; // The birthday has not occurred yet this year
        }

        return age;
    }
}
