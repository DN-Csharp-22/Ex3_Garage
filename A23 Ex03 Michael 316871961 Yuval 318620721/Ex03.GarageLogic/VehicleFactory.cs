using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleFactory
    {
        public static readonly Dictionary<string, Type> ALLOWED_VEHICLES_DICTIONARY = new Dictionary<string, Type>
        {
            { "1", typeof(GasCar) },
            { "2", typeof(ElectricCar) },
            { "3", typeof(GasMotorcycle) },
            { "4", typeof(ElectricMotorcycle) },
            { "5", typeof(Truck) }
        };

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
                    inputMessages = GasCar.GetInputMessages();
                    break;
                case nameof(ElectricCar):
                    inputMessages = ElectricCar.GetInputMessages();
                    break;
                case nameof(GasMotorcycle):
                    inputMessages = GasMotorcycle.GetInputMessages();
                    break;
                case nameof(ElectricMotorcycle):
                    inputMessages = ElectricMotorcycle.GetInputMessages();
                    break;
                case nameof(Truck):
                    inputMessages = Truck.GetInputMessages();
                    break;
                default:
                    throw new Exception("unsupported vehicle");
            }

            return inputMessages;
        }
    }
}
