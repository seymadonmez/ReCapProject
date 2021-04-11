using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager:ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard creditCard)
        {
            IResult result = BusinessRules.Run(CheckCreditCardExists(creditCard));

            if (result != null)
            {
                return result;
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        [SecuredOperation("admin,user")]
        [CacheAspect]
        public IDataResult<List<CreditCard>> GetByCustomer(int id)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == id));
        }
        public IResult CheckCreditCardExists(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(c => c.NameOnTheCard == creditCard.NameOnTheCard
                                                 && c.CardNumber == creditCard.CardNumber
                                                 && c.CVV == creditCard.CVV
                                                 && c.ExpirationDate == creditCard.ExpirationDate);

            if (result != null)
            {
                return new ErrorResult(Messages.CreditCardExists);
            }

            return new SuccessResult();
        }

    }
}
