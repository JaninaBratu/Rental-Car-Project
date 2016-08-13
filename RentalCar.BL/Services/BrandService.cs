﻿using RentalCar.DAL;
using RentalCar.DAL.Repositories;
using RentalCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.WindowsForm.Services
{
    public class BrandService
    {
        public static List<tblBrand> GetBrandTypes()
        {
            return BrandRepository.GetBrandTypes();
        }
    }
}
