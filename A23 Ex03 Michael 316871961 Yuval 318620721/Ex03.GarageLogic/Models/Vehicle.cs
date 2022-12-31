using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string IdNumber { get; set; }
        public float AmountOfEnergyLeft { get; set; }

        public List<Wheel> wheels { get; set; }

        public VehicleStatus vehicleStatus { get; set; }

    }



}
