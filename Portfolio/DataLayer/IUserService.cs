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
        void CreateActorBookmark(string userid, string nconstactor, string? usernote);
        IList<userBookmark> GetMovieBookmarks();
        userBookmark? GetMovieBookmark(string userid);
        void CreateMovieBookmark(string userid, string tconstmovie, string? note);
        void DeleteActorBookmark(string userid, string nconstactor);
        void DeleteMovieBookmark(string userid, string tconstmovie);
        void CreateRating(string uid, string tconst, int rating);
        void DeleteRating(string uid, string tconst);
        IList<UserSearchModel> GetActorSearch(string userid,string search);
        void CreateUser(userMain newUser);
        void DeleteUser(int uid);
        public userMain? GetUser(int uid);
        IList<userMain> GetUsers();
        void GetUsersHistory(string userid);
        IList<userRate> GetRatings();
    }
}
