using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorQuery
  {
    public int AuthorId { get; set;}
    public UpdateAuthorModel Model{ get; set; }
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;


    public UpdateAuthorQuery(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
      if (author is null)
      {
        throw new InvalidOperationException("Yazar Bulunamadı.");
      }
      if (_context.Authors.Any(a => a.Name.ToLower() == Model.Name.ToLower() && a.SurName.ToLower() == Model.SurName.ToLower()))
      {
        throw new InvalidOperationException("Bilgiler Kayıtlı Bir Yazara Ait.");
      }
      _mapper.Map(Model,author);
      _context.SaveChanges();
    }
  }

  public class UpdateAuthorModel
  {

    public string Name { get; set; }
    public string SurName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}