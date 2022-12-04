using DataLayer.Domain;
using AutoMapper;

namespace WebServer.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<userMain, UserModel>();

            CreateMap<UserCreateModel, userMain>();
        }
    }
}
