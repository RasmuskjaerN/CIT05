using DataLayer.Domain;
using AutoMapper;
using DataLayer.Models;

namespace WebServer.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
<<<<<<< HEAD
            CreateMap<userMain, UserModel>();
=======
            CreateMap<userMain, UserModel>()
                .ForMember(dst => dst.bookmarkTconst, opt => opt.MapFrom(src => src.Bookmarks.Tconst))
                .ForMember(dst => dst.bookmarkNote, opt => opt.MapFrom(src => src.Bookmarks.Note))
                .ForMember(dst => dst.rateTconst, opt => opt.MapFrom(src => src.Ratings.Tconst))
                .ForMember(dst => dst.Rating, opt => opt.MapFrom(src => src.Ratings.Rate))
                .ForMember(dst => dst.searchDate, opt => opt.MapFrom(src => src.History.Date.ToString()))
                .ForMember(dst => dst.SearchInput, opt => opt.MapFrom(src => src.History.SearchInput));

>>>>>>> f9e92dab41f4aaff27c0606ee026f07218cbe348
            CreateMap<UserCreateModel, userMain>();
            CreateMap<UserCreateRatingModel, userRate>();
            CreateMap<UserDeleteRating, userRate>();
            CreateMap<UserCreateBookmark, userBookmark>();
            CreateMap<UserDeleteBookmark, userBookmark>();
            CreateMap<userHistory, UserGetHistory>();
            CreateMap<UserModel, userHistory>();
            CreateMap<StringSearchModel, titleBasic>();
            //CreateMap<UserGetHistory, userHistory>();
            CreateMap<tempSearch, MovieSeachModel>();
        }
    }
}
