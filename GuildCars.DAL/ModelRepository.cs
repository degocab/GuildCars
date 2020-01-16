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
    public class ModelRepository:IModelRepository
    {
        public void CreateModel(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateModel", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Model", model.model);
                cn.Open();

                cmd.ExecuteNonQuery();
                model.ModelId = (int)param.Value;
            }
        }
        //public void DeleteModel(int ModelId)
        //{
        //    using (var cn = new SqlConnection(Settings.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("DeleteModel", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ModelId", ModelId);
        //        cn.Open();
        //        cmd.ExecuteNonQuery();

        //    }
        //}
        //public void EditModel(Model model)
        //{
        //    using (var cn = new SqlConnection(Settings.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("EditModel", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ModelId", model.ModelId);
        //        cmd.Parameters.AddWithValue("@Model", model.model);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();

        //    }
        //}
        public Model GetModelById(int ModelId)
        {
            Model model = new Model();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetByModelId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelId", ModelId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        model.ModelId = (int)dr["ModelId"];
                        model.model = dr["Model"].ToString();
                        model.MakeId = (int)dr["MakeId"];
                    }
                }
                return model;
            }
        }
        public List<Model> GetAllModels()
        {
            List<Model> list = new List<Model>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model addModel = new Model();
                        addModel.ModelId = (int)dr["ModelId"];
                        addModel.model = dr["Model"].ToString();
                        addModel.MakeId = (int)dr["MakeId"];
                        list.Add(addModel);
                    }
                }
            }
            return list;
        }
    }
}
