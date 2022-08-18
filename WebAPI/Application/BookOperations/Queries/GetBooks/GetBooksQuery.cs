using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.BookOperations.Commands.GetBooks
{
  public class GetBooksQuery
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<BooksViewModel> Handle()
    {
      var bookList = _context.Books.Include(b => b.Genre).OrderBy(i => i.Id).ToList<Book>();
      List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
     
      return vm;
    }
  }
  public class BooksViewModel
  {
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
  }
}