using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class VehicleAddVM
    {
        public Vehicle Vehicle { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public string EColor { get; set; }
        public string IColor { get; set; }
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
        public string Picture { get; set; }
    }
}