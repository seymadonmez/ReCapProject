using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        IColorService _colorService;


        public CarManager(ICarDal carDal, IBrandService brandService, IColorService colorService)
        {
            _carDal = carDal;
            _brandService = brandService;
            _colorService = colorService;
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfColorExists(car.ColorId), CheckIfBrandExists(car.BrandId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal max, decimal min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >=min && c.DailyPrice <=max));
        }

        public IDataResult<List<Car>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetAllByModelYear(int year)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear==year));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [SecuredOperation("car.update,admin,editor")]
        public IResult Update(Car car)
        { 
            if (car.Name.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarNameInvalid);
        }

        private IResult CheckIfBrandExists(int brandId)
        {
            var result = _brandService.GetById(brandId);
            if (result == null)
            {
                return  new ErrorResult(Messages.InvalidBrandId);
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorExists(int colorId)
        {
            var result = _colorService.GetByColorId(colorId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.InvalidColorId);
            }
            return new SuccessResult();
        }

    }
}
