using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.User_Models;

namespace TravelPal.Managers;

public static class UserManager
{
    private static int _idCounter = 2;

    public static List<IUser> users = new()
    {
        new Admin("Mahdi", "Ali", "admin", "Mahdi.Ali@edu.newton.se", "password", Enums.Country.Sweden),
        new User(1, "Dr", "Horse", "user", "Dr.Horse@edu.newton.se", DateTime.Parse("2023-10-24"), "password",Country.Sweden)
    };

    public static IUser? SignedInUser { get; set; }

    public static bool AddUser(IUser user) 
    {   
        //TODO: IMPLEMENT LOGIC FOR ADDING NEW USER
        return false;
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
        //TODO: IMPLEMENT LOGIC FOR CHECKING IF USERNAME IS AVAILABLE
        return false;
        
    }
    public static bool UpdateEmail(IUser user, string choosenEmail)
    {
        //TODO: IMPLEMENT LOGIC FOR UPDATING AND CHECKING EMAIL
        return false;
    }

    private static bool ValidateEmail(string email)
    {
        //TODO: IMPLEMENT LOGIC FOR CHECKING IF EMAIL IS AVAILABLE
        return false;

    }

    public static bool SignInUser(string username, string password) 
    {   
        //TODO: IMPLEMENT LOGIC FOR CHECKING IF USER CAN SIGN IN
        return false;
    }

}
