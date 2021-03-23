using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage,IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckMaxCarImage(carImage.CarId));
            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = CarImageFileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result==null)
            {
                AddDefaultImage(id,result);
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage,IFormFile file)
        {
            carImage.ImagePath = CarImageFileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        private IResult CheckMaxCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>4)
            {
                return new ErrorResult(Messages.MaxCarImageError);
            }
            return new SuccessResult();
        }

        private IResult AddDefaultImage(int carId,List<CarImage>result)
        {
            var newResult = new CarImage
            {
                CarId = carId,
                ImagePath = Environment.CurrentDirectory + @"\wwwroot\Images\DefaultCar.jpeg",
                Date = DateTime.Now
            };
            result.Add(newResult);
            return new SuccessResult();
        }
        
    }
}
