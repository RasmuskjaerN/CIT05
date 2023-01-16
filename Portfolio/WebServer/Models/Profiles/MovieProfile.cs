using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<titleBasic, MovieModel>();
            CreateMap<titleBasic, MovieListModel>();
            CreateMap<omdbData, movieomdbmodel>();
            CreateMap<omdbData, MoviePosterListModel>();
            CreateMap<titleRating, movietitleratingmodel>();
            CreateMap<titleRating,MovieRatingListModel>();
            CreateMap<titleAka, movietitleakasmodel>();
            CreateMap<nameBasic, movieactormodel>();
            
            /*CreateMap<userBookmark, movieuserbookmarkmodel>()
                .ForMember(dst => dst.Uid, opt => opt.MapFrom(src => src.Uid))
                .ForMember(dst => dst.userbookmarkNote, opt => opt.MapFrom(src => src.Note));
            CreateMap<omdbData, movieomdbmodel>()
                .ForMember(dst => dst.Plot, opt => opt.MapFrom(src => src.Plot))
                .ForMember(dst => dst.Poster, opt => opt.MapFrom(src => src.Poster));
            CreateMap<titleBasic, MovieListModel>();
            CreateMap<titleAka, movietitleakasmodel>()
                .ForMember(dst => dst.Ordering, opt => opt.MapFrom(src => src.Ordering))
                .ForMember(dst => dst.Region, opt => opt.MapFrom(src => src.Region))
                .ForMember(dst => dst.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
            CreateMap<titleRating, movietitleratingmodel>()
                .ForMember(dst => dst.NumVotes, opt => opt.MapFrom(src => src.NumVotes))
                .ForMember(dst => dst.AverageRating, opt => opt.MapFrom(src => src.AverageRating));
            CreateMap<titleRating, MovieRatingListModel>()
                .ForMember(dst => dst.NumVotes, opt => opt.MapFrom(src => src.NumVotes))
                .ForMember(dst => dst.AverageRating, opt => opt.MapFrom(src => src.AverageRating));*/
        }
        

    }
}
