using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class SchoolBus:Vehicles
    {
        private bool needInteriorCleanUp;
        public bool NeedInteriorCleanUp { get => needInteriorCleanUp; set => needInteriorCleanUp = value; }

        public SchoolBus(string year, string company, string model, bool needInteriorCleanUp) : base(year, company, model)
        {
            this.needInteriorCleanUp = needInteriorCleanUp;
        }
        public override void ShowTypeOfVehicle()
        {
            Console.WriteLine("repair service is available for bus.");
        }
        public override string ToString()
        {
            return string.Format("Model of bus : {0} , year : {1} and company: {2} require clean up of interior ", Model, Year, Company, (needInteriorCleanUp) ? "Is" : "Is Not");
        }
    }
}
