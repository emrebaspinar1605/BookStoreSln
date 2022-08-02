using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Models;

namespace WebAPI.BookOperations.GetBooks
{
  public class GetBooksQuery
  {
    private readonly BookStoreDbContext _context;
    
    public GetBooksQuery(BookStoreDbContext context)
    {
      _context = context;
    }
    public List<BooksViewModel> Handle()
    {
      var bookList = _context.Books.OrderBy(i => i.Id).ToList<Book>();
      List<BooksViewModel> vm = new List<BooksViewModel>();
      foreach (var book in bookList)
      {
        vm.Add(new BooksViewModel(){
          Name =book.Name,
          Genre = ((GenreEnum)book.GenreId).ToString(),
          PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
          PageCount = book.PageCount
        });
      }
      return vm;
    }
  }
  public class BooksViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
  }
}