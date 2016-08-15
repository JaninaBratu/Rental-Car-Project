using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentalCar.WindowsForm.Util
{
    public class CarAction
    {
        public static int ValidateRegistrationNumber(int registrationNumber)
        {
            string registrationNumberStringValue = registrationNumber.ToString();
            //is character
            if (Regex.IsMatch(registrationNumberStringValue, @"^[a-zA-Z]+$") && (!Regex.IsMatch(registrationNumberStringValue, @"^\d$")))
            {
                return -1;
            }
            //is number
            else if (!Regex.IsMatch(registrationNumberStringValue, @"^[a-zA-Z]+$") && (Regex.IsMatch(registrationNumberStringValue, @"^\d+$")))
            {
                int size = registrationNumberStringValue.Length;
                if (size == 7)
                {
                    return 1;
                }
                else if(size < 7)
                {
                    // the size of the registrationNumber is less than the accepted one.
                    return -2;
                }
                else 
                {
                    //the size of the registrationNumber is greater than the accepted one.
                    return -3;
                }
            }
            //is special character
            else
            {
                return -4;
            }
        }

        //public void SetMessageLabel(int validationValue, )
        //{
        //    switch(validationValue)
        //    {
        //        case -1:

        //            break;
        //        case -2:

        //            break;
        //        case -3:

        //            break;
        //        case -4:

        //            break;
        //    }
        //}
    }
}
