using System;
using System.Linq;
using WebAPI.DbOperations;
using WebAPI.Models;

namespace WebAPI.BookOperations.CreateBook
{
  public class CreateBookQuery
  {
    public CreateBookModel Model {get; set;}
    private readonly BookStoreDbContext _context;

    public CreateBookQuery(BookStoreDbContext dbContext)
    {
      _context = dbContext;
    }
    public void Handle()
    {
      var book = _context.Books.SingleOrDefault(x=> x.Name == Model.Name);
      if (book is not null)
        throw new InvalidOperationException("Kitap Zaten Mevcut");
      book = new Book();
      book.Name = Model.Name;
      book.PublishDate = Model.PublishDate;
      book.GenreId = Model.GenreID;
      book.PageCount = Model.PageCount;

      _context.Books.Add(book);
      _context.SaveChanges();
    }
    
  }
  public class CreateBookModel
    {
      public string Name {get; set;}
      public int GenreID {get; set;}
      public int PageCount {get; set;}
      public DateTime PublishDate {get; set;}

    }
}