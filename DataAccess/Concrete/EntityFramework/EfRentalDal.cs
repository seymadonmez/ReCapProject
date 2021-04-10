using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public RentalDetailDto GetRentalDetails(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals.Where(r => r.RentalId == id)
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             
                             select new RentalDetailDto()
                             {
                                 Id = r.RentalId,
                                 CarId = c.Id,
                                 ModelYear = c.ModelYear,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CarName = c.Name,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate                           
                             };
                return result.SingleOrDefault();
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
               var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             
                             select new RentalDetailDto()
                             {
                                 Id = r.RentalId,
                                 CarId = c.Id,
                                 ModelYear = c.ModelYear,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CarName = c.Name,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate                           
                             };
                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetCarDetailsById(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals

                             join c in context.Cars on r.CarId equals c.Id
                    join cu in context.Customers on r.CustomerId equals cu.CustomerId
                    join u in context.Users on cu.UserId equals u.UserId
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId

                    select new RentalDetailDto()
                    {
                        Id = r.RentalId,
                        CarId = c.Id,
                        ModelYear = c.ModelYear,
                        UserName = u.FirstName + " " + u.LastName,
                        CarName = c.Name,
                        BrandName = b.BrandName,
                        ColorName = cl.ColorName,
                        CompanyName = cu.CompanyName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
