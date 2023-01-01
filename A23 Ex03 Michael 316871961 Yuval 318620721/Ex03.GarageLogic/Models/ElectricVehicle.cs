using System;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        public float AccumulatorTimeLeft { get; set; }
        public int AccumulatorMaxTime { get; set; }

        public void RechargeAccumulator (int rechargeTimeInHours)
        {
            if (this.AccumulatorTimeLeft + rechargeTimeInHours > this.AccumulatorMaxTime)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AccumulatorTimeLeft += rechargeTimeInHours;
        }
    }
}
