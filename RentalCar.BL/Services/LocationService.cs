using RentalCar.DAL.Repositories;
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BL.Services
{
    public class LocationService
    {
        public static List<tblLocation> GetAllLocations()
        {
            return LocationRepository.GetAllLocations();
        }
    }
}
