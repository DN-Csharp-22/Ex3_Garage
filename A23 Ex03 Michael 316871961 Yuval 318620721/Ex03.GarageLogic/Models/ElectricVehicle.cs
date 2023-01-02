using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        public int BatteryMaxTime { get; set; }

        protected new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
            { "BatteryMaxTime", string.Format("Please insert door amount out of : \n{0}", string.Join(",", Enum.GetNames(typeof(CarColors)))) },
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

        public void RechargeBattery(int rechargeTimeInHours)
        {
            if (this.AmountOfEnergyLeft + rechargeTimeInHours > this.BatteryMaxTime)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AmountOfEnergyLeft += rechargeTimeInHours;
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
