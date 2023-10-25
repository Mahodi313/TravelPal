using System;
using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal.Managers;

public static class UserManager
{

    public static List<IUser> users = new()
    {
        new Admin("Mahdi", "Ali", "admin", "Mahdi.Ali@edu.newton.se", "password", Enums.Country.Sweden, DateTime.Parse("2002-10-24")),

        new User("Dr", "Horse", "user", "Dr.Horse@edu.newton.se", DateTime.Parse("2002-10-24"), "password",Country.Sweden, new List<Travel> {

        new Vacation("Copenhagen", Country.Denmark, 1, new List<PackingListItem>{new TravelDocument("Passport", false), new OtherItem("Kinder", 1)}, DateTime.Parse("2023-10-24"), DateTime.Parse("2023-11-05"), true),
        new WorkTrip("Chennai", Country.India, 2, new List<PackingListItem>{new TravelDocument("Passport", true), new TravelDocument("Visum", true), new OtherItem("Kinder", 1)}, DateTime.Parse("2023-12-23"), DateTime.Parse("2024-01-07"), "Meeting with Kim Jong Un")

        })
    };

    public static IUser? SignedInUser { get; set; }

    public static bool AddUser(IUser user)
    {
        //if email and username don't exist, return true, else return false
        string username = user.Username;
        string email = user.Email;

        if (ValidateUserName(username) && ValidateEmail(email) && user.Age >= 16)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static void RemoveUser(IUser user)
    {
        //TODO: IMPLEMENT LOGIC FOR REMOVING USER
    }

    public static bool UpdateUsername(IUser user, string choosenName)
    {
        //TODO: IMPLEMENT LOGIC FOR UPDATING AND CHECKING USERNAME
        return false;
    }

    private static bool ValidateUserName(string userName)
    {
        foreach (var user in users)
        {
            // If the username already exists in the list of users return false because it's not available. Return true if available
            if (userName == user.Username)
            {
                return false;
            }
        }
        return true;
    }
    public static bool UpdateEmail(IUser user, string choosenEmail)
    {
        //TODO: IMPLEMENT LOGIC FOR UPDATING AND CHECKING EMAIL
        return false;
    }

    private static bool ValidateEmail(string email)
    {
        foreach (var user in users)
        {
            // If the email already exists in the list of users return false because it's not available. Return true if available
            if (email == user.Email)
            {
                return false;
            }
        }
        return true;
    }

    public static bool SignInUser(string username, string password)
    {
        //TODO: IMPLEMENT LOGIC FOR CHECKING IF USER CAN SIGN IN

        foreach (var user in users)
        {
            if (username == user.Username && password == user.Password)
            {
                if (user is User costumer)
                {
                    TravelWindow travelWindow = new(costumer);
                    travelWindow.Show();

                    SignedInUser = costumer;
                }
                else if (user is Admin admin)
                {
                    //ADD ADMIN WINDOW
                    //TravelWindow travelWindow = new(admin);
                    //travelWindow.Show();
                    SignedInUser = admin;
                }
                return true;
            }
        }
        return false;
    }


}
