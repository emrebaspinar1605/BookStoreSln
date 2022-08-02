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
  public class GetBookByIdQuery
  {
    private readonly BookStoreDbContext _context;
    
    public GetBookByIdQuery(BookStoreDbContext context)
    {
      _context = context;
    }
    public BooksViewModel Handle(int id)
    {
      var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
      
      BooksViewModel vm = new BooksViewModel();

      vm.Id = book.Id ;
      vm.Name = book.Name ;
      vm.Genre = ((GenreEnum)book.GenreId).ToString();
      vm.PublishDate = book.PublishDate.ToString("dd/mm/yyyy") ;
      vm.PageCount = book.PageCount ;

      return vm;
    }
  }

}