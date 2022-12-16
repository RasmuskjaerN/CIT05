using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<titleBasic, MovieModel>()
                /*.ForMember(dst => dst.Plot, opt => opt.MapFrom(src => src.OmdbData.Plot))
                .ForMember(dst => dst.Poster, opt => opt.MapFrom(src => src.OmdbData.Poster))
                .ForMember(dst => dst.AverageRating, opt => opt.MapFrom(src => src.TitleRating.AverageRating))
                .ForMember(dst => dst.NumVotes, opt => opt.MapFrom(src => src.TitleRating.NumVotes))
                .ForMember(dst => dst.Region, opt => opt.MapFrom(src => src.TitleAkas.Region))
                .ForMember(dst => dst.Language, opt => opt.MapFrom(src => src.TitleAkas.Language))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.TitleAkas.Type))
                .ForMember(dst => dst.Attribute, opt => opt.MapFrom(src => src.TitleAkas.Attribute))
                .ForMember(dst => dst.Ordering, opt => opt.MapFrom(src => src.TitleAkas.Ordering))*/;
            CreateMap<titleBasic, MovieListModel>()/*.ForMember(dst => dst.Poster, opt => opt.MapFrom(src => src.OmdbData.Poster))*/;

        }
        

    }
}
