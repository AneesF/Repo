using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TollFeeCalculator
{
    public class TollFeeCustomException : Exception
    {
        public TollFeeCustomException(string message)
            : base(message)
        {
        }
    }
}
