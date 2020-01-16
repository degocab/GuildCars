using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.DAL
{
    public class VehicleMockRepository : IVehicleRepository
    {
        public void CreateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int VehicleId)
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetByAllByMakeModelYear(string QuickSearch)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetByVehicleId(int VehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
