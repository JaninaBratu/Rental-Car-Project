using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DAL.Repositories
{
    public class LocationRepository
    {
        public static List<tblLocation> GetAllLocations()
        {
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    return context.tblLocations.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
