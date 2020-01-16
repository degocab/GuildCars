using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.DAL
{
    public class MakeRepository:IMakeRepository
    {
        public void CreateMake(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateMake", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Make", make.make);
                cn.Open();

                cmd.ExecuteNonQuery();
                make.MakeId = (int)param.Value;
            }
        }
        //public void DeleteMake(int MakeId)
        //{
        //    using (var cn = new SqlConnection(Settings.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("DeleteMake", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MakeId", MakeId);
        //        cn.Open();
        //        cmd.ExecuteNonQuery();

        //    }
        //}
        //public void EditMake(Make make)
        //{
        //    using (var cn = new SqlConnection(Settings.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("EditMake", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MakeId", make.MakeId);
        //        cmd.Parameters.AddWithValue("@Make", make.make);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();

        //    }
        //}
        public Make GetMakeById(int MakeId)
        {
            Make make = new Make();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetByMakeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeId", MakeId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make.MakeId = (int)dr["MakeId"];
                        make.make = dr["Make"].ToString();
                    }
                }
                return make;
            }
        }
        public List<Make> GetAllMakes()
        {
            List<Make> list = new List<Make>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllMakes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make addMake = new Make();
                        addMake.MakeId = (int)dr["MakeId"];
                        addMake.make = dr["Make"].ToString();
                        list.Add(addMake);
                    }
                }
            }
            return list;
        }
    }
}
