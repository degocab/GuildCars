using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Interfaces
{
    public interface IVehicleRepository
    {
        void CreateVehicle(Vehicle vehicle);
        void DeleteVehicle(int VehicleId);
        void EditVehicle(Vehicle vehicle);
        Vehicle GetByVehicleId(int VehicleId);
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetByAllByMakeModelYear(string QuickSearch);
    }
}
