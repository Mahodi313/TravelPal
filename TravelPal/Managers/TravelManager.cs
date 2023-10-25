using System.Collections.Generic;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        public static List<Travel> travels = new();

        public static void AddTravel(Travel travelToAdd)
        {
            //TODO: IMPLEMENT LOGIC FOR ADDING TRAVEL
        }

        public static void RemoveTravel(Travel travelToRemove, User user)
        {
            travels = user.Travels;
            travels.Remove(travelToRemove);
        }
    }
}
