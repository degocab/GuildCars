using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models;

namespace GuildCars.DAL
{
    public class SalesMockRepository : ISalesRepository
    {
        public void CreateSale(Sale Sale)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetAllSales()
        {
            throw new NotImplementedException();
        }

        public List<States> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Sale GetSaleById(int SaleId)
        {
            throw new NotImplementedException();
        }

        public States GetStateById(int StateId)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetTotalSalesCount(DateTime SaleDateMin, DateTime SaleDateMax,string Name)
        {
            throw new NotImplementedException();
        }
    }
}
