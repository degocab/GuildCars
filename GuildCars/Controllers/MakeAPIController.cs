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
    public class MakeAPIController : ApiController
    {
        private MakeManager makeManager = new MakeManager();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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

        [AllowAnonymous]
        [Route("api/make")]
        [AcceptVerbs("GET")]
        public  IHttpActionResult GetAllMakes()
        {
            List<Make> found = makeManager.GetAllMake().Data;
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
    }
}