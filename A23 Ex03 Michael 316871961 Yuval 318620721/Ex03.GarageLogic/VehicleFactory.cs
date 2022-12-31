using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public List<string> allowedVehicles { get; set; }
        
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
