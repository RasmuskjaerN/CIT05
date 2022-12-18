using DataLayer.Domain;
using AutoMapper;
using DataLayer.Models;

namespace WebServer.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<userMain, UserModel>();                
            CreateMap<userBookmark, userbookmarkmodel>()
                .ForMember(dst => dst.bookmarkTconst, opt => opt.MapFrom(src => src.Tconst))
                .ForMember(dst => dst.bookmarkNote, opt => opt.MapFrom(src => src.Note));
            CreateMap<userHistory, userhistorymodel>()
               .ForMember(dst => dst.historyDate, opt => opt.MapFrom(src => src.Date))
               .ForMember(dst => dst.historySearchInput, opt => opt.MapFrom(src => src.SearchInput));
            CreateMap<userRate, userratingmodel>()
               .ForMember(dst => dst.ratingTconst, opt => opt.MapFrom(src => src.Tconst))
               .ForMember(dst => dst.ratingRate, opt => opt.MapFrom(src => src.Rating));

            CreateMap<UserCreateModel, userMain>();
            CreateMap<userMain,UserLoginModel>();
            CreateMap<UserCreateBookmark, userBookmark>();
            CreateMap<UserDeleteBookmark, userBookmark>();
            CreateMap<userHistory, UserGetHistory>().ReverseMap();
            CreateMap<UserModel, userHistory>();
            CreateMap<SearchResult, SearchResultModel>();
        }
    }
}
