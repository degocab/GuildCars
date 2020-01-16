using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.DAL
{
    public class VehicleRepository : IVehicleRepository
    {
        public void CreateVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ExteriorColorId", vehicle.ExteriorColorId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@DateAdded", vehicle.DateAdded);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Featured",vehicle.Featured);
                cmd.Parameters.AddWithValue("@Condition", vehicle.Condition);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cn.Open();

                cmd.ExecuteNonQuery();
                vehicle.VehicleId = (int)param.Value;
            }
        }
        public void DeleteVehicle(int VehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);
                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void EditVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@ExteriorColorId", vehicle.ExteriorColorId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@DateAdded", vehicle.DateAdded);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Condition", vehicle.Condition);
                cmd.Parameters.AddWithValue("@Picture",vehicle.Picture);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public Vehicle GetByVehicleId(int VehicleId)
        {
            NumberFormatInfo nfi = new CultureInfo("en-us").NumberFormat;
            Vehicle vehicle = new Vehicle();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetByVehicleId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.EColor = dr["EColor"].ToString();
                        vehicle.IColor = dr["IColor"].ToString();
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.Year = ((int)dr["Year"]);
                        vehicle.DateAdded = (DateTime)dr["DateAdded"];
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Condition = (bool)dr["Condition"];
                        vehicle.Make = dr["Make"].ToString();
                        vehicle.Model = dr["Model"].ToString();
                        vehicle.Picture = dr["Picture"].ToString();
                        vehicle.InteriorColorId = (int)dr["InteriorColorId"];
                        vehicle.ExteriorColorId = (int)dr["ExteriorColorId"];

                    }
                }
                return vehicle;
            }
        }
        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> list = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle addVehicle = new Vehicle();
                        addVehicle.VehicleId = (int)dr["VehicleId"];
                        addVehicle.ExteriorColorId = (int)dr["ExteriorColorId"];
                        addVehicle.InteriorColorId = (int)dr["InteriorColorId"];
                        addVehicle.ModelId = (int)dr["ModelId"];
                        //addVehicle.MakeId = (int)dr["MakeId"];
                        addVehicle.Price = (decimal)dr["Price"];
                        addVehicle.Year = ((int)dr["Year"]);
                        addVehicle.DateAdded = (DateTime)dr["DateAdded"];
                        addVehicle.Transmission = dr["Transmission"].ToString();
                        addVehicle.BodyStyle = dr["BodyStyle"].ToString();
                        addVehicle.Mileage = dr["Mileage"].ToString();
                        addVehicle.VIN = dr["VIN"].ToString();
                        addVehicle.MSRP = (decimal)dr["MSRP"];
                        addVehicle.Description = dr["Description"].ToString();
                        addVehicle.Condition = (bool)dr["Condition"];
                        addVehicle.Featured = (bool)dr["Featured"];
                        addVehicle.Make = dr["Make"].ToString();
                        addVehicle.Model = dr["Model"].ToString();
                        addVehicle.Picture = dr["Picture"].ToString();
                        list.Add(addVehicle);
                    }
                }
            }
            return list;
        }
        public List<Vehicle> GetByAllByMakeModelYear(string QuickSearch)
        {
            List<Vehicle> list = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllByMakeModelYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QuickSearch", QuickSearch);

                cn.Open();
                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Vehicle addVehicle = new Vehicle();
                            addVehicle.VehicleId = (int)dr["VehicleId"];
                            addVehicle.ExteriorColorId = (int)dr["ExteriorColorId"];
                            addVehicle.InteriorColorId = (int)dr["InteriorColorId"];
                            addVehicle.ModelId = (int)dr["ModelId"];
                            //addVehicle.MakeId = (int)dr["MakeId"];
                            addVehicle.Price = (decimal)dr["Price"];
                            addVehicle.Year = ((int)dr["Year"]);
                            addVehicle.DateAdded = (DateTime)dr["DateAdded"];
                            addVehicle.Transmission = dr["Transmission"].ToString();
                            addVehicle.BodyStyle = dr["BodyStyle"].ToString();
                            addVehicle.Mileage = dr["Mileage"].ToString();
                            addVehicle.VIN = dr["VIN"].ToString();
                            addVehicle.MSRP = (decimal)dr["MSRP"];
                            addVehicle.Description = dr["Description"].ToString();
                            addVehicle.Condition = (bool)dr["Condition"];
                            addVehicle.Featured = (bool)dr["Featured"];
                            addVehicle.Make = dr["Make"].ToString();
                            addVehicle.Model = dr["Model"].ToString();
                            addVehicle.EColor = dr["EColor"].ToString();
                            addVehicle.IColor = dr["IColor"].ToString();
                            addVehicle.Picture = dr["Picture"].ToString();
                            list.Add(addVehicle);

                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return list;
        }
    }
}
