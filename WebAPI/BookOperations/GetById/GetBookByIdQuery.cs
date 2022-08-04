using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Models;

namespace WebAPI.BookOperations.GetById
{
  public class GetBookByIdQuery
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetBookByIdQuery(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public BookByIdVM Handle(int id)
    {
      var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
      if (book is null)
        throw new InvalidOperationException("Kitap Bulunamadı");
      BookByIdVM vm = _mapper.Map<BookByIdVM>(book);
      
      return vm;
    }
  }
  public class BookByIdVM
  {
    public string Name { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
  }

}