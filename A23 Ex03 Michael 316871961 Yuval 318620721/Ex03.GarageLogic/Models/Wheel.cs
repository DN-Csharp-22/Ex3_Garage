using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }

        public float CurrentPressure { get; set; }

        public float MaxPressure { get; set; }

        private readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "ManufacturerName", "Please insert tire manufacturer name" },
            { "CurrentPressure", "Please insert tire current pressure amount" },
            { "MaxPressure", "Please insert tire max pressure amount" }
        };

        public Dictionary<string, string> GetInputMessages()
        {
            return inputMessages;
        }

        public Wheel(Dictionary<string, string> inputValues)
        {
            if (inputValues != null)
            {
                this.ManufacturerName = inputValues["ManufacturerName"];
                if (float.TryParse(inputValues["CurrentPressure"], out float currentPressureInput))
                {
                    this.CurrentPressure = currentPressureInput;
                }
                else
                {
                    throw new ArgumentException("Invalid current tire pressure amount was inserted");
                }

                if (float.TryParse(inputValues["MaxPressure"], out float maxPressureInput))
                {
                    this.MaxPressure = maxPressureInput;
                }
                else
                {
                    throw new ArgumentException("Invalid max tire pressure amount was inserted");
                }
            }
        }

        public void FillTirePressure(float pressureToFill)
        {
            if (this.CurrentPressure + pressureToFill > this.MaxPressure)
            {
                throw new Exception("you have exceeded the maximun tire pressure");
            }

            this.CurrentPressure += pressureToFill;
        }
    }
}
