using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarIsAvailable(rental));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult();
        }
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return  new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Rental> GetAllById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==rentalId));
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByUser(int userId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarDetailsById(r=>r.UserId==userId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCar(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarDetailsById(r => r.CarId == carId));
        }

        private IResult CheckCarIsAvailable(Rental rental)
        {
            var result = _rentalDal.Get(r => (r.CarId == rental.CarId && r.ReturnDate == null)
                                             || (r.RentDate >= rental.RentDate && r.ReturnDate >= rental.RentDate));

            if (result != null)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }

            return new SuccessResult();
        }

        public IResult CheckCarIsRented(int carId)
        {
            var result = _rentalDal.GetCarDetailsById(r => r.CarId == carId && r.ReturnDate == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }

            return new SuccessResult();
        }
    }
}
