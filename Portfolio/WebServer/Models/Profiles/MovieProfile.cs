using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<titleBasic, MovieModel>()
                .ForMember(dst => dst.Plot, opt => opt.MapFrom(src => src.Poster.Plot))
                .ForMember(dst => dst.Poster, opt => opt.MapFrom(src => src.Poster.Poster));
            CreateMap<titleBasic, MovieListModel>().ForMember(dst => dst.Poster, opt => opt.MapFrom(src => src.Poster.Poster));

        }
        

    }
}
