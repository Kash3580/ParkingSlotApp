using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp
{

    public class Parking:IParking
    {
        Slot[] slots = new Slot[30].Select(h => new Slot()).ToArray();
        public int cnt = 0;
        public Parking()
        {
            Random r = new Random();
            foreach (Slot item in slots)
            {
                Vehicle v = new Vehicle();
                int res = r.Next(1, 4);
                v.vtype = (VehicleType)res;
                item.SlotNo = "P" + cnt;   // Assigning Parking Slot
                item.isAvailable = true;
                item.vehicle = v;
                cnt++;
            }
        }

        //Return all parking slots
        public Slot[] getAllSlots()
        {
            return slots;

        }

        //Find available parking slot based on vehicle type and assign parking slot to specific vehicle
        public string AllocateParking(Vehicle vehicle, VehicleType vehType)
        {
            Slot slot = CheckAvailability(vehType);
            if (slot == null) return "There is no slot available for vehicle type " + vehType;
            slots = slots.Select(s => {
                if (s.SlotNo == slot.SlotNo)
                {
                    s.vehicle = vehicle;
                    s.isAvailable = false;
                    s.vehicle.vtype = vehType;

                }
                return s;

            }).ToArray();

            return "Sucessfully Assigned Slot no " + slot.SlotNo;
        }

        //deallocate parking slot
        public string DeallocateParking(string slotno)
        {
          //  Slot slot = SearchVehicle(vehicle.VehicleNo);
            try
            {
                Slot slot = slots.FirstOrDefault(s => s.SlotNo == slotno);
                if (slot != null)
                    if (slot.isAvailable == true) return "You have entered wrong slot. its already avaialable";


                slots = slots.Select(s => {
                    if (s.SlotNo == slotno && s.isAvailable==false)
                    {
                        s.vehicle.EntryDateTime = null;
                        s.vehicle.VehicleNo = null;
                        s.isAvailable = true;

                    }
                 return s;

                }).ToArray();

            
            }
            catch (Exception)
            {
                return "Something went wrong!! Please correct Slot No.";

            }         

            return "Parking successfully deallocated. Now Slot No " + slotno+" is Available " ;
        }
        
        //Find parking slot based on vehicle type
        public Slot CheckAvailability(VehicleType vehicleType)
        {
            Slot slot = null;
            try
            {
                slot = slots.FirstOrDefault(s => s.isAvailable == true && s.vehicle.vtype == vehicleType);
            }
            catch (Exception)
            {

                slot = null;
            }


            return slot;

        }

        //Find exact slot number based on vehicle no
        public Slot SearchVehicle(string veh_no)
        {
            Slot slot = null;
            try
            {
                slot = slots.FirstOrDefault(s => s.vehicle.VehicleNo == veh_no);
            }
            catch (Exception)
            {
                slot = null;
            }
            return slot;
        }


    }

}
