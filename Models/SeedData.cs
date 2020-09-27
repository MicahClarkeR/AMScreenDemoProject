using AMScreenInterview.Data;
using AMScreenInterview.Models.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AMScreenInterview.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AMScreenContext(
                serviceProvider.GetRequiredService<DbContextOptions<AMScreenContext>>()))
            {
                if(context.Screen.Any())
                {
                    return; // Database has data.
                }
                else
                {
                    context.Screen.AddRange(
                        new Screen
                        {
                            Postcode = "A19 15VA"
                        },
                        new Screen
                        {
                            Postcode = "L14 6TA"
                        },
                        new Screen
                        {
                            Postcode = "P59 3NE"
                        },
                        new Screen
                        {
                            Postcode = "G1 91A"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
