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
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car{Id = 6});

            //foreach (var car in carManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(car.Id+ "-"+car.Description);
            //}
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            //}



        }

        private static void CarGetAll(CarManager carManager)
        {
            carManager.Add(new Car { Id = 6, BrandId = 3, DailyPrice = 300, ColorId = 2, ModelYear = 2020, Description = "2.0 benzinli turbo" });
            carManager.Delete(new Car { Id = 6 });
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.BrandId + " " + c.ColorId + " " + c.DailyPrice + " " + c.Description);
            }
        }
    }
}
