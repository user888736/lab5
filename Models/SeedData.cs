using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace lab5.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new lab5Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<lab5Context>>()))
            {
                // Look for any movies.
                if (context.lab5Items.Any())
                {
                    return;   // DB has been seeded
                }

                context.lab5Items.AddRange(
                    new lab5Item
                    {
                        Name = "Szymon",
                        Surname = "Kwaśniewski",
                        EmployeeId = 12321,
                        EmployeeTask = "Utworzyć projekt",
                        IsComplete = true
                    },

                    new lab5Item
                    {
                        Name = "Maciej",
                        Surname = "Kowalski",
                        EmployeeId = 15451,
                        EmployeeTask = "Sprawdzić projekt",
                        IsComplete = false
                    },

                    new lab5Item
                    {
                        Name = "Adam",
                        Surname = "Nowak",
                        EmployeeId = 19861,
                        EmployeeTask = "Sprawdzić stan magazynu",
                        IsComplete = false
                    },

                    new lab5Item
                    {
                        Name = "Mateusz",
                        Surname = "markowiak",
                        EmployeeId = 11534,
                        EmployeeTask = "Odebrać dostawę",
                        IsComplete = true
                    }




                );
                context.SaveChanges();
            }
        }
    }
}
