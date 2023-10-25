using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation: Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, Country country, int travellers, List<PackingListItem> packinglist, DateTime startDate, DateTime endDate, bool allInclusive): base(destination, country, travellers,packinglist,startDate,endDate)
        {
            AllInclusive = allInclusive;            
        }

        public override string GetInfo()
        {   

            return $"Vacation - {Country} - Date: {StartDate.Day}/{StartDate.Month}/{StartDate.Year}";
            
        }
        public string GetVacationInfo()
        {   
            if (AllInclusive) 
            {
                return $"Vacation - All Inclusive";
            }

            return $"Vacation - NOT - All Inclusive";
        }
    }
}
