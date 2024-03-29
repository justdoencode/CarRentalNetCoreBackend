﻿using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<Car> GetById(int id);
        IDataResult<CarDetailDto> GetCarDetailById(int id);
        IDataResult<List<CarDetailDto>> GetCarDatails();
        IResult TransactionOperation(Car car);
        IDataResult<List<CarDetailDto>> GetCarsByBrandAndColor(int brandId, int colorId);
    }
}
