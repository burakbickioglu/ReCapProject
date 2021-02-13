using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager= new CarManager(new InMemoryCarDal());
            
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.BrandId + " " + c.ColorId + " " + c.DailyPrice + " " + c.Description);
            }

            
                
        }
    }
}
