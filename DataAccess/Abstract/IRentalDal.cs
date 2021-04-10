﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        RentalDetailDto GetRentalDetails(int id);
        List<RentalDetailDto> GetRentalDetails();
        List<RentalDetailDto> GetCarDetailsById(Expression<Func<RentalDetailDto, bool>> filter = null);
    }
}
