using AutoMapper;

namespace WebServer.Models.Profiles
{
    public class AttributeProfile : Profile
    {

        public AttributeProfile()
        {
            CreateMap<AkaAttributeModel, AkaAttributeModel>();
        }


    }
}
