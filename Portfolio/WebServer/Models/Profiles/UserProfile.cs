using DataLayer.Domain;
using AutoMapper;

namespace WebServer.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<userMain, UserModel>()
                .ForMember(dst => dst.bookmarkTconst, opt => opt.MapFrom(src => src.Bookmarks.Tconst))
                .ForMember(dst => dst.bookmarkNote, opt => opt.MapFrom(src => src.Bookmarks.Note))
                .ForMember(dst => dst.rateTconst, opt => opt.MapFrom(src => src.Ratings.Tconst))
                .ForMember(dst => dst.Rating, opt => opt.MapFrom(src => src.Ratings.Rate))
                .ForMember(dst => dst.searchDate, opt => opt.MapFrom(src => src.History.Date.ToString()))
                .ForMember(dst => dst.SearchInput, opt => opt.MapFrom(src => src.History.SearchInput));

            CreateMap<UserCreateModel, userMain>();
            CreateMap<UserCreateRatingModel, userRate>();
            CreateMap<UserDeleteRating, userRate>();
            CreateMap<userRate, RatingModel>();
        }
    }
}
