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

        public ElectricVehicle(Dictionary<string, string> inputValues) : base(inputValues)
        {
            if (inputValues != null)
            {
                if (int.TryParse(inputValues["BatteryMaxTime"], out int BatteryMaxTimeInput))
                {
                    this.BatteryMaxTime = BatteryMaxTimeInput;
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

        public void RechargeBattery(float rechargeTimeInHours)
        {
            if (this.AmountOfEnergyLeft + rechargeTimeInHours > this.BatteryMaxTime)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AmountOfEnergyLeft += rechargeTimeInHours;
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
