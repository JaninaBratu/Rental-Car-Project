using RentalCar.DAL;
using RentalCar.DAL.Repositories;
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BL.Services
{
    public class CarService
    {
        public static List<tblCar> GetListCarsByModel(int modelId)
        {
            return CarRepository.GetListCarsByModel(modelId);
        }

        public static tblCar GetCarById( int carId)
        {
            return CarRepository.GetCarById(carId);
        }

        public static List<tblCar> OrderAscByRegistrNr(List<tblCar> listOfCars)
        {
            return CarRepository.OrderAscByRegistrNr(listOfCars);
        }

        public static int AddCar(int registrationNumber, int location, int brand, int model)
        {
            return CarRepository.AddCar(registrationNumber, location, brand, model);
        }

        public static int GetTotalNrOfCars(List<tblCar> listOfCars)
        {
            return CarRepository.GetTotalNrOfCars(listOfCars);
        }

        public static List<tblCar> GetFilteredList(int limit, double offset)
        {
            return CarRepository.GetFilteredList(limit, offset);
        }
    }
}
