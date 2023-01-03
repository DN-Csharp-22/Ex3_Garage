using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GasCar : GasVehicle
    {
        public CarColors carColor { get; set; }

        public DoorAmount doorAmount { get; set; }

        protected static new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "carColor", string.Format("Please insert car color out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(CarColors))) },
            { "doorAmount", string.Format("Please insert door amount out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(DoorAmount))) },
        };

        public GasCar(Dictionary<string, string> i_inputValues = null) : base(i_inputValues)
        {
            if (i_inputValues != null)
            {
                if (int.TryParse(i_inputValues["carColor"], out int o_carColorInput) && Enum.IsDefined(typeof(CarColors), o_carColorInput - 1))
                {
                    this.carColor = (CarColors)o_carColorInput;

                    if (int.TryParse(i_inputValues["doorAmount"], out int o_doorAmountInput) && Enum.IsDefined(typeof(DoorAmount), o_doorAmountInput - 1))
                    {
                        this.doorAmount = (DoorAmount)o_carColorInput;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid door amount selected");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid car color input");
                }
            }
        }

        public static new Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = GasVehicle.GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }

        public override string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("Gas car");
            sb.AppendLine(base.GetVehicleInformation());

            sb.AppendLine(string.Format("Car color : {0}", this.carColor.ToString()));
            sb.AppendLine(string.Format("Door amount : {0}", this.doorAmount.ToString()));

            return sb.ToString();
        }
    }
}
