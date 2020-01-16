using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Interfaces
{
    public interface IModelRepository
    {
        void CreateModel(Model model);
        Model GetModelById(int ModelId);
        List<Model> GetAllModels();
    }
}
