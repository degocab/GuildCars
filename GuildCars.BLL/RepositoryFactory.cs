using GuildCars.DAL;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class RepositoryFactory
    {
        public static IVehicleRepository VehicleRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "QA":
                    IVehicleRepository mockVehicleRepository = new VehicleMockRepository();
                    return mockVehicleRepository;
                case "PROD":
                    IVehicleRepository vehicleRepository = new VehicleRepository();
                    return vehicleRepository;
                default:
                    throw new Exception();
            }
        }
        public static ISpecialRepository SpecialsRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "QA":
                    ISpecialRepository mockSpecialRepository = new SpecialsMockRepository();
                    return mockSpecialRepository;
                case "PROD":
                    ISpecialRepository specialRepository = new SpecialRepository();
                    return specialRepository;
                default:
                    throw new Exception();
            }
        }
        public static ISalesRepository SalesRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "QA":
                    ISalesRepository mockVehicleRepository = new SalesMockRepository();
                    return mockVehicleRepository;
                case "PROD":
                    ISalesRepository vehicleRepository = new SaleRepository();
                    return vehicleRepository;
                default:
                    throw new Exception();
            }
        }
        public static IMakeRepository MakeRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "QA":
                    IMakeRepository mockMakeRepository = new MakeMockRepository();
                    return mockMakeRepository;
                case "PROD":
                    IMakeRepository makeRepository = new MakeRepository();
                    return makeRepository;
                default:
                    throw new Exception();
            }
        }
        public static IModelRepository ModelRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "QA":
                    IModelRepository mockModelRepository = new ModelMockRepository();
                    return mockModelRepository;
                case "PROD":
                    IModelRepository ModelRepository = new ModelRepository();
                    return ModelRepository;
                default:
                    throw new Exception();
            }
        }
    }
}
