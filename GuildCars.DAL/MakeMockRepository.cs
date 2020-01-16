using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models;

namespace GuildCars.DAL
{
    public class MakeMockRepository : IMakeRepository
    {
        public void CreateMake(Make make)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetAllMakes()
        {
            throw new NotImplementedException();
        }

        public Make GetMakeById(int MakeId)
        {
            throw new NotImplementedException();
        }
    }
}
