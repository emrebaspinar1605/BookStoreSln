using System;
using System.Linq;
using WebAPI.DbOperations;
using WebAPI.Models;

namespace WebAPI.BookOperations.DeleteBook
{
  public class DeleteBookQuery
  {
    private readonly BookStoreDbContext _context;

    public DeleteBookQuery(BookStoreDbContext context)
    {
      _context = context;
    }
    public void Handle(int id)
    {
      var book = _context.Books.SingleOrDefault(x=> x.Id == id);
      if (book is null)
        throw new InvalidOperationException("Böyle bir kitap bulunmamaktadır.");
      _context.Books.Remove(book);
      _context.SaveChanges();
    }
  }
}