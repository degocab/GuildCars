using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class VehicleSalesStatesPurchaseTypeVM
    {
        public Vehicle Vehicle { get; set; }
        public List<PurchaseType> PurchaseTypes { get; set; }
        public List<States> States { get; set; }
        public Sale Sale { get; set; }
        public States State { get; set; }
        public PurchaseType PurchaseType { get; set; }
        public VehicleSalesStatesPurchaseTypeVM()
        {
            PurchaseTypes = new List<PurchaseType>();
            States = new List<States>();

        }
    }
}