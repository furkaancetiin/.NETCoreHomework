using System;
using WebApi.DBoperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                      new Author { FirstName = "Eric", LastName = "Ries", DateOfBirth = new DateTime(1978, 09, 22) },
                      new Author { FirstName = "Charlotte Perkins", LastName = "Gilman", DateOfBirth = new DateTime(1860, 07, 03) },
                      new Author { FirstName = "Frank", LastName = "Herbert", DateOfBirth = new DateTime(1920, 10, 08) }
                      );
        }
    }
}