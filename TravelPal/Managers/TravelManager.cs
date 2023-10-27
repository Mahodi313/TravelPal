using System;
using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        public static List<Travel> travels = new();

        public static void AddTravel(Travel travelToAdd, User user)
        {
            //TODO: IMPLEMENT LOGIC FOR ADDING TRAVEL
            travels = user.Travels;
            travels.Add(travelToAdd);
        }

        public static void RemoveTravel(Travel travelToRemove, User user)
        {
            travels = user.Travels;
            travels.Remove(travelToRemove);
        }


        /* Checks if user location and 
         * choosen country exists in 
         * Europe when adding travel */
        public static bool CheckCountryEurope(Country country) 
        {
            foreach (EuropeanCountry euCountry in Enum.GetValues(typeof(EuropeanCountry))) 
            {
                if (country.ToString() == euCountry.ToString()) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}
