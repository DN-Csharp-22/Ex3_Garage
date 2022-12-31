using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : GasVehicle
    {
        public bool isMovingDangerousMaterials { get; set; }
        public float cargoVolume { get; set; }
    }
}