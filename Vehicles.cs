using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class Vehicles
    {
        private bool OilChange;
        private bool EngineTuneUp;
        private bool TransmissionCleanUp;

        private string year;
        private string company;
        private string model;

        public bool NeedOilChange { get => OilChange; set => OilChange = value; }
        public bool NeedEngineTuneUp { get => EngineTuneUp; set => EngineTuneUp = value; }
        public bool NeedTransmissionCleanUp { get => TransmissionCleanUp; set => TransmissionCleanUp = value; }

        public string Year { get => year; set => year = value; }
        public string Company { get => company; set => company = value; }
        public string Model { get => model; set => model = value; }


        public Vehicles() { }

        public Vehicles(string year, string company, string model)
        {
            this.year = year;
            this.company = company;
            this.model = model;
        }
        public virtual void ShowTypeOfVehicle()
        {
            Console.WriteLine("Service for general vehicles is not available");
        }

    }
}
