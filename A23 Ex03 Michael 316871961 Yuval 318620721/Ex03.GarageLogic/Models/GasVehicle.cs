using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GasVehicle : Vehicle
    {
        public GasType gasType { get; set; }

        public float MaxFuelAmount { get; set; }

        protected new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "gasType", string.Format("Please insert gas type out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(GasType))) },
            { "MaxFuelAmount", "Please insert max fuel amount" }
        };

        public GasVehicle(Dictionary<string, string> inputValues) : base(inputValues)
        {
            if (inputValues != null)
            {
                if (int.TryParse(inputValues["gasType"], out int gasTypeInput) && Enum.IsDefined(typeof(GasType), gasTypeInput))
                {
                    this.gasType = (GasType)gasTypeInput;

                    if (float.TryParse(inputValues["MaxFuelAmount"], out float maxFuelAmountInput))
                    {
                        this.MaxFuelAmount = maxFuelAmountInput;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid max fuel amount was inserted");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid gas type input");
                }
            }
        }

        public void FillGas(float amountToFill)
        {
            if (this.AmountOfEnergyLeft + amountToFill > this.MaxFuelAmount)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AmountOfEnergyLeft += amountToFill;
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

            sb.AppendLine(string.Format("Gas type : {0}", this.gasType.ToString()));
            sb.AppendLine(string.Format("MaxFuelAmount : {0}", this.MaxFuelAmount));

            return sb.ToString();
        }
    }
}
