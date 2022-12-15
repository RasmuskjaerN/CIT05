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
