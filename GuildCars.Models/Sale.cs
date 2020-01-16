using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public int StateId { get; set; }
        public decimal PurchasedPrice { get; set; }
        public int PurchaseTypeId{ get; set; }
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public string StateAbbrevation { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public DateTime SaleDate{ get; set; }
    }
}
