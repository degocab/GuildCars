using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class ModelManager
    {
        private static IModelRepository _ModelRepository;
        public ModelManager()
        {
            _ModelRepository = RepositoryFactory.ModelRepository();
        }
        public Response<Model> CreateModel(Model model)
        {
            Response<Model> response = new Response<Model>();
            try
            {
                _ModelRepository.CreateModel(model);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Model> GetByModelId(int ModelId)
        {
            Response<Model> response = new Response<Model>();
            try
            {
                response.Data = _ModelRepository.GetModelById(ModelId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Model>> GetAllModel()
        {
            Response<List<Model>> response = new Response<List<Model>>();
            try
            {
                response.Data = _ModelRepository.GetAllModels();
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
    }
}
