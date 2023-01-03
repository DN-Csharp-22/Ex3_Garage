using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        public string ManufacturerName { get; set; }

        public float CurrentPressure { get; set; }

        public float MaxPressure { get; set; }

        private static readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "ManufacturerName", "Please insert tire manufacturer name" },
            { "CurrentPressure", "Please insert tire current pressure amount" },
            { "MaxPressure", "Please insert tire max pressure amount" }
        };

        internal static Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }
            
            return result;
        }

        public Wheel(Dictionary<string, string> i_inputValues)
        {
            if (i_inputValues != null)
            {
                this.ManufacturerName = i_inputValues["ManufacturerName"];
                if (float.TryParse(i_inputValues["CurrentPressure"], out float o_currentPressureInput))
                {
                    this.CurrentPressure = o_currentPressureInput;
                }
                else
                {
                    throw new ArgumentException("Invalid current tire pressure amount was inserted");
                }

                if (float.TryParse(i_inputValues["MaxPressure"], out float o_maxPressureInput))
                {
                    this.MaxPressure = o_maxPressureInput;
                }
                else
                {
                    throw new ArgumentException("Invalid max tire pressure amount was inserted");
                }
            }
        }

        public string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("ManufacturerName : {0}", this.ManufacturerName));
            sb.AppendLine(string.Format("CurrentPressure : {0}", this.CurrentPressure));
            sb.Append(string.Format("MaxPressure : {0}", this.MaxPressure));

            return sb.ToString();
        }

        public void FillTirePressure(float i_pressureToFill)
        {
            if (this.CurrentPressure + i_pressureToFill > this.MaxPressure)
            {
                throw new Exception("you have exceeded the maximun tire pressure");
            }

            this.CurrentPressure += i_pressureToFill;
        }
    }
}
