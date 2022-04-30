using System;
using WebApi.DBoperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup{
    public static class Books{
        public static void AddBooks(this BookStoreDbContext context){
            context.Books.AddRange(
                    new Book { AuthorId=1,GenreId = 1, Title = "Lean Startup", PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
                    new Book { AuthorId=2,GenreId = 2, Title = "Herland", PageCount = 250, PublishDate = new DateTime(2010, 05, 23) },
                    new Book { AuthorId=3,GenreId = 2, Title = "Dune", PageCount = 540, PublishDate = new DateTime(2001, 12, 21) }
                );
        }
    }
}