using System;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        public float AccumulatorTimeLeft { get; set; }
        public int AccumulatorMaxTime { get; set; }

        public void AccumulatorFill (float amountToFill)
        {
            if (this.AccumulatorTimeLeft + amountToFill > this.AccumulatorMaxTime)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.AccumulatorTimeLeft += amountToFill;
        }

    }
}
