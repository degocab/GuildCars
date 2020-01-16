using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Interfaces
{
    public interface IMakeRepository
    {
        void CreateMake(Make make);
        Make GetMakeById(int MakeId);
        List<Make> GetAllMakes();
    }
}
