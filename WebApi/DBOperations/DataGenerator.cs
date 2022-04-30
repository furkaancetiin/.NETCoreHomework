using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

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
                context.Authors.AddRange(
                    new Author { FirstName = "Eric", LastName = "Ries", DateOfBirth = new DateTime(1978, 09, 22) },
                    new Author { FirstName = "Charlotte Perkins", LastName = "Gilman", DateOfBirth = new DateTime(1860, 07, 03) },
                    new Author { FirstName = "Frank", LastName = "Herbert", DateOfBirth = new DateTime(1920, 10, 08) }
                    );



                context.Genres.AddRange(
                    new Genre { Name = "Personal Growth" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Romance" }

                );

                context.Books.AddRange(
                    new Book { AuthorId = 1, GenreId = 1, Title = "Lean Startup", PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
                    new Book { AuthorId = 2, GenreId = 2, Title = "Herland", PageCount = 250, PublishDate = new DateTime(2010, 05, 23) },
                    new Book { AuthorId = 3, GenreId = 2, Title = "Dune", PageCount = 540, PublishDate = new DateTime(2001, 12, 21) }
                );

                context.SaveChanges();
            }
        }
    }
}