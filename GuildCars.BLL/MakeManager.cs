using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class MakeManager
    {
        private static IMakeRepository _makeRepository;
        public MakeManager()
        {
            _makeRepository = RepositoryFactory.MakeRepository();
        }
        public Response<Make> CreateMake(Make make)
        {
            Response<Make> response = new Response<Make>();
            try
            {
                _makeRepository.CreateMake(make);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Make> GetByMakeId(int MakeId)
        {
            Response<Make> response = new Response<Make>();
            try
            {
                response.Data = _makeRepository.GetMakeById(MakeId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Make>> GetAllMake()
        {
            Response<List<Make>> response = new Response<List<Make>>();
            try
            {
                response.Data = _makeRepository.GetAllMakes();
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
