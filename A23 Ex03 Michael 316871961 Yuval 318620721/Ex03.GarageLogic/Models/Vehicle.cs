using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string Model { get; set; }

        public string IdNumber { get; set; }

        public float AmountOfEnergyLeft { get; set; }

        public List<Wheel> wheels { get; set; }

        public VehicleStatus vehicleStatus { get; set; }

        protected readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "Model", "Please insert vehicle model" },
            { "AmountOfEnergyLeft", "Please insert vehicle power source left amount" },
            { "WheelsAmount", "Please insert vehicle wheels amount" },
        };

        public Vehicle(Dictionary<string, string> inputValues)
        {
            if (inputValues != null)
            {
                this.Model = inputValues["Model"];

                if (float.TryParse(inputValues["AmountOfEnergyLeft"], out float amountOfEnergyLeftInput))
                {
                    this.AmountOfEnergyLeft = amountOfEnergyLeftInput;
                }
                else
                {
                    throw new ArgumentException("Invalid current energy left amount was inserted");
                }

                this.wheels = new List<Wheel>();

                if (int.TryParse(inputValues["WheelsAmount"], out int wheelsAmount))
                {
                    for (int i = 0; i < wheelsAmount; i++)
                    {
                        this.wheels.Add(new Wheel(inputValues));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid amount of wheels was inserted");
                }
            }
        }

        public Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = (new Wheel(null)).GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }
    }
}
