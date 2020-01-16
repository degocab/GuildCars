using GuildCars.BLL;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class InventoryController : Controller
    {
        private VehicleManager vm = new VehicleManager();
        // GET: Inventory
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SearchNew()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SearchUsed()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult SearchNew(string QuickSearch)
        {
            var model = new List<Vehicle>();
            model = vm.GetAllByMakeModelYear(QuickSearch).Data;

            return Json(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult SearchUsed(string QuickSearch)
        {
            var model = new List<Vehicle>();
            model = vm.GetAllByMakeModelYear(QuickSearch).Data;

            return Json(model);
        }
        public ActionResult GetAllNewByModeMakeOrYear()
        {
            return View();
        }

        [AllowAnonymous]
        //[Route("Inventory/Details/{VehicleId:int}")]
        [HttpGet]
        public ActionResult Details(int VehicleId)
        {
            Vehicle model = vm.GetByVehicleId(VehicleId).Data;
            return View(model);
        }
    }
}