using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class Tractors:Vehicles
    {
        private bool ptoRepaired;
        public bool PtoRepaired { get => ptoRepaired; set => ptoRepaired = value; }

        public Tractors(string year, string company, string model, bool ptoRepaired) : base(year, company, model)
        {
            this.ptoRepaired = ptoRepaired;
        }
        public override void ShowTypeOfVehicle()
        {
            Console.WriteLine("repair service is available for tarctor.");
        }
        public override string ToString()
        {
            return string.Format("model of tractor : {0} , year : {1} and company: {2} require PTO repaired ", Model, Year, Company, (ptoRepaired) ? "Is" : "Is Not");
        }
    }
    
}
