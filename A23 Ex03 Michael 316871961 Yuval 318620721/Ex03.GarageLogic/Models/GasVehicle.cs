using System;

namespace Ex03.GarageLogic
{
    public class GasVehicle : Vehicle
    {
        public GasType gasType { get; set; }

        public float CurrentFuelAmount { get; set; }

        public float MaxFuelAmount { get; set; }

        public void FillGas(float amountToFill)
        {
            if (this.CurrentFuelAmount + amountToFill > this.MaxFuelAmount)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.CurrentFuelAmount += amountToFill;
        }
    }
}
