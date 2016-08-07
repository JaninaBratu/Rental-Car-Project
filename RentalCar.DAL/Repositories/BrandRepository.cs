using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DAL.Repositories
{
    public class BrandRepository
    {

        public static List<tblBrand> GetBrandTypes()
        {
            try
            {
                using (var context = new Rental_CarEntities1())
                {
                    return context.tblBrands.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
