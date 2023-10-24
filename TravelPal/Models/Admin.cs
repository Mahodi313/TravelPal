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

    public Admin(string firstname, string lastname, string username, string email, string password, Country location)
    {
        Firstname = firstname;
        Lastname = lastname;
        Username = username;
        Email = email;
        Password = password;
        Location = location;
        Fullname = Firstname + " " + Lastname;
    }
}
