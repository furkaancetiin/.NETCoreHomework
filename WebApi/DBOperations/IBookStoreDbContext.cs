using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBoperations{
    public interface IBookStoreDbContext{
        DbSet<Book> Books{get;set;}
        DbSet<Genre> Genres{get;set;}
        DbSet<Author> Authors{get;set;}

        int SaveChanges();
    }
}