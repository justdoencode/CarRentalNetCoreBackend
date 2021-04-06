using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDatabaseContext>, ICarDal
    {
        public CarDetailDto GetCarDetailById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context = new ReCapProjectDatabaseContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join images in context.CarImages
                             on car.Id equals images.CarId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 Description = car.Description,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 CarImage=images.ImagePath
                             };
                return result.SingleOrDefault(filter);
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDatabaseContext context=new ReCapProjectDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id=c.Id,
                                 Description = c.Description,
                                 ColorName = color.Name,
                                 BrandName = b.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear=c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
