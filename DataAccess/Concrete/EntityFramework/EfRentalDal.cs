using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDatabaseContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDatabaseContext context=new ReCapProjectDatabaseContext())
            {
                var result = from rental in filter == null
                             ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new CarRentalDetailDto
                             {
                                 RentalId = rental.Id,
                                 CustomerName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CustomerCompanyName = customer.CompanyName,
                                 CarName = car.Description,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
