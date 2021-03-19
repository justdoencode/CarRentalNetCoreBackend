using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("****************Arabalar**************");
            CarCRUD();
            //Console.WriteLine("****************Renkler**************");
            //ColorCRUD();
            //Console.WriteLine("****************Markalar**************");
            //BrandCRUD();
            //Console.WriteLine("****************Müşteriler**************");
            //CustomerCRUD();
            //Console.WriteLine("****************Kullanıcılar**************");
            //UserCRUD();
            //Console.WriteLine("****************Rental**************");
            //RentalCRUD();

            Console.WriteLine("İşlem Gerçekleşti");

            
        }

        private static void RentalCRUD()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental { Id = 2, CarId = 1, CustomerId = 1, RentDate = DateTime.Now});
            //rentalManager.GetAll();
        }

        private static void UserCRUD()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //userManager.Add(new User { Id = 3, FirstName = "Cansu", LastName = "Tuncer", Email = "tuncer@gmail.com", Password = "546" });
        }

        private static void CustomerCRUD()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //customerManager.Add(new Customer { Id = 3, UserId = 2, CompanyName = "İlhan AŞ" });

            customerManager.GetAll();

        }

        private static void BrandCRUD()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Add(new Brand { Id = 2, Name = "Ford" });

            //Console.WriteLine(brandManager.GetById(1).Name);

            //brandManager.Delete(new Brand { Id = 2, Name = "Ford" });

            //brandManager.Update(new Brand { Id = 2, Name = "Mercedes" });

            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}

        }

        private static void ColorCRUD()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Console.WriteLine(colorManager.GetById(2).Name);

            //colorManager.Delete(new Color { Id = 1, Name = "Kırmızı" });

            //colorManager.Update(new Color { Id = 2, Name = "Siyah" });

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}

        }

        private static void CarCRUD()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.GetCarsByBrandId(1);
            
            
            //carManager.GetAll();

            //foreach (var car in carManager.GetCarDatails())
            //{
            //    Console.WriteLine(car.BrandName + "//" + car.Description + "//" + car.ColorName + "//" + car.DailyPrice);
            //}
            
            
            //Console.WriteLine(carManager.GetById(2).Description);

            //carManager.Delete(new Car { Id = 1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=50000,Description="Yaris"});

            //carManager.Update(new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 50000, Description = "Yaris", ModelYear = 2012 });

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //carManager.Add(new Car { Id=2,BrandId = 2, ColorId = 1, DailyPrice = 200, Description = "Auris", ModelYear = 2010 });


        }
    }
}
