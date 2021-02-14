using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TollFeeCalculator
{
    public enum VehicleType
    {
        Car,
        Motorbike,
        Emergency,
        Diplomat,
        Foreign,
        Bus,
        Bus14Ton,
        Military
    }

    public interface IVehicle
    {
        VehicleType GetVehicleType();
    }

}