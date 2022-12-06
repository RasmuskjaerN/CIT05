using DataLayer.Domain;
using AutoMapper;

namespace WebServer.Models.Profiles
{
    public class NameBasicProfile : Profile
    {
        public NameBasicProfile()
        {
            CreateMap<nameBasic, NameBasicModel>();
            CreateMap<NameCreateModel, nameBasic>();
        }
        
    }

}
