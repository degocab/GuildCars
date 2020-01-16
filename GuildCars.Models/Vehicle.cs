using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GuildCars.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int ExteriorColorId { get; set; }
        public int InteriorColorId { get; set; }
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public DateTime DateAdded { get; set; }
        public string Transmission { get; set; }
        public string BodyStyle { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public bool Condition { get; set; }
        public bool Featured { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string EColor { get; set; }
        public string IColor { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}
