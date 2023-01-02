using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        public CarColors carColor { get; set; }

        public DoorAmount doorAmount { get; set; }

        protected new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "carColor",   string.Format("Please insert car color out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(CarColors))) },
            { "doorAmount", string.Format("Please insert door amount out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(DoorAmount))) },
        };

        public ElectricCar(Dictionary<string, string> inputValues = null) : base(inputValues)
        {
            if (inputValues != null)
            {
                if (int.TryParse(inputValues["carColor"], out int carColorInput) && Enum.IsDefined(typeof(CarColors), carColorInput))
                {
                    this.carColor = (CarColors)carColorInput;

                    if (int.TryParse(inputValues["doorAmount"], out int doorAmountInput) && Enum.IsDefined(typeof(DoorAmount), doorAmountInput))
                    {
                        this.doorAmount = (DoorAmount)doorAmountInput;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid door amount selected");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid car color selected");
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
    }
}