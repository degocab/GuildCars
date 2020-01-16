using GuildCars.BLL;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class SpecialsController : Controller
    {
        private SpecialsManager sm = new SpecialsManager();
        // GET: Specials
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
            var model = new List<Specials>();
            model = sm.GetAllSpecials().Data;
            return View(model);
        }
    }
}