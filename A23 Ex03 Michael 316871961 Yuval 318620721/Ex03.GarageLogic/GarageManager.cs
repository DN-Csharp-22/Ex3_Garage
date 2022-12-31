using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public List<string> allowedVehicles { get; set; }

        private Dictionary<string, Vehicle> VehiclesInGarage { get; set; }

        public List<Vehicle> getCurrentVehiclesInGarage()
        {
            List<Vehicle> result = VehiclesInGarage.Values.ToList();

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

        public void updateVehicleStatus(string carLicenseNumber, VehicleStatus changeStatusOptionInput)
        {
            VehiclesInGarage[carLicenseNumber].vehicleStatus = changeStatusOptionInput;
        }

        public void fillTires(string carLicenseNumber)
        {
            Vehicle currentVehicle = VehiclesInGarage[carLicenseNumber];

            foreach (Wheel wheel in currentVehicle.wheels)
            {
                wheel.FillTirePressure(wheel.MaxPressure - wheel.CurrentPressure);
            }
        }

        public void FillGasTank(string carLicenseNumber, GasType gasType, int amountToFill)
        {
            if (VehiclesInGarage[carLicenseNumber].GetType() == typeof(GasCar))
            {
                GasCar gasCar = (GasCar)VehiclesInGarage[carLicenseNumber];

                if (gasCar.gasType != gasType)
                {
                    throw new ArgumentException("Requested Gas type differs from the current gas type");
                }

                gasCar.FillGas(amountToFill);
            }
            else if (VehiclesInGarage[carLicenseNumber].GetType() == typeof(GasMotorcycle))
            {
                GasMotorcycle gasMotorcycle = (GasMotorcycle)VehiclesInGarage[carLicenseNumber];

                if (gasMotorcycle.gasType != gasType)
                {
                    throw new ArgumentException("Requested Gas type differs from the current gas type");
                }

                gasMotorcycle.FillGas(amountToFill);
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with number : {0} is not an gas vehicle!", carLicenseNumber));
            }
        }
    }
}
