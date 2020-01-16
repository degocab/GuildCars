using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models;
using System.Data.SqlClient;

namespace GuildCars.DAL
{
    public class SaleRepository : ISalesRepository
    {
        public void CreateSale(Sale sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateSale", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@SaleId", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", sale.Name);
                cmd.Parameters.AddWithValue("@Phone", sale.Phone);
                cmd.Parameters.AddWithValue("@Email", sale.Email);
                cmd.Parameters.AddWithValue("@Street1", sale.Street1);
                cmd.Parameters.AddWithValue("@Street2", sale.Street2);
                cmd.Parameters.AddWithValue("@City", sale.City);
                cmd.Parameters.AddWithValue("@Zipcode", sale.Zipcode);
                cmd.Parameters.AddWithValue("@StateId", sale.StateId);
                cmd.Parameters.AddWithValue("@PurchasedPrice", sale.PurchasedPrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", sale.PurchaseTypeId);
                cmd.Parameters.AddWithValue("@VehicleId", sale.VehicleId);
                cn.Open();
                cmd.ExecuteNonQuery();
                sale.SaleId = (int)param.Value;
            }
        }
        public List<Sale> GetTotalSalesCount(DateTime SaleDateMin, DateTime SaleDateMax, string Name)
        {
            List<Sale> list = new List<Sale>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetTotalSalesCount",cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SaleDateMin",SaleDateMin);
                cmd.Parameters.AddWithValue("@SaleDateMax", SaleDateMax);
                cmd.Parameters.AddWithValue("@Name",Name);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale sale = new Sale();
                        sale.Name = dr["Name"].ToString();
                        sale.Sum = (decimal)dr["Sum"];
                        sale.Count = (int)dr["Count"];

                        list.Add(sale); 
                    }
                }
            }
            return list;
        }
        public List<Sale> GetAllSales()
        {
            List<Sale> list = new List<Sale>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllSales", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale sale = new Sale();
                        sale.SaleId = (int)dr["SaleId"];
                        sale.Name = dr["Name"].ToString();
                        sale.Phone = dr["Phone"].ToString();
                        sale.Email = dr["Email"].ToString();
                        sale.Street1 = dr["Street1"].ToString();
                        sale.Street2 = dr["Street2"].ToString();
                        sale.City = dr["City"].ToString();
                        sale.Zipcode = dr["Zipcode"].ToString();
                        sale.StateId = (int)dr["StateId"];
                        sale.StateAbbrevation = dr["StateAbbrevation"].ToString();
                        sale.PurchasedPrice = (decimal)dr["PurchasedPrice"];
                        sale.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        sale.Type = dr["Type"].ToString();
                        sale.VehicleId = (int)dr["VehicleId"];
                        list.Add(sale);
                    }
                }
            }
            return list;
        }
        public List<Sale> GetAllUsers()
        {
            List<Sale> list = new List<Sale>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale sale = new Sale();
                  
                        sale.Name = dr["Name"].ToString();
                        
                        list.Add(sale);
                    }
                }
            }
            return list;
        }
        public Sale GetSaleById(int SaleId)
        {
            Sale sale = new Sale();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetSaleById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SaleId", SaleId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        sale.SaleId = (int)dr["SaleId"];
                        sale.Name = dr["Name"].ToString();
                        sale.Phone = dr["Phone"].ToString();
                        sale.Email = dr["Email"].ToString();
                        sale.Street1 = dr["Street1"].ToString();
                        sale.Street2 = dr["Street2"].ToString();
                        sale.City = dr["City"].ToString();
                        sale.Zipcode = dr["Zipcode"].ToString();
                        sale.StateId = (int)dr["StateId"];
                        sale.StateAbbrevation = dr["StateAbbrevation"].ToString();
                        sale.PurchasedPrice = (decimal)dr["PurchasedPrice"];
                        sale.PurchaseTypeId = (int)dr["PuchaseTypeId"];
                        sale.Type = dr["Type"].ToString();
                        sale.VehicleId = (int)dr["VehicleId"];

                    }
                }
            }
            return sale;
        }
        public List<States> GetAllStates()
        {
            List<States> list = new List<States>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllStates", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        States states = new States();
                        states.StateId = (int)dr["StateId"];
                        states.StateAbbrevation = dr["StateAbbrevation"].ToString();

                        list.Add(states);
                    }
                }
            }
            return list;
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            List<PurchaseType> list = new List<PurchaseType>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllPurchaseTypes", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType purchaseType = new PurchaseType();
                        purchaseType.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        purchaseType.Type = dr["Type"].ToString();

                        list.Add(purchaseType);
                    }
                }
            }
            return list;
        }

        public States GetStateById(int StateId)
        {
            States states = new States();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetStateById", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        states.StateId = (int)dr["StateId"];
                        states.StateAbbrevation = dr["StateAbbrevation"].ToString();

                    }
                }
            }
            return states;
        }
    }
}
