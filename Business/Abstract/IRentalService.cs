using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IResult CheckReturnDate(int carId);
        IDataResult<List<CarRentalDetailDto>> GetCarRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
