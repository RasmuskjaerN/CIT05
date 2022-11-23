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
<<<<<<< HEAD
        userBookmark? CreateActorBookmark(string userid, string nconstactor, string? usernote);
=======
        IList<userBookmark> GetMovieBookmarks();

        userBookmark? GetMovieBookmark(string userid);

        userBookmark? CreateActorBookmark(string userid, string nconstactor, string? usernote);
        userBookmark? UpdateActorBookmark(string userid, string nconstactor, string note);

        void CreateMovieBookmark(userBookmark userid, userBookmark? tconstmovie, userBookmark? note);

>>>>>>> 30086cc3d512026bcb61640ad649b8a69dd763cd
        void DeleteActorBookmark(string userid, string nconstactor);
        void DeleteMovieBookmark(string userid, string tconstmovie);
        void CreateRating(string userid, string title, int rating);
        void DeleteRating(string userid, string tconst);
        IList<UserSearchModel> GetActorSearch(string userid,string search);
    }
}
