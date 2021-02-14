using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ID\tBrandId\tGünlük Kirası\tAçıklama\n");
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine("Araç Detay: "+carDetail.CarName + "\t"+ " Marka: "+ carDetail.BrandName + "\t"+ "Renk: "+ carDetail.ColorName+ "\t"+ "Günlük Ücret: "+ carDetail.DailyPrice);
            }

        }
    }
}
