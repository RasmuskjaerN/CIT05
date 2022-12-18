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
        //userBookmark? GetMovieBookmark(string userid);
        void CreateMovieBookmark(string userid, string tconstmovie, string? note);
        void DeleteActorBookmark(string userid, string nconstactor);
        void DeleteMovieBookmark(string userid, string tconstmovie);
        void CreateRating(string uid, string tconst, int rating);
        void DeleteRating(string uid, string tconst);
       /* IList<UserSearchModel> GetMovieSearch(string userid,string search);
        IList<UserSearchModel> GetMovieSearchOffAuth(string search);*/
        //void CreateUser(userMain newUser);
        //IList<UserSearchModel> GetActorSearch(string userid,string search);
        //void CreateUser(userMain newUser);
        userMain CreateUser(string? username, string? password = null, string? salt = null);
        void DeleteUser(int uid);
        public userMain? GetUser(int? uid);
        /*IList<userMain>? GetUserModel();*/
        public userMain? GetUserName(string? username);
        public IList<userMain> GetUsers();

        IList<userHistory> GetUsersHistory(int uid);
        IList<SearchResult> getSearch(string input);
        IList<SearchResult> getSearch(int uid, string input);
    }
}
