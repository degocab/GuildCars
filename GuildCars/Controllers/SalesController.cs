using GuildCars.BLL;
using GuildCars.DAL;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class SalesController : Controller
    {
        private VehicleManager vm = new VehicleManager();
        private SalesManager sm = new SalesManager();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SaleSearch()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult SaleSearch(string QuickSearch)
        {
            var model = new List<Vehicle>();
            model = vm.GetAllByMakeModelYear(QuickSearch).Data;

            return Json(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Purchase(int VehicleId)
        {
            List<States> states = sm.GetAllStates().Data;
            List<PurchaseType> purchaseTypes = sm.GetAllPurchaseTypes().Data;
            Vehicle v = vm.GetByVehicleId(VehicleId).Data;
            var model = new VehicleSalesStatesPurchaseTypeVM();
            model.Vehicle = v;
            model.States = states;
            model.PurchaseTypes = purchaseTypes;
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Purchase(VehicleSalesStatesPurchaseTypeVM model,int StateId, int PurchaseTypeId,int VehicleId)
        {


            model.Sale.StateId = StateId;
            model.Sale.PurchaseTypeId = PurchaseTypeId;
            model.Sale.VehicleId = VehicleId;
            sm.CreateSale(model.Sale);
            
           
            return RedirectToAction("Index","Home");
        }
    }
}