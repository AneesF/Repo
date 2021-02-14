using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TollFeeCalculator
{
    public static class DataAccessLayer
    {
        // Data to be pulled from database and cached
        public static readonly List<string> TollFreeVehicles = new List<string>()
                    {
                        "Motorbike",
                        "Emergency",
                        "Diplomat",
                        "Bus14Ton",
                        "Military"                   
                    };

        public static readonly List<TollFeeZone> tollzones = new List<TollFeeZone>()
        {
            
           (new TollFeeZone(new TimeSpan(6, 0, 0), new TimeSpan(6, 29, 0), 9)),
           (new TollFeeZone(new TimeSpan(6, 30, 0), new TimeSpan(6, 59, 0), 16)),
           (new TollFeeZone(new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 0), 22)),
           (new TollFeeZone(new TimeSpan(8, 0, 0), new TimeSpan(8, 29, 0), 16)),
           (new TollFeeZone(new TimeSpan(8, 30, 0), new TimeSpan(14, 59, 0), 9)),
           (new TollFeeZone(new TimeSpan(15, 0, 0), new TimeSpan(15, 29, 0), 16)),
           (new TollFeeZone(new TimeSpan(15, 29, 0), new TimeSpan(16, 59, 0), 22)),
           (new TollFeeZone(new TimeSpan(17, 0, 0), new TimeSpan(17, 59, 0), 16)),
           (new TollFeeZone(new TimeSpan(18, 0, 0), new TimeSpan(18, 29, 0), 9)),

        };

        public static readonly List<DateTime> AllTaxExemptDate = new List<DateTime>()
            {
                new DateTime(2021, 1, 1),
                new DateTime(2021, 1, 5),
                new DateTime(2021, 1, 6),
                new DateTime(2021, 4, 1),
                new DateTime(2021, 4, 2),
                new DateTime(2021, 4, 5),
                new DateTime(2021, 4, 30),
                new DateTime(2021, 5, 12),
                new DateTime(2021, 5, 13),
                new DateTime(2021, 6, 25),
                new DateTime(2021, 11, 5),
                new DateTime(2021, 12, 24),
                new DateTime(2021, 12, 31),

                new DateTime(2020, 1, 1),
                new DateTime(2020, 1, 6),
                new DateTime(2020, 4, 9),
                new DateTime(2020, 4, 10),
                new DateTime(2020, 4, 13),
                new DateTime(2020, 4, 30),
                new DateTime(2020, 5, 1),
                new DateTime(2020, 5, 20),
                new DateTime(2020, 5, 21),
                new DateTime(2020, 6, 5),
                new DateTime(2020, 6, 19),
                new DateTime(2020, 10, 30),
                new DateTime(2020, 12, 24),
                new DateTime(2020, 12, 25),
                new DateTime(2020, 12, 31),
            };

    }
}
