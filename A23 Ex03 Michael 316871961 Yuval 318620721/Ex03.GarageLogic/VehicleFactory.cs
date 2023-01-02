using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleFactory
    {
        public Vehicle CreateVehicle(Type vehicleType, Dictionary<string, string> inputValues)
        {
            Vehicle result = null;

            switch (vehicleType.Name)
            {
                case nameof(GasCar):
                    result = new GasCar(inputValues);
                    break;
                case nameof(ElectricCar):
                    result = new ElectricCar(inputValues);
                    break;
                case nameof(GasMotorcycle):
                    result = new GasMotorcycle(inputValues);
                    break;
                case nameof(ElectricMotorcycle):
                    result = new ElectricMotorcycle(inputValues);
                    break;
                case nameof(Truck):
                    result = new Truck(inputValues);
                    break;
                default:
                    throw new Exception("unsupported vehicle");
            }

            return result;
        }

        public Dictionary<string, string> GetInputMessages(Type vehicleType)
        {
            Dictionary<string, string> inputMessages = null;

            switch (vehicleType.Name)
            {
                case nameof(GasCar):
                    inputMessages = (new GasCar()).GetInputMessages();
                    break;
                case nameof(ElectricCar):
                    inputMessages = (new ElectricCar()).GetInputMessages();
                    break;
                case nameof(GasMotorcycle):
                    inputMessages = (new GasMotorcycle()).GetInputMessages();
                    break;
                case nameof(ElectricMotorcycle):
                    inputMessages = (new ElectricMotorcycle()).GetInputMessages();
                    break;
                case nameof(Truck):
                    inputMessages = (new Truck()).GetInputMessages();
                    break;
                default:
                    throw new Exception("unsupported vehicle");
            }

            return inputMessages;
        }
    }
}
