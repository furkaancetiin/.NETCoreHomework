using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBoperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
            new Book { GenreId = 1, Title = "Lean Startup", PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
            new Book { GenreId = 2, Title = "Herland", PageCount = 250, PublishDate = new DateTime(2010, 05, 23) },
            new Book { GenreId = 2, Title = "Dune", PageCount = 540, PublishDate = new DateTime(2001, 12, 21) }
                );

                context.SaveChanges();
            }
        }
    }
}