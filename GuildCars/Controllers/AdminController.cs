using GuildCars.BLL;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GuildCars.Controllers
{
    public class AdminController : Controller
    {
        private MakeManager makeManager = new MakeManager();
        private ModelManager modelManager = new ModelManager();
        private VehicleManager vm = new VehicleManager();
        private SpecialsManager sm = new SpecialsManager();
        private SalesManager salesm = new SalesManager();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public  ActionResult Vehicles()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult Vehicles(string QuickSearch)
        {
            var model = new List<Vehicle>();
            model = vm.GetAllByMakeModelYear(QuickSearch).Data;

            return Json(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddVehicle()
        {

           
            var model = new VehicleAddVM();
            model.Makes = makeManager.GetAllMake().Data;
            model.Models = modelManager.GetAllModel().Data;
            //return View(new JavaScriptSerializer().Serialize(model));
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddVehicle(VehicleAddVM model, string BodyStyle, int Condition, int InteriorColorId, int ExteriorColorId, string Transmission, int ModelId)
        {

            var m = new Vehicle();
            m.BodyStyle = BodyStyle;
            if (Condition == 0)
            {
                m.Condition = true;
            }
            m.DateAdded = DateTime.Now;
            m.Description = model.Vehicle.Description;
            m.ExteriorColorId = ExteriorColorId;
            m.InteriorColorId = InteriorColorId;
            m.ModelId = ModelId;
            m.MSRP = model.Vehicle.MSRP;
            m.Price = model.Vehicle.Price;
            m.Transmission = Transmission;
            m.VIN = model.Vehicle.VIN;
            m.Year = model.Vehicle.Year;
            m.Mileage = model.Vehicle.Mileage;

            m.Featured = false;
            m.Picture = model.UploadedFile.FileName;
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images"),
                    Path.GetFileName(model.UploadedFile.FileName));

                model.UploadedFile.SaveAs(path);
            }

            vm.CreateVehicle(m);


            //change to edit vehicle
            return RedirectToAction("EditVehicle", "Admin",new {VehicleId = m.VehicleId });
                }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult EditVehicle(int VehicleId)
        {
            var model = vm.GetByVehicleId(VehicleId).Data;
            
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult EditVehicle(Vehicle model)
        {
            vm.EditVehicle(model);
            return RedirectToAction("Vehicles","Admin");
        }

        [AllowAnonymous]
   
        public ActionResult DeleteVehicle(int VehicleId)
        {
            vm.DeleteVehicle(VehicleId);
            return RedirectToAction("Vehicles","Admin");
        }

        public ActionResult CreateSpecial()
        {

            //create new view model to pass Special and List<Specials> to load it all

            var model = new SpecialsVM();
            model.Specials = new Specials();
            model.ListOfSpecials = sm.GetAllSpecials().Data;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateSpecial(SpecialsVM model)
        {
            try
            {
                sm.CreateSpecials(model.Specials);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("CreateSpecial","Admin");
        }



        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult SalesReport()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult SalesReport(DateTime SaleDateMin, DateTime SaleDateMax, string Name)
        {
            //add user as part of drop down
            var users = salesm.GetAllUsers().Data;
            var model = new List<Sale>();
            model = salesm.GetTotalSalesCount( SaleDateMin,  SaleDateMax,Name).Data;

            return Json(model);
        }
        //[AllowAnonymous]
        //[HttpGet]
        //public  ActionResult GetAllMakes()
        //{
        //    var model = makeManager.GetAllMake().Data;
        //    return View(model);
        //}


    }
}