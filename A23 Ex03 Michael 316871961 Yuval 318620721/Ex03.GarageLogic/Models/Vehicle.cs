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

        internal List<Wheel> wheels { get; set; }

        public VehicleStatus vehicleStatus { get; set; }

        protected static readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "Model", "Please insert vehicle model" },
            { "AmountOfEnergyLeft", "Please insert vehicle power source left amount" },
            { "WheelsAmount", "Please insert vehicle wheels amount" },
        };

        public Vehicle(Dictionary<string, string> i_inputValues)
        {
            if (i_inputValues != null)
            {
                this.Model = i_inputValues["Model"];
                this.IdNumber = i_inputValues["IdNumber"];

                if (float.TryParse(i_inputValues["AmountOfEnergyLeft"], out float o_amountOfEnergyLeftInput))
                {
                    this.AmountOfEnergyLeft = o_amountOfEnergyLeftInput;
                }
                else
                {
                    throw new ArgumentException("Invalid current energy left amount was inserted");
                }

                this.wheels = new List<Wheel>();

                if (int.TryParse(i_inputValues["WheelsAmount"], out int o_wheelsAmount))
                {
                    for (int i = 0; i < o_wheelsAmount; i++)
                    {
                        this.wheels.Add(new Wheel(i_inputValues));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid amount of wheels was inserted");
                }
            }
        }

        public static Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = Wheel.GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }

        public virtual string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("IdNumber : {0}", this.IdNumber));
            sb.AppendLine(string.Format("Model : {0}", this.Model));
            sb.AppendLine(string.Format("AmountOfEnergyLeft : {0}", this.AmountOfEnergyLeft));
            sb.AppendLine(string.Format("Wheel amount : {0}", this.wheels.Count));
            sb.AppendLine(string.Format("Wheel information : \n{0}", wheels.FirstOrDefault().GetVehicleInformation()));

            return sb.ToString();
        }
    }
}
