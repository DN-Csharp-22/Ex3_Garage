using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }

        public float CurrentPressure { get; set; }

        public float MaxPressure { get; set; }

        public void FillTirePressure(float PressureToFill)
        {
            if (this.CurrentPressure + PressureToFill > this.MaxPressure)
            {
                throw new Exception("you have exceeded the maximun tire pressure");
            }

            this.CurrentPressure += PressureToFill;
        }
    }
}
