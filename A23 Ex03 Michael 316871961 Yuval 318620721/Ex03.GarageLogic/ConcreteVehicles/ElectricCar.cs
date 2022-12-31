using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        public CarColors carColor { get; set; }
        public DoorAmount doorAmount { get; set; }
    }
}