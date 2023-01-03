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

        public void createVehicle(Type i_vehicleType, Dictionary<string, string> i_inputValues)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Vehicle newVehicle = vehicleFactory.CreateVehicle(i_vehicleType, i_inputValues);

            VehiclesInGarage.Add(i_inputValues["IdNumber"], newVehicle);
        }

        public List<Vehicle> getCurrentVehiclesInGarage()
        {
            List<Vehicle> result = VehiclesInGarage.Values.ToList();
            return result;
        }

        public Vehicle GetVehicle(string i_id)
        {
            KeyValuePair<string, Vehicle> foundVehicle = VehiclesInGarage.Where(vehicle => vehicle.Value.IdNumber == i_id.ToLower()).FirstOrDefault();

            Vehicle result = foundVehicle.Value;

            return result;
        }

        public Dictionary<string, string> getVehicleInputMessages(Type i_vehicleType)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Dictionary<string, string> inputMessages = vehicleFactory.GetInputMessages(i_vehicleType);

            return inputMessages;
        }

        public void updateVehicleStatus(string i_carLicenseNumber, VehicleStatus i_changeStatusOptionInput)
        {
            VehiclesInGarage[i_carLicenseNumber].vehicleStatus = i_changeStatusOptionInput;
        }

        public void fillTires(string i_carLicenseNumber)
        {
            Vehicle currentVehicle = VehiclesInGarage[i_carLicenseNumber];

            foreach (Wheel wheel in currentVehicle.wheels)
            {
                wheel.FillTirePressure(wheel.MaxPressure - wheel.CurrentPressure);
            }
        }

        public void chargingElectricMotor(string i_carLicenseNumber, int i_chargeTimeInMinutes)
        {
            float chargeTimeInHours = (float)i_chargeTimeInMinutes / 60;

            ElectricCar electricCar = (ElectricCar)VehiclesInGarage[i_carLicenseNumber];

            electricCar.RechargeBattery(chargeTimeInHours);
        }

        public void FillGasTank(string i_carLicenseNumber, GasType i_gasType, int i_amountToFill)
        {
            if (VehiclesInGarage.ContainsKey(i_carLicenseNumber))
            {
                Vehicle vehicle = VehiclesInGarage[i_carLicenseNumber];

                if(vehicle.GetType().BaseType == typeof(GasVehicle))
                {
                    ((GasVehicle)vehicle).FillGas(i_amountToFill);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with number : {0} is not an gas vehicle!", i_carLicenseNumber));
                }
            }
        }

        public string displayVehicleData(string i_carLicenseNumber)
        {
            Vehicle currentVehicle = VehiclesInGarage[i_carLicenseNumber];

            return currentVehicle.GetVehicleInformation();
        }
    }
}
