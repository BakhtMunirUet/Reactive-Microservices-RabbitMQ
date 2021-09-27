using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlateformServices.Model;
using System;
using System.Linq;

namespace PlateformServices.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Plateforms.Any())
            {
                Console.WriteLine("--> Seeding Data....");

                context.Plateforms.AddRange(
                        new Plateform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                        new Plateform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                        new Plateform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
