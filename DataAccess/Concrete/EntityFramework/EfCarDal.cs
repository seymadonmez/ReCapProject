﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    select new CarDetailDto()
                    {
                        CarName = c.Name, BrandName = b.BrandName, ColorName = cl.ColorName,DailyPrice = c.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
