using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class SpecialsManager
    {
        private static ISpecialRepository _specialRepository;
        public SpecialsManager()
        {
            _specialRepository = RepositoryFactory.SpecialsRepository();
        }
        public Response<Specials> CreateSpecials(Specials specials)
        {
            Response<Specials> response = new Response<Specials>();
            try
            {
                _specialRepository.CreateSpecials(specials);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Specials> DeleteSpecials(int SpecialsId)
        {
            Response<Specials> response = new Response<Specials>();
            try
            {
                _specialRepository.DeleteSpecials(SpecialsId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Specials> EditSpecials(Specials specials)
        {
            Response<Specials> response = new Response<Specials>();
            try
            {
                _specialRepository.EditSpecials(specials);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Specials> GetBySpecialsId(int SpecialsId)
        {
            Response<Specials> response = new Response<Specials>();
            try
            {
                response.Data = _specialRepository.GetBySpecialsId(SpecialsId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Specials>> GetAllSpecials()
        {
            Response<List<Specials>> response = new Response<List<Specials>>();
            try
            {
                response.Data = _specialRepository.GetAllSpecials();
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
