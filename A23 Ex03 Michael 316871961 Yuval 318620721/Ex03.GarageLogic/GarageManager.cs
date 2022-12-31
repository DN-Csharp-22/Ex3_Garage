using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public List<string> allowedVehicles { get; set; }

        private Dictionary<string, Vehicle> VehiclesInGarage { get; set; }

        public List<string> getCarList(VehicleStatus vehicleStatus)
        {
            List<string> result = VehiclesInGarage.Where(vechile => vechile.Value.vehicleStatus == vehicleStatus)
                .Select(vehicle => vehicle.Key).ToList();

            return result;
        }
        public List<string> getCarList()
        {
            List<string> result = VehiclesInGarage.Keys.ToList();

            return result;
        }
        public Vehicle createVehicle(string vehicleType)
        {
            if (!allowedVehicles.Contains(vehicleType))
            {
                throw new Exception("unsupported vehicle");

            }

            switch (vehicleType)
            {
                default:
                    break;
            }
            return null;
        }
    }
}
