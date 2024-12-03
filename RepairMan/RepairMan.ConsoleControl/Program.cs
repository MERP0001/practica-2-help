using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairMan.ConsoleControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new RepairManContextFactory();
            var context = factory.CreateDbContext(null);

            var repo = new SampleDataRepo(context);

            var workshop = context.Workshops.FirstOrDefault(x => x.Name != "");
            context.Add(new Offer()
            {
                Description = "Compra un gatito por 500 peso.",
                Keywords = "Gato",
                AvailableFrom = DateTime.Now.AddDays(-1),
                AvailableUntil = DateTime.Now.AddDays(50),
                WorkshopId = workshop.WorkshopId,
                Price = 500
            });

            context.SaveChanges();
            Console.Read();
        }
    }
}
