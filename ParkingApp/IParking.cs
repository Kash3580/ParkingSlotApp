using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp
{
    interface IParking
    {
        Slot[] getAllSlots();
        string AllocateParking(Vehicle vehicle, VehicleType vehType);
        string DeallocateParking(string slotno);
        Slot CheckAvailability(VehicleType vehicleType);
        Slot SearchVehicle(string veh_no);
    }
}
