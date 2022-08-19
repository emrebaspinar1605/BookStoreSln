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

namespace WebAPI.Application.BookOperations.Commands.GetById
{
  public class GetBookByIdQuery
  {
    public int BookId { get; set;}
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetBookByIdQuery(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public BookByIdVM Handle()
    {
      var book = _context.Books.Include(g => g.Genre ).Include(x => x.Author).Where(book => book.Id == BookId).SingleOrDefault();
      if (book is null)
        throw new InvalidOperationException("Kitap Bulunamadı");
      BookByIdVM vm = _mapper.Map<BookByIdVM>(book);
      
      return vm;
    }
  }
  public class BookByIdVM
  {
    public string Author { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
  }

}