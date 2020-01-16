using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class SalesManager
    {
        private static ISalesRepository _salesRepository;
        public SalesManager()
        {
            _salesRepository = RepositoryFactory.SalesRepository();
        }
        public Response<Sale> CreateSale(Sale sale)
        {
            Response<Sale> response = new Response<Sale>();
            try
            {
                _salesRepository.CreateSale(sale);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Sale> GetSaleById(int SaleId)
        {
            Response<Sale> response = new Response<Sale>();
            try
            {
                response.Data = _salesRepository.GetSaleById(SaleId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Sale>> GetAllUsers()
        {
            Response<List<Sale>> response = new Response<List<Sale>>();
            try
            {
                response.Data = _salesRepository.GetAllUsers();
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Sale>> GetTotalSalesCount(DateTime SaleDateMin, DateTime SaleDateMax, string Name)
        {
            Response<List<Sale>> response = new Response<List<Sale>>();
            try
            {
                response.Data = _salesRepository.GetTotalSalesCount( SaleDateMin,  SaleDateMax, Name);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Sale>> GetAllSales()
        {
            Response<List<Sale>> response = new Response<List<Sale>>();
            try
            {
                response.Data = _salesRepository.GetAllSales();
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }

        public Response<List<States>> GetAllStates()
        {
            Response<List<States>> response = new Response<List<States>>();
            try
            {
                response.Data = _salesRepository.GetAllStates();
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<PurchaseType>> GetAllPurchaseTypes()
        {
            Response<List<PurchaseType>> response = new Response<List<PurchaseType>>();
            try
            {
                response.Data = _salesRepository.GetAllPurchaseTypes();
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }

        public Response<States> GetStateById(int StateId)
        {
            Response<States> response = new Response<States>();
            try
            {
                response.Data = _salesRepository.GetStateById(StateId);
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
