using GuildCars.Models;
using GuildCars.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class VehicleManager
    {
        private static IVehicleRepository _vehicleRepository;
        public VehicleManager()
        {
            _vehicleRepository = RepositoryFactory.VehicleRepository();
        }
        //public Vehicle CreateVehicle(Vehicle vehicle)
        //{
        //    Response<Vehicle> response = new Response<Vehicle>();
        //    try
        //    {
        //        _vehicleRepository.CreateVehicle(vehicle);
        //        response.Success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //    return vehicle;
        //}
        public Response<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            Response<Vehicle> response = new Response<Vehicle>();
            try
            {
                _vehicleRepository.CreateVehicle(vehicle);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Vehicle> DeleteVehicle(int VehicleId)
        {
            Response<Vehicle> response = new Response<Vehicle>();
            try
            {
                _vehicleRepository.DeleteVehicle(VehicleId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Vehicle> EditVehicle(Vehicle vehicle)
        {
            Response<Vehicle> response = new Response<Vehicle>();
            try
            {
                _vehicleRepository.EditVehicle(vehicle);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<Vehicle> GetByVehicleId(int VehicleId)
        {
            Response<Vehicle> response = new Response<Vehicle>();
            try
            {
                response.Data = _vehicleRepository.GetByVehicleId(VehicleId);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Vehicle>> GetAllVehicles()
        {
            Response<List<Vehicle>> response = new Response<List<Vehicle>>();
            try
            {
                response.Data = _vehicleRepository.GetAllVehicles();
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
        public Response<List<Vehicle>> GetAllByMakeModelYear(string QuickSearch)
        {
            Response<List<Vehicle>> response = new Response<List<Vehicle>>();
            try
            {
                response.Data = _vehicleRepository.GetByAllByMakeModelYear(QuickSearch);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }
    }
}
