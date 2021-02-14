using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TollFeeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateTimes = new List<DateTime> 
            {
                
                new DateTime(2021,5,26,7,00,00), 
                 new DateTime(2021,5,26,8,00,00),              
                new DateTime(2021,5,26,16,29,31),
                new DateTime(2021,5,26,17,59,31),
                new DateTime(2021,5,26,18,00,31),                
                 new DateTime(2021,5,26,6,00,00),  
            };
            Console.WriteLine("Hello, Welcome to Toll Fee Calculator");
            IVehicle bike = new Motorbike();
            IVehicle car = new Car();
            TollCalculator obj = new TollCalculator();
            try
            {
                Console.WriteLine("Total Fee  " + obj.GetTollFee(car, dateTimes));
            }
            catch (TollFeeCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Some Error occured in the application");
            }

        }
    }
}
