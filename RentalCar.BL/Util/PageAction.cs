using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.WindowsForm.Util
{
    public class PageAction
    {
        public static double GetNrOfPages(int nrOfCars, int pageLimit)
        {
            //you must have a double result; not an interger one
            var pageNumber = nrOfCars / pageLimit;
            double doubleVal = System.Convert.ToDouble(pageNumber);
            return Math.Round(doubleVal, 1, MidpointRounding.AwayFromZero);
        }

        //pageLimit = items per page
        public static double CalculateOffset(int currentPage, int pageLimit)
        {
            double tempResult = System.Convert.ToDouble(currentPage -1);
            double finalResult = System.Convert.ToDouble(tempResult * pageLimit);
            
            return finalResult;
        }

    }
}
