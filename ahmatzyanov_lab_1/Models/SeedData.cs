using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ahmatzyanov_lab_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ahmatzyanov_lab_1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ahmatzyanov_lab_1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ahmatzyanov_lab_1Context>>()))
            {
                // Look for any movies.
                if (context.EngineOil.Any())
                {
                    return;   // DB has been seeded
                }

                context.EngineOil.AddRange(
                    new EngineOil
                    {
                        Title = "Castrol v1",
                        Structure = "Синтетика",
                        Volume = 4,
                        Price = 7.99M
                    },

                    new EngineOil
                    {
                        Title = "Castrol v2",
                        Structure = "Синтетика",
                        Volume = 4,
                        Price = 10.99M
                    },

                    new EngineOil
                    {
                        Title = "Total 2334",
                        Structure = "Синтетика",
                        Volume = 2,
                        Price = 4.99M
                    },

                    new EngineOil
                    {
                        Title = "Mobile 150000",
                        Structure = "Синтетика",
                        Volume = 10,
                        Price = 20.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
