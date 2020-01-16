using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models;

namespace GuildCars.DAL
{
    public class ModelMockRepository : IModelRepository
    {
        public void CreateModel(Model model)
        {
            throw new NotImplementedException();
        }

        public List<Model> GetAllModels()
        {
            throw new NotImplementedException();
        }

        public Model GetModelById(int ModelId)
        {
            throw new NotImplementedException();
        }
    }
}
