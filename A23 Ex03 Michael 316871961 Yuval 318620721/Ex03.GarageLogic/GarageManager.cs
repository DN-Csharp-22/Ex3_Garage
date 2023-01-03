using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Vehicle> VehiclesInGarage { get; set; }

        public GarageManager()
        {
            this.VehiclesInGarage = new Dictionary<string, Vehicle>();
        }

        public Dictionary<string, Type> GetAllowedVehicles()
        {
           return VehicleFactory.ALLOWED_VEHICLES_DICTIONARY;
        }

        public void createVehicle(Type vehicleType, Dictionary<string, string> inputValues)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Vehicle newVehicle = vehicleFactory.CreateVehicle(vehicleType, inputValues);

            VehiclesInGarage.Add(inputValues["IdNumber"], newVehicle);
        }

        public List<Vehicle> getCurrentVehiclesInGarage()
        {
            List<Vehicle> result = VehiclesInGarage.Values.ToList();
            return result;
        }

        public Vehicle GetVehicle(string id)
        {
            KeyValuePair<string, Vehicle> foundVehicle = VehiclesInGarage.Where(vehicle => vehicle.Value.IdNumber == id.ToLower()).FirstOrDefault();

            Vehicle result = foundVehicle.Value;

            return result;
        }

        public Dictionary<string, string> getVehicleInputMessages(Type vehicleType)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Dictionary<string, string> inputMessages = vehicleFactory.GetInputMessages(vehicleType);

            return inputMessages;
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

        public void chargingElectricMotor(string carLicenseNumber, int chargeTimeInMinutes)
        {
            float chargeTimeInHours = (float)chargeTimeInMinutes / 60;

            ElectricCar electricCar = (ElectricCar)VehiclesInGarage[carLicenseNumber];

            electricCar.RechargeBattery(chargeTimeInHours);
        }

        public void FillGasTank(string carLicenseNumber, GasType gasType, int amountToFill)
        {
            if (VehiclesInGarage.ContainsKey(carLicenseNumber))
            {
                Vehicle vehicle = VehiclesInGarage[carLicenseNumber];

                if(vehicle.GetType().BaseType == typeof(GasVehicle))
                {
                    ((GasVehicle)vehicle).FillGas(amountToFill);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with number : {0} is not an gas vehicle!", carLicenseNumber));
                }
            }
        }

        public string displayVehicleData(string carLicenseNumber)
        {
            Vehicle currentVehicle = VehiclesInGarage[carLicenseNumber];

            return currentVehicle.GetVehicleInformation();
        }
    }
}
