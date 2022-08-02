using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Models;

namespace WebAPI.BookOperations.UpdateBook
{
  public class UpdateBookQuery
  {
    public UpdateBookModels Model{ get; set; }
    private readonly BookStoreDbContext _context;

    public UpdateBookQuery(BookStoreDbContext context)
    {
      _context = context;
    }

    public void Handle(int id)
    {
      var book = _context.Books.SingleOrDefault(x=> x.Id == id);
      if (book is null)
      {
        throw new InvalidOperationException("Böyle bir kitap bulunamadı");
      }
      book.Name = Model.Name != default ? Model.Name : book.Name;
      book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
      book.PageCount = Model.PageCount != default ? Model.PageCount : book.GenreId;
      book.PublishDate = Model.PublishDate.Date.ToString("dd/mm/yyyy") != default ? Model.PublishDate : book.PublishDate ;
      _context.SaveChanges();
    }
  }
  public class UpdateBookModels
  {
    public string Name { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
  }
}