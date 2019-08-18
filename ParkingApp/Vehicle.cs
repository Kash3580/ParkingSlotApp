using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp
{
    public class Vehicle
    { 
        public string VehicleNo{ get;   set; }
        public VehicleType vtype;
        public DateTime? EntryDateTime { get;  set; }      
    }

    public enum VehicleType
        {
            HatchBack=1,
            Sedan=2,
            MiniTruck=3
        }

    public enum SlotPrice
        {
            HatchBack = 20,
            Sedan = 40,
            MiniTruck = 50
        }

   


}
