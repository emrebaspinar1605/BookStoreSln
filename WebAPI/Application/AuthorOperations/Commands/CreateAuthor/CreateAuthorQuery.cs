using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorQuery
  {
    public CreateAuthorModel Model { get; set; }
    private readonly BookStoreDbContext _context;

    public CreateAuthorQuery(BookStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name && x.SurName == Model.SurName);
      if (author is not null)
      {
        throw new InvalidOperationException("Yazar Zaten Mevcut");
      }
      author = new Author();
      author.Name = Model.Name;
      author.SurName = Model.SurName;
      author.BirthDate = Model.BirthDate;
      
      _context.Authors.Add(author);
      _context.SaveChanges();
    }
  }

  public class CreateAuthorModel
  {
    public string Name { get; set; }
    public string SurName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}