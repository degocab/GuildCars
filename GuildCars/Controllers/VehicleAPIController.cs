using GuildCars.BLL;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class VehicleAPIController : ApiController
    {
        private VehicleManager vehicleManager = new VehicleManager();
        // GET api/<controller>
        [AllowAnonymous]
        [Route("api/all/vehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllVehicles()
        {
            List<Vehicle> found = vehicleManager.GetAllVehicles().Data;
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        // GET api/<controller>/5
        [Route("api/vehicle/{VehicleId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int VehicleId)
        {
            Vehicle found = vehicleManager.GetByVehicleId(VehicleId).Data;
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}