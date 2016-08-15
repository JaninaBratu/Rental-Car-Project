
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace RentalCar.DAL.Repositories
{
    public class CarRepository
    {
        public static List<tblCar> GetListCarsByModel(int modelId)
        {
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    return context.tblCars.Where(c => c.ModelId == modelId).Where(c => c.isRent == false).Include("tblLocation").ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static tblCar GetCarById(int carId)
        {
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    return context.tblCars.Where(c => c.CarId == carId).Include("tblModel").FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public static List<tblCar> OrderAscByRegistrNr(List<tblCar> listOfCars)
        {
            IEnumerable<tblCar> query = listOfCars.OrderBy(car => car.RegistrationNumber);
            return query.ToList();
        }

        public static List<tblCar> GetRegistrationNumber(int registrationNumber)
        {
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    return context.tblCars.Where(c => c.RegistrationNumber == registrationNumber).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static int AddCar(int registrationNumber, int location, int brand, int model)
        {

            using (var context = new Rental_CarEntities1())
            {
                if (GetRegistrationNumber(registrationNumber).Count == 0)
                {
                    tblCar car = new tblCar();
                    car.CarId = context.tblCars.Max( c=> c.CarId) + 1;
                    car.RegistrationNumber = registrationNumber;
                    car.LocationId = location;
                    car.ModelId = model;
                    context.tblCars.Add(car);
                    context.SaveChanges();
                    return car.CarId;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static List<tblCar> GetFilteredList(int limit, double offset)
        {
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    //the Skip method is the offset
                    //the Take methos is the limit 

                    return context.tblCars.Include("tblLocation").OrderBy(c => c.CarId).Skip(Convert.ToInt32(offset)).Take(limit).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static int GetTotalNrOfCars()
        {
            using (var context = new Rental_CarEntities1())
            {
                return context.tblCars.Count();
            }
        }

        public static int CheckRegistrationNumber(int registrationNumber)
        {
            tblCar car = new tblCar();
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    car = context.tblCars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
                    if (car == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return car.CarId;
                    }
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static bool CheckBrandAndModel(int brand, int model)
        {
            using (var context = new Rental_CarEntities1())
            {
                try
                {
                    var newContext = context.tblCars.Include("tblModel.BrandId").ToList();
                    var filteredList = newContext.Where(c => c.tblModel.BrandId == brand && c.ModelId == model);
                    if (filteredList.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                        //FirstOrDefault(c=>c.tblModel.BrandId == brand);

                }
                catch (Exception)
                {

                    throw;
                }
            }

                return false;
        }
    }
}
