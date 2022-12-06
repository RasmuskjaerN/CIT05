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
        void CreateRating(string userid, string titlein, int rating);
        void DeleteRating(string userid, string tconst);
        IList<UserSearchModel> GetActorSearch(string userid,string search);
        void CreateUser(userMain newUser);
<<<<<<< HEAD
        void DeleteUser(string username, string password);
        public userMain? GetUser(string username);
=======
        public userMain? GetUser(int uid);
>>>>>>> c96309e0f52277decfb6a63c65931c0b92f087be
        IList<userMain> GetUsers();
        void GetUsersHistory(string userid);
    }
}
