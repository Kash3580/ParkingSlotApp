using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ParkingApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int choice;
            IParking p = new Parking();
            bool input = true ;       

            do
            {
                try
                {
                    choice = 0;
                    int veh_type;
                    Console.WriteLine("\n1. Search Parking");
                    Console.WriteLine("2. Allocate Parking");
                    Console.WriteLine("3. Deallocate Parking");
                    Console.WriteLine("4. Search Vehicle ");
                    Console.WriteLine("5. Display All Slots");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("\n-------------------------------------------------------------------------");

                    Console.WriteLine("Enter Choice:");
                    string str = Console.ReadLine();
                    choice = Convert.ToInt32(str);     
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Select Vehicle Type:");
                            Console.WriteLine("\t 1.Hatchback\n\t 2.Sedan\n\t 3.Mini Truck");
                            veh_type = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n*******************************Result***********************************");

                            if (!(veh_type > 0 && veh_type < 4)) // if input is not between specified vehicle type then will show Error Message
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please correct your Vehicle Type. try Again!!");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                            Slot AvaialbleSlot = p.CheckAvailability((VehicleType)veh_type);
                          
                            if (AvaialbleSlot != null)
                            {
                                Console.WriteLine("Congratuation!!! You have avaialble Slot for your {0} vehicle", ((VehicleType)veh_type));
                                Console.WriteLine("Available Parking Slot is " + AvaialbleSlot.SlotNo);
                                Console.WriteLine("Parking Fees: Rs. " + AvaialbleSlot.getPrice((VehicleType)veh_type));

                            }
                            else
                            {
                                Console.WriteLine("Opps!!! Parking is full", ((VehicleType)veh_type));
                            }
                            

                            break;

                        case 2:    //Allocating parking Slot
                            Vehicle veh = new Vehicle();
                            Console.WriteLine("Enter Vehicle No (Eg. MH14DK4915):");
                            veh.VehicleNo = Console.ReadLine();
                            veh.EntryDateTime = DateTime.Now;
                           
                            Console.WriteLine("1.Hatchback \t 2.Sedan \t 3.Mini Truck");
                            veh_type = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\n*************************Result****************************************");

                            Console.WriteLine("\t"+p.AllocateParking(veh, (VehicleType)veh_type));

                            Console.WriteLine("\n*************************************************************************");


                            break;
                        case 3:  //deallocating parking Slot
                            
                            Console.WriteLine("Enter Slot No:");

                            string slotno = Console.ReadLine();
                            Console.WriteLine("\n*************************************************************************");

                            Console.WriteLine("\t" + p.DeallocateParking(slotno.ToUpper()));

                            Console.WriteLine("\n*************************************************************************");

                            break;

                        case 4:// find slot number by Vehicle number
                            Console.WriteLine("Search Vehicle by Vehicle No (Eg. MH14DK4915):");
                            Slot slot = p.SearchVehicle(Console.ReadLine());
                            Console.WriteLine("\n---------------------------Result------------------------------------");
                            if (slot != null)
                            {
                                Console.WriteLine("\twe found your vehicle at slot no :" + slot.SlotNo);
                                Console.WriteLine("\tThank you for using our Parking!!!");                              
                            }
                            else
                            {
                                Console.WriteLine("\t\tNo vehicle found");
                            }
                            Console.WriteLine("\n-------------------------------------------------------------------------");
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Slot[] allslots=  p.getAllSlots();
                            for (int i = 0; i < allslots.Length; i=i+5)
                            {
                                Console.Write("\n|{0}-{1}({2})\t", allslots[i].SlotNo, allslots[i].isAvailable ?  "Available": "Allocated", allslots[i].vehicle.vtype);
                                Console.Write("|{0}-{1}({2})\t", allslots[i+1].SlotNo, allslots[i+1].isAvailable ?"Available" :"Allocated" , allslots[i + 1].vehicle.vtype);
                                Console.Write("|{0}-{1}({2})\t", allslots[i+2].SlotNo, allslots[i+2].isAvailable ?"Available" :"Allocated" , allslots[i + 2].vehicle.vtype);
                                Console.Write("|{0}-{1}({2})\t", allslots[i+3].SlotNo, allslots[i+3].isAvailable ?"Available" :"Allocated" , allslots[i + 3].vehicle.vtype);
                                Console.Write("|{0}-{1}({2})\t", allslots[i+4].SlotNo, allslots[i+4].isAvailable ?"Available" :"Allocated", allslots[i + 4].vehicle.vtype);

                            }

                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("\n*************************************************************************\n\n");

                            break;
                        case 6:

                            input = false;
                            break;

                        default:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select correct option");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    } 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (input);
            Console.WriteLine("Press <Enter> to exit!!");
            Console.Read();
        }


    }

}
