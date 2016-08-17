using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static RentalCar.BL.Util.ValidationTypes;

namespace RentalCar.WindowsForm.Util
{
    public class CarAction
    {
        public static int ValidateRegistrationNumber(int registrationNumber)
        {
            string registrationNumberStringValue = registrationNumber.ToString();

            //is number
            if (Regex.IsMatch(registrationNumberStringValue, @"^\d+$"))
            {
                int size = registrationNumberStringValue.Length;
                if (size == 7)
                {
                    return 1;
                }
                else if (size < 7)
                {
                    // the size of the registrationNumber is less than the accepted one.
                    return -1;
                }
                else
                {
                    //the size of the registrationNumber is greater than the accepted one.
                    return -2;
                }
            }
            else
            {
                return -3;
            }
        }

        

        public static Dictionary<Enum, bool> ValidateDataForRezervation(string name, string surname, float price, DateTime dateFrom, DateTime dateTill, tblCar car)
        {
            Dictionary<Enum, bool> resultListOfValidation = new Dictionary<Enum, bool>();

            resultListOfValidation.Add(ValidTypes.Name, true);
            resultListOfValidation.Add(ValidTypes.Surname, true);
            resultListOfValidation.Add(ValidTypes.Price, true);
            resultListOfValidation.Add(ValidTypes.DateFrom, true);
            resultListOfValidation.Add(ValidTypes.DateTill, true);
            resultListOfValidation.Add(ValidTypes.Car, true);

            if (name == "")
            {
                resultListOfValidation[ValidTypes.Name] = false;
            }
            if (surname == "")
            {
                resultListOfValidation[ValidTypes.Surname] = false;
            }
            if(price == 0.0)
            {
                resultListOfValidation[ValidTypes.Price] = false;
            }
            if(dateFrom == null)
            {
                resultListOfValidation[ValidTypes.DateFrom] = false;
            }
            if(dateTill == null)
            {
                resultListOfValidation[ValidTypes.DateTill] = false;
            }
            if(car == null)
            {
                resultListOfValidation[ValidTypes.Car] = false;
            }
            
            return resultListOfValidation;
        }
    }
}
