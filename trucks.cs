using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class Trucks : Vehicles
    {
        private bool installCover;
        public bool InstallCover { get => installCover;
                                  set => installCover = value; }

        public Trucks(string year, string company, string model, bool installCover) : base(year, company, model)
        {
            this.installCover = installCover;
        }
        public override void ShowTypeOfVehicle()
        {
            Console.WriteLine("repair service is available for Truck.");
        }
        public override string ToString()
        {
            return string.Format("Model of Truck : {0} , year : {1} and company: {2} need to install cover ", Model, Year, Company, (installCover) ? "Is" : "Is Not");

        }
    }
}
