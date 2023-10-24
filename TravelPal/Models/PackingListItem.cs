using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models;

public interface PackingListItem
{
    public string Name { get; set; }

    public string GetInfo();
}
