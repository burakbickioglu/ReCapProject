using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result =
                rentalManager.Add(new Rental {CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 02, 01)});
            //var result=rentalManager.Add(new Rental {CarId = 1, CustomerId = 1, RentDate = new DateTime(2020, 01, 01),ReturnDate = null});
            Console.WriteLine(result.Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.Get(3);
            Console.WriteLine(result.Data.CompanyName);

            //var result = customerManager.GetAll();
            //foreach (var customer in result.Data)
            //{
            //    Console.WriteLine(customer.CustomerId + "-" + customer.UserId + "-" + customer.CompanyName);
            //}
            //var result=customerManager.Delete(new Customer{CustomerId = 2});

            //var result = customerManager.Add(new Customer { UserId = 3, CompanyName = "Onurque" });
            Console.WriteLine(result.Message);
        }

        private static void UserTest()
        {
            UserManager user = new UserManager(new EfUserDal());

            var result = user.GetAll();
            foreach (var res in result.Data)
            {
                Console.WriteLine(res.UserId + " - " + res.UserFirstName + " " + res.UserLastName);
            }
            //var result = user.Get(4);
            //Console.WriteLine(result.Data.UserId + "-" + result.Data.UserFirstName + "-" + result.Data.UserLastName);


            //var result= user.Add(new User
            //{
            //    UserFirstName = "Emrehan", UserLastName = "Aydın", UserPassword = "54321",UserEmail = "emrehanaydin@gmail.com"
            //});
            Console.WriteLine(result.Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Update(new Color {ColorId = 8, ColorName = "PURPLE"});
            Console.WriteLine(result.Message);

            var result2 = colorManager.Get(2);
            if (result2.Success)
            {
                Console.WriteLine(result2.Data.ColorId + "-" + result2.Data.ColorName);
            }

            Console.WriteLine(result.Message);

            var result3 = colorManager.GetAll();
            if (result3.Success)
            {
                foreach (var color in colorManager.GetAll().Data)
                {
                    Console.WriteLine(color.ColorId + "-" + color.ColorName);
                }
            }

            Console.WriteLine(result.Message);
        }



        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Update(new Brand { BrandId = 5, BrandName = "HYUNDAI" });
            Console.WriteLine(result.Message);


            var result2 = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
                }
            }

            Console.WriteLine(result2.Message);
        }

    }
}
