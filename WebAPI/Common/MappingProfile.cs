using AutoMapper;
using WebAPI.BookOperations.CreateBook;
using WebAPI.BookOperations.GetById;
using WebAPI.BookOperations.UpdateBook;
using WebAPI.BookOperations.GetBooks;
using WebAPI.Models;

namespace WebAPI.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateBookModel,Book>();
      CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
      CreateMap<Book,BookByIdVM>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
    }
  }
}