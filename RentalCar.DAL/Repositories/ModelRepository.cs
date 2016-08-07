using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DAL.Repositories
{
    public class ModelRepository
    {
       
        public static List<tblModel> GetModelTypesByBrand(int brandId)
        {
            try
            {
                using (var context = new Rental_CarEntities1())
                {
                    return context.tblModels.Where(m => m.BrandId == brandId).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}
