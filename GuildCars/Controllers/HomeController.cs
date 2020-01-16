using GuildCars.BLL;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class HomeController : Controller
    {
            private VehicleManager vm = new VehicleManager();
            private SpecialsManager sm = new SpecialsManager();
            public ActionResult Index()
            {
                var model = new VehicleSpecialsVM();
                model.ListOfVehicles = vm.GetAllVehicles().Data;
                model.ListOfSpecials = sm.GetAllSpecials().Data;

                return View(model);
            }

            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

            public ActionResult Contact(Vehicle vehicle)
            {
                ViewBag.Message = "Your contact page.";

                return View(vehicle);
            }
            public ActionResult GetAllSpecials()
            {
                var model = new List<Specials>();
                model = sm.GetAllSpecials().Data;
                return View(model);
            }
        
    }
}