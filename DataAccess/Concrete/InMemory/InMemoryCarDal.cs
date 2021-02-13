using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id = 1,ColorId = 2,BrandId = 3,DailyPrice = 350,Description = "Benzinli 1.6"},
                new Car{Id = 2,ColorId = 3,BrandId = 3,DailyPrice = 300,Description = "Benzinli 1.6"},
                new Car{Id = 3,ColorId = 3,BrandId = 1,DailyPrice = 325,Description = "Dizel 1.6"},
                new Car{Id = 4,ColorId = 5,BrandId = 1,DailyPrice = 400,Description = "Dizel 1.6"},
                new Car{Id = 5,ColorId = 1,BrandId = 2,DailyPrice = 450,Description = "Dizel 1.6"}
            };
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(Car car)
        {
            return _car.Where(c => c.Id == car.Id).ToList();
        }

        public void Add(Car car)
        {
            _car.Add(car);

        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.Id;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

            Console.WriteLine(carToUpdate.Id + " updated succesfully");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
            Console.WriteLine(carToDelete.Id + " deleted succesfully");

        }

       
    }
}
