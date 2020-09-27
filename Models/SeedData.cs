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
                    Console.WriteLine("DATABASE HAS DATA.");
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


                    context.Engineer.AddRange(
                        new Engineer
                        {
                            Name = "John Smith"
                        },
                        new Engineer
                        {
                            Name = "Adam Williams"
                        }
                    );
                    context.SaveChanges();

                    context.Issue.AddRange(
                        new Issue
                        {
                            Description = "Dead pixels"
                        },
                        new Issue
                        {
                            Description = "Melted cpu"
                        },
                        new Issue
                        {
                            Description = "Cracked screen"
                        }
                    );
                    context.SaveChanges();

                    context.ScreenIssues.AddRange(
                        new ScreenIssues
                        {
                            IssueId = 1,
                            ScreenId = 1,
                            DateReported = new DateTime(2020, 10, 20)
                        },
                        new ScreenIssues
                        {
                            IssueId = 3,
                            ScreenId = 2,
                            DateReported = new DateTime(2020, 7, 1)
                        },
                        new ScreenIssues
                        {
                            IssueId = 3,
                            ScreenId = 3,
                            DateReported = new DateTime(2020, 5, 13)
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
