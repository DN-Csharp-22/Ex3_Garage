using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : GasVehicle
    {
        public bool isMovingDangerousMaterials { get; set; }

        public float cargoVolume { get; set; }

        protected new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "isMovingDangerousMaterials", "Please insert 'true' for moving dangerous materials or 'no' for not moving" },
            { "cargoVolume", "Please insert cargo volume" },
        };

        public Truck(Dictionary<string, string> inputValues = null) : base(inputValues)
        {
            if (inputValues != null)
            {
                if (inputValues["isMovingDangerousMaterials"].ToLower() == "true")
                {
                    this.isMovingDangerousMaterials = true;
                }
                else if (inputValues["isMovingDangerousMaterials"].ToLower() == "false")
                {
                    this.isMovingDangerousMaterials = false;
                }
                else
                {
                    throw new ArgumentException("Invalid parameter value : truck moving dangerous metrials must be yes/no");
                }

                if (float.TryParse(inputValues["cargoVolume"], out float cargoVolumeInput))
                {
                    this.cargoVolume = cargoVolumeInput;
                }
                else
                {
                    throw new ArgumentException("Invalid cargo volume was inserted");
                }
            }
        }

        public new Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = base.GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }

        public string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.GetVehicleInformation());

            sb.AppendLine(string.Format("Is Moving Dangerous Materials : {0}", this.isMovingDangerousMaterials.ToString()));
            sb.AppendLine(string.Format("Cargo volume : {0}", this.cargoVolume.ToString()));

            return sb.ToString();
        }
    }
}