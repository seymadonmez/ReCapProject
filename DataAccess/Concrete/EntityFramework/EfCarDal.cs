using System;
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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto,bool>> filter=null)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    select new CarDetailDto()
                    {
                        CarId =c.Id ,CarName = c.Name, BrandName = b.BrandName, BrandId = b.BrandId, ColorName = cl.ColorName,ColorId = cl.ColorId,DailyPrice = c.DailyPrice, ModelYear=c.ModelYear, Description=c.Description,
                        ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
