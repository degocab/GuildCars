using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Interfaces
{
    public interface ISpecialRepository
    {
        void CreateSpecials(Specials specials);
        void DeleteSpecials(int SpecialsId);
        void EditSpecials(Specials Specials);
        Specials GetBySpecialsId(int SpecialsId);
        List<Specials> GetAllSpecials();
    }
}
