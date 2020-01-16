using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class Response
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
