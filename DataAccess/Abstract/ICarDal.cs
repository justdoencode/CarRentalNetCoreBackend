﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        CarDetailDto GetCarDetailById(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetCarDetailByIdList(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}
