using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        public float BatteryMaxTime { get; set; }

        protected static new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "BatteryMaxTime", "Please insert battery max time" },
        };

        public ElectricVehicle(Dictionary<string, string> i_inputValues) : base(i_inputValues)
        {
            if (i_inputValues != null)
            {
                if (int.TryParse(i_inputValues["BatteryMaxTime"], out int o_BatteryMaxTimeInput))
                {
                    this.BatteryMaxTime = o_BatteryMaxTimeInput;
                }
                else
                {
                    throw new ArgumentException("Invalid max battery time inserted");
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

        public void RechargeBattery(float i_rechargeTimeInHours)
        {
            if (this.AmountOfEnergyLeft + i_rechargeTimeInHours > this.BatteryMaxTime)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AmountOfEnergyLeft += i_rechargeTimeInHours;
        }

        public override string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.GetVehicleInformation());

            sb.Append(string.Format("Battery max time : {0}", this.BatteryMaxTime.ToString()));

            return sb.ToString();
        }
    }
}
