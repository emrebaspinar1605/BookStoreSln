using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.GenreOperations.Queries.GetGenres
{
  public class GetGenresQuery
  {
    public readonly BookStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<GenresViewModel> Handle()
    {
      var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
      List<GenresViewModel> list = _mapper.Map<List<GenresViewModel>>(genres);
      return list;
    }

  }
  public class GenresViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}