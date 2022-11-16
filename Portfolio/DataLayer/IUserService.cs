using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public interface IUserService
    {
        void CreateActorBookmark(string userid, string nconstactor, string usernote);

        void CreateMovieBookmark(string userid, string tconstmovie);
        void DeleteActorBookmark(string userid, string nconstactor);
        void DeleteMovieBookmark(string userid, string tconstmovie);
        void CreateRating(string userid, string title, int rating);
        void DeleteRating(string userid, string tconst);
        IList<UserSearchModel> GetActorSearch(string userid,string search);
    }
}
