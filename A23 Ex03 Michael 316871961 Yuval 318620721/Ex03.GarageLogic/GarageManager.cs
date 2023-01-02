using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public static readonly Dictionary<string, Type> ALLOWED_VEHICLES_DICTIONARY = new Dictionary<string, Type> 
        {
            { "1", typeof(GasCar) },
            { "2", typeof(ElectricCar) },
            { "3", typeof(GasMotorcycle) },
            { "4", typeof(ElectricMotorcycle) },
            { "5", typeof(Truck) }
        };

        private Dictionary<string, Vehicle> VehiclesInGarage { get; set; }

        public GarageManager()
        {
            this.VehiclesInGarage = new Dictionary<string, Vehicle>();
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
            int chargeTimeInHours = chargeTimeInMinutes / 60;

            ElectricCar electricCar = (ElectricCar)VehiclesInGarage[carLicenseNumber];

            electricCar.RechargeBattery(chargeTimeInHours);
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

        public string displayVehicleData(string carLicenseNumber)
        {
            object currentVehicle = VehiclesInGarage[carLicenseNumber];
            Type t = currentVehicle.GetType();

            object b = Convert.ChangeType(VehiclesInGarage[carLicenseNumber], VehiclesInGarage[carLicenseNumber].GetType());

            return (Vehicle)b.GetVehicleInformation();
        }
    }
}
