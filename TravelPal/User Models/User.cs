using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.User_Models;

public class User : IUser
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public string Password { get; set; }
    public Country Location { get; set; }
    
    //TODO: ADD LATER WHEN TRAVEL CLASS IS CREATED
    //public List<Travel> Travels { get; set; }

    public User(int id, string firstname, string lastname, string username, string email, DateTime birthday, string password, Country location)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        Username = username;
        Email = email;
        Birthday = birthday;
        Password = password;
        Location = location;
    }
}
