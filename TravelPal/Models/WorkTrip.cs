using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class WorkTrip: Travel
    {

        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Country country, int travellers, List<PackingListItem> packinglist, DateTime startDate, DateTime endDate, string meetingDetails) : base(destination, country, travellers, packinglist, startDate, endDate)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return $"WorkTrip - {Country} - Date: {StartDate.Day}/{StartDate.Month}/{StartDate.Year}";
        }
    }
}
