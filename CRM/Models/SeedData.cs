using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CRM.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CRMContext(
                serviceProvider.GetRequiredService<DbContextOptions<CRMContext>>()))
            {
                // Look for any movies.
                if (context.Usuario.Any())
                {
                    return;   // DB has been seeded
                }

                context.Usuario.AddRange(
                     new Usuario
                     {

                         Username = "admin",
                         Password ="123",
                         Tipo = "admin"
                  
                     }
   
                
                );
                context.SaveChanges();
            }
        }
    }
}