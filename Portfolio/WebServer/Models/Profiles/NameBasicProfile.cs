using DataLayer.Domain;
using AutoMapper;

namespace WebServer.Models.Profiles
{
    public class NameBasicProfile : Profile
    {
        public NameBasicProfile()
        {
            CreateMap<nameBasic, NameBasicModel>();
            CreateMap<nameBasic, NameBasicListModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<titleBasic, NameCharacterModel>();
            
        }
        
    }

}
