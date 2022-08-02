using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Models;

namespace WebAPI.DbOperations
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
          new Book
            {
               // Id = 1,
                Name = "Sherlock Holmes",
                GenreId = 1, //polisiye
                PageCount = 180,
                PublishDate = new DateTime(1850,11,28)
            },
            new Book
            {
                // Id = 2,
                Name = "Ateşten Gömlek",
                GenreId = 2, //kült
                PageCount = 150,
                PublishDate = new DateTime(1960,05,07)
            },
            new Book
            {
                // Id = 3,
                Name = "Beyaz Gemi",
                GenreId = 2, //kült
                PageCount = 130,
                PublishDate = new DateTime(1987,01,15)
            }
        );
        context.SaveChanges();
      }
    }
  }
}