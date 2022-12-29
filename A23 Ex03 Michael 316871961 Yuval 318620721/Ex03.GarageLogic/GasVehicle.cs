using System;

namespace Ex03.GarageLogic
{
    public class GasVehicle : Vehicle
    {
        public GasType gasType { get; set; }

        public float CurrentAmountOfGas { get; set; }

        public float MaxAmountOfGas { get; set; }

        public void FillGas(float amountToFill)
        {
            if (this.CurrentAmountOfGas + amountToFill > this.MaxAmountOfGas)
            {
                throw new Exception("you have exceeded the maximun Ampere amount");
            }

            this.CurrentAmountOfGas += amountToFill;
        }
    }

    public class GasCar : GasVehicle
    {
        public CarColors carColor { get; set; }

        public DoorAmount doorAmount { get; set; }



    }


}
