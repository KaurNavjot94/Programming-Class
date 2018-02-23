using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarrageMechanic
{
    class Program
    {
        enum TimeFrame
        {
            am10h00m = 0,
            am10h30m = 1,
            am11h00m = 2,
            am11h30m = 3,
            pm01h00m = 4,
            pm01h30m = 5,
            pm02h00m = 6,
            pm02h30m = 7,
            pm03h00m = 8,
            pm03h30m = 9,

        }
        enum AllVehicles
        {
            Cars, Buses, Trucks, Tractors
        }
        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.Apply();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        public void Apply()
        {
            // intialized Objects
            Program p = new Program();

            // Getting intial values
            var frameTime = Enum.GetNames(typeof(TimeFrame));
            var frameOrder = Enum.GetValues(typeof(TimeFrame));

            
            Hashtable hTable = new Hashtable();

            Booking[] booking = new Booking[frameTime.Length];
            for (int i = 0; i < frameOrder.Length; i++)
            {
                string frameName = p.GetSlotFormats(frameTime[i]);
                int slotePlace = (int)frameOrder.GetValue(i);

                // appending frame to hash collection
                hTable.Add(slotePlace, frameName);

                // appending frames to Booking
                booking[i] = new Booking();
                booking[i].Time = frameName;
            }

            bool needToBook = false;

           
            do
            {
                needToBook = p.GetYesNo("Do you need any bookings?(Y/N)");
               
                if (!needToBook)
                {
                    continue;
                }

               
                foreach (int frameIndex in frameOrder)
                {
                    if (hTable.ContainsKey(frameIndex))
                    {
                        Console.WriteLine("{0}. {1}", (int)frameIndex + 1, hTable[frameIndex]);
                    }
                }

                // get frame from client
                string selectedFrame = string.Empty;
                int frameNumber = 0;
                do
                {
                    Console.Write("Please choose available time frame [0 to exit]: ");
                    selectedFrame = Console.ReadLine();
                } while (!int.TryParse(selectedFrame, out frameNumber) || (frameNumber < 0 || frameNumber > hTable.Keys.Count));

                if (frameNumber == 0)
                {
                    needToBook = false;
                    continue;
                }

                // get infoormation about vehicle
                if (frameNumber > 0 && frameNumber <= hTable.Keys.Count)
                {
                    // show  vehicles 
                    Console.WriteLine("Choose vehicle type:");
                    var vehicles = Enum.GetValues(typeof(AllVehicles));
                    int count = 0;
                    foreach (var val in vehicles)
                    {
                        Console.WriteLine("{0}. {1}", ++count, val);
                    }

                    string vehicleSelected = String.Empty;
                    int vehicleChoice = 0;
                    do
                    {
                        Console.Write("Choose your vehicle[0 to exit]: ");
                        vehicleSelected = Console.ReadLine();
                    } while (!int.TryParse(vehicleSelected, out vehicleChoice) || (vehicleChoice < 0 || vehicleChoice > vehicles.Length));


                    if (vehicleChoice == 0)
                    {
                        needToBook = false;
                        continue;
                    }
                    else
                    {
                        // getting properties of vehicle
                        string year = p.YearOnly("Year of manufacture? : ");
                        string company = p.GetSting("name of Company? : ");
                        string model = p.GetSting("Name of Model? : ");

                        Vehicles vehicle = null;

                        // get information of particular Vehicle

                        switch (vehicleChoice - 1)
                        {
                            case (int)AllVehicles.Cars:
                                bool needBodyTuneUp = p.GetYesNo("Need Body Tune Up?(Y/N) : ");
                                vehicle = new PassengerCar(year, company, model, needBodyTuneUp);
                                break;

                            case (int)AllVehicles.Buses:
                                bool needInteriorCleanup = p.GetYesNo("Require clean up of interior?(Y/N) : ");
                                vehicle = new SchoolBus(year, company, model, needInteriorCleanup);
                                break;

                            case (int)AllVehicles.Trucks:
                                bool installCover = p.GetYesNo("Require installation of Cover?(Y/N) : ");
                                vehicle = new Trucks(year, company, model, installCover);
                                break;

                            case (int)AllVehicles.Tractors:
                                bool ptoRepaired = p.GetYesNo("Require PTO repaired?(Y/N) : ");
                                vehicle = new Tractors(year, company, model, ptoRepaired);
                                break;

                            default:
                                throw new Exception("Serice for these vehicles is not available");
                        }

                        booking[frameNumber - 1].Customer = vehicle.ToString();
                        vehicle.ShowTypeOfVehicle();
                        needToBook = true;
                        hTable.Remove(frameNumber - 1);

                    }

                }



            } while (needToBook && hTable.Keys.Count > 0);

            for (int i = 0; i < booking.Length; i++)
            {
                if (booking[i].Customer != null)
                {
                    Console.WriteLine("Time : {0}, Vehicle : {1}", booking[i].Time, booking[i].Customer);
                }
            }

            Console.ReadKey();
        }

        
        private string GetSlotFormats(string name)
        {
            string meridiem = name.Substring(0, 2);        
            string hours = name.Substring(2, 2);          
            string minutes = name.Substring(5, 2);          
            return hours + ":" + minutes + " " + meridiem;
        }

        
        private bool GetYesNo(string prom)
        {
            string reply = string.Empty;
            do
            {
                Console.Write(prom);
                reply = Console.ReadLine();
            } while (reply != "Y" && reply != "N");  // validations
            if (reply == "Y")
            {
                return true;
            }
            return false;
        }
        private string GetSting(string message)
        {
            string reply = string.Empty;
            do
            {
                Console.Write(message);
                reply = Console.ReadLine();
            } while (reply.Length == 0);  // validation for null value
            return reply;
        }
        private string YearOnly(string message)
        {
            string reply = string.Empty;
            int year = 0;
            do
            {
                Console.Write(message);
                reply = Console.ReadLine();
            } while (!int.TryParse(reply, out year) || reply.Length != 4);  
            return reply; ;
        }
    }
}
