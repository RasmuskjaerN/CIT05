using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieBookmarkProfile : Profile
    {
        public MovieBookmarkProfile()
        {
            CreateMap<userBookmark, MovieBookmarkModel>();

            CreateMap<CreateMovieBookmarkModel, userBookmark>();
        }
    }
}
