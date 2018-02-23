using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class PassengerCar:Vehicles
    {
        private bool requireBodyTuneUp;
        public bool NeedBodyTuneUp { get => requireBodyTuneUp; set => requireBodyTuneUp = value; }

        public PassengerCar(string year, string company, string model, bool needBodyTuneUp) : base(year, company, model)
        {
            this.requireBodyTuneUp = needBodyTuneUp;
        }
        public override void ShowTypeOfVehicle()
        {
            Console.WriteLine("Car is being ready to repair.");
        }

        public override string ToString()
        {
            return string.Format("This is Car of model : {0} , year : {1} and company : {2}, require body tune up ", Model, Year, Company, (requireBodyTuneUp) ? "Is" : "Is Not");
        }
    }
}
