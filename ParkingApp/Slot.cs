using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp
{
    public class Slot
    {
        public string SlotNo { get; set; }
        public Vehicle vehicle;
        public bool isAvailable { get; set; }   

        public int getPrice(VehicleType vtype)
        {
            if (vtype.ToString() == SlotPrice.HatchBack.ToString())
                return ((int)SlotPrice.HatchBack);
            if (vtype.ToString() == SlotPrice.Sedan.ToString())
                return ((int)SlotPrice.Sedan);
            if (vtype.ToString() == SlotPrice.MiniTruck.ToString())
                return ((int)SlotPrice.MiniTruck);
            return 0;
        }

    }

}
