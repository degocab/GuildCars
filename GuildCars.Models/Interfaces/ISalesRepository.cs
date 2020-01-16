using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Interfaces
{
    public interface ISalesRepository
    {
        void CreateSale(Sale Sale);
        Sale GetSaleById(int SaleId);
        List<Sale> GetAllUsers();
        List<Sale> GetTotalSalesCount(DateTime SaleDateMin, DateTime SaleDateMax, string Name);
        List<Sale> GetAllSales();
        List<States> GetAllStates();
        States GetStateById(int StateId);
        List<PurchaseType> GetAllPurchaseTypes();
    }
}
