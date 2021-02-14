using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            
            return _carDal.GetAll();
        }

        public List<Car> GetAllByDailyPrice(decimal max, decimal min)
        {
            return _carDal.GetAll(c => c.DailyPrice >=min && c.DailyPrice <=max);
        }

        public List<Car> GetAllById(int id)
        {
            return _carDal.GetAll(c => c.Id == id);
        }

        public List<Car> GetAllByModelYear(int year)
        {
            return _carDal.GetAll(c => c.ModelYear==year);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            try
            {
                if (car.Description.Length >= 2 && car.DailyPrice > 0)
                {
                    _carDal.Update(car);
                    Console.WriteLine("Araba başarıyla güncellendi!");
                }
                else
                {
                    throw new Exception("Güncellemek istedğiniz değerin günlük ücreti 0'dan büyük olmalıdır!");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
            
        }
    }
}
