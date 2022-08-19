using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.AuthorOperations.Commands.DeleteAuthor
{
  public class DeleteAuthorQuery
  {
    public int AuthorId { get; set; }
    private readonly BookStoreDbContext _context;
    public DeleteAuthorQuery(BookStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
      var book = _context.Books.Where(x => x.AuthorId == AuthorId).Any();
      if (author is null)
      {
        throw new InvalidOperationException("Silinecek Yazar Bulunamadı");
      }
      if (book)
      {
        throw new InvalidOperationException("Yazarın kitabı hala yayında");
      }
      _context.Authors.Remove(author);
      _context.SaveChanges();
    }
  }
}