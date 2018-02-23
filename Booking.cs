using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class Booking
    {
        private string time;
        private string client;
        public string Time { get => time; set => time = value; }
        public string Customer { get => client; set => client = value; }
    }
}
