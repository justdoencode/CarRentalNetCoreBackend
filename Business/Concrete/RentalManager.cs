using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult("Ekleme başarısız");
            }
            _rentalDal.Add(rental);
            return new SuccessResult("Ekleme başarılı");
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);

            if (result.Count>0)
            {
                return new ErrorResult("Dönüş Tarihi Yok");
            }
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            foreach (var item in _rentalDal.GetAll())
            {
                Console.WriteLine(item.CustomerId);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
