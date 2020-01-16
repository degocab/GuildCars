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
    public class SpecialRepository : ISpecialRepository
    {
        public void CreateSpecials(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateSpecials", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@SpecialsId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Specials", specials);
                cn.Open();

                cmd.ExecuteNonQuery();
                specials.SpecialsId = (int)param.Value;
            }
        }
        public void DeleteSpecials(int SpecialsId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialsId", SpecialsId);
                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void EditSpecials(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialsId", specials.SpecialsId);
                cmd.Parameters.AddWithValue("@Specials.Title", specials.Title);
                cmd.Parameters.AddWithValue("@Specials.Description", specials.Description);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public Specials GetBySpecialsId(int SpecialsId)
        {
            Specials specials = new Specials();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetBySpecialsId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialsId", SpecialsId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        specials.SpecialsId = (int)dr["SpecialsId"];
                        specials.Title = dr["Title"].ToString();
                        specials.Description = dr["Description"].ToString();
                    }
                }
                return specials;
            }
        }
        public List<Specials> GetAllSpecials()
        {
            List<Specials> list = new List<Specials>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials addSpecials = new Specials();
                        addSpecials.SpecialsId = (int)dr["SpecialsId"];
                        addSpecials.Title = dr["Title"].ToString();
                        addSpecials.Description = dr["Description"].ToString();
                        list.Add(addSpecials);
                    }
                }
            }
            return list;
        }
    }
}
