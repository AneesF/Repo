using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TollFeeCalculator
{
    public class TollFeeZone
    {
        public TollFeeZone(TimeSpan start, TimeSpan end, int fee)
        {
            Start = start;
            End = end;
            Fee = fee;
        }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int Fee { get; set; }

        public bool IsValidFeeZone(DateTime time)
        {
            var timeSpan = new TimeSpan(time.Hour, time.Minute, 0);
            return (Start <= timeSpan && timeSpan <= End);
        }
    }   
}
