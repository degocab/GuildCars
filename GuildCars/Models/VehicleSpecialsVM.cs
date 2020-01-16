using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class VehicleSpecialsVM
    {
        public List<Vehicle> ListOfVehicles { get; set; }
        public List<Specials> ListOfSpecials { get; set; }
    }
}