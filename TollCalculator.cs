using System;
using System.Globalization;
using System.Linq;
using TollFeeCalculator;
using System.Collections.Generic;


public class TollCalculator
{

    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    public const int JULY = 7;
    public const decimal MAXIMUM_FEE_PERDAY = 60;

    public decimal GetTollFee(IVehicle vehicle, List<DateTime> dates)
    {
        if (CheckIfTollFreeVehicle(vehicle))
            return 0;
        if (dates == null || dates.Count == 0)
            throw new TollFeeCustomException("Date cannot be empty");
        if (IsValidDates(dates))
            throw new TollFeeCustomException("You can calculate fee for one date only");
        if(CheckIfFreeDay(dates[0].Date))
            return 0;

        decimal totalFee = GetTollFees(dates);       
        return totalFee;
    }

    private bool CheckIfTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) throw new TollFeeCustomException("Vehicle cannot be empty");
         String vehicleType = vehicle.GetVehicleType().ToString();
         return DataAccessLayer.TollFreeVehicles.Contains(vehicleType);

    }

    private bool CheckIfFreeDay(DateTime date)
    {
        // no fee to pay on Saturdays, Sundays
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            return true;
        //no fee to pay during July
        if (date.Month == JULY)
            return true;
        var TaxExemptDates = GetTaxExemptByYear(date);        
        if (TaxExemptDates != null && TaxExemptDates.Count > 0)
        {
            // no fee to pay on “red days”/holiday and on day before “red days”/holiday
            if (TaxExemptDates.Contains(date.Date))
                return true;            
        }
        return false;
    }

    private bool IsValidDates(List<DateTime> dates)
    {
        // as per requirement date and time of all passes on one day only
        return dates.Any(d => d.Date != dates[0].Date);
    }

    private decimal GetTollFees(List<DateTime> dates)
    {
        var datesSorted = dates.OrderBy(x => x.TimeOfDay).ToList();
        //list of pay stations within 60 minutes 
        List<List<DateTime>> listbyTime = GetListByTime(datesSorted);
        decimal fee = 0;
        decimal[] tempFee;
        foreach (var date in listbyTime)
        {
            if (date.Count == 1)
            {
                var result =DataAccessLayer.tollzones.FirstOrDefault(x => x.IsValidFeeZone(date[0]));
                fee = fee + (result != null ? result.Fee : 0);
            }
            else
            {
                tempFee = new decimal[date.Count];
                for (int i = 0; i < date.Count; i++)
                {
                    var result = DataAccessLayer.tollzones.FirstOrDefault(x => x.IsValidFeeZone(date[i]));
                    tempFee[i] = (result != null ? result.Fee : 0);
                }
                //Add highest of the fees within 60 minutes with the existing fee
                fee = fee + tempFee.Max();
            }
        }

        return (fee >= MAXIMUM_FEE_PERDAY? MAXIMUM_FEE_PERDAY : fee);
    }

    private List<List<DateTime>> GetListByTime(List<DateTime> dateList)
    {
                var endLists = new List<List<DateTime>>();
                var innerList = new List<DateTime>();
                DateTime partialListStart = dateList[0];
                for (int i = 0; i < dateList.Count; i++)
                {
                    if ((dateList[i] - partialListStart).TotalMinutes <= 60)
                    {
                        innerList.Add(dateList[i]);
                    }
                    else
                    {
                        endLists.Add(innerList);
                        partialListStart = dateList[i];
                        innerList = new List<DateTime>() { dateList[i] };
                    }
                }
                endLists.Add(innerList);
                return endLists;
    }

    private List<DateTime> GetTaxExemptByYear(DateTime dateList)
    {
        return DataAccessLayer.AllTaxExemptDate.Where(x => x.Year == dateList.Year).ToList();
    }

}