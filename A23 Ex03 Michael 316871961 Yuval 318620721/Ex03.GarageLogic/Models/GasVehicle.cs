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

        protected static new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "gasType", string.Format("Please insert gas type out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(GasType))) },
            { "MaxFuelAmount", "Please insert max fuel amount" }
        };

        public GasVehicle(Dictionary<string, string> i_inputValues) : base(i_inputValues)
        {
            if (i_inputValues != null)
            {
                if (int.TryParse(i_inputValues["gasType"], out int o_gasTypeInput) && Enum.IsDefined(typeof(GasType), o_gasTypeInput - 1))
                {
                    this.gasType = (GasType)o_gasTypeInput;

                    if (float.TryParse(i_inputValues["MaxFuelAmount"], out float o_maxFuelAmountInput))
                    {
                        this.MaxFuelAmount = o_maxFuelAmountInput;
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

        public static new Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = Vehicle.GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }

        public void FillGas(float i_amountToFill)
        {
            if (this.AmountOfEnergyLeft + i_amountToFill > this.MaxFuelAmount)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AmountOfEnergyLeft += i_amountToFill;
        }

        public override string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.GetVehicleInformation());

            sb.AppendLine(string.Format("Gas type : {0}", this.gasType.ToString()));
            sb.Append(string.Format("MaxFuelAmount : {0}", this.MaxFuelAmount));

            return sb.ToString();
        }
    }
}
