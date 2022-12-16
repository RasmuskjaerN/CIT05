using System;
using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DataLayer
{
    public class UserService : IUserService
    {
        public IMDBContext db = new IMDBContext();
       
        public userMain CreateUser(string? username, string? password = null, string? salt = null)
        {
            var user = new userMain();
            {
                user.Uid = db.userMain.Max(x => x.Uid) + 1;
                user.UserName = username;
                user.Password = password;
                user.Salt = salt;
            };
            db.Add(user);
            db.SaveChanges();
            return user;
        }

        public void DeleteUser(int uid)
        {
            
            db.Database.ExecuteSqlInterpolated($"select user_delete({uid})");
            db.SaveChanges();
        }
        
        public userMain? GetUser(int? uid)
        {
            userMain? user = db.userMain
                .FirstOrDefault(x=> x.Uid == uid);//add first or default tconst
            if (user != null) 
            {
                user.Bookmarks = db.userBookmarks.Where(x => x.Uid == uid).ToList();
                user.Histories = db.userHistories.Where(x => x.Uid == uid).ToList();
                user.Ratings = db.userRates.Where(x => x.Uid == uid).ToList();
            }
            return user;
        }
        public IList<userMain> GetUsers()
        {
            return db.userMain.ToList();
        }
        /*public List<userBookmark> UserGetBookmarks()
        {
            return db.userBookmarks.ToList();
        }
        public List<userRate> GetRatings()
        {
            return db.userRate.ToList();
        }

       /* public IList<UserSearchModel> GetMovieSearch(string userid, string search)
        {
           
            string search_result = db.Database.ExecuteSqlInterpolated($"select string_search({userid},{search})").ToString();
            return (IList<UserSearchModel>)search_result.ToList();
        }*/

        /*public IList<U> GetMovieSearchOffAuth(string search)
        {

            string search_result = db.userHistory.ExecuteSqlInterpolated($"select string_searchoffauth({search})").ToString();
            return search_result.ToList();
        }*/


        public void CreateMovieBookmark(string uid, string tconstmovie, string? note)
        {

            db.Database.ExecuteSqlInterpolated($"select bookmark_movie({uid}, {tconstmovie}, {note})");
            db.SaveChanges();

        }
        public void CreateActorBookmark(string userid, string nconstactor, string? usernote)
        {
            db.Database.ExecuteSqlInterpolated($"select bookmark_actor({userid},{nconstactor},{usernote})");
            db.SaveChanges();
        }
        public void DeleteMovieBookmark(string uid, string tconstmovie)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_bookmark_movie({uid},{tconstmovie})");
            db.SaveChanges();
        }
        public void DeleteRating(string uid, string tconst)
        {
            //var user = db.userRate.Find(uid);
            db.Database.ExecuteSqlInterpolated($"select delete_rate({uid},{tconst})");
            db.SaveChanges();
        }
        public void DeleteActorBookmark(string userid, string nconstactor)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_bookmark_actor({userid},{nconstactor})");
            db.SaveChanges();
        }
        
        
        public void getSearch(string input)
        {
            db.Database.ExecuteSqlInterpolated($"select string_search({input})");
            db.SaveChanges();
        }

        public userMain? GetUserName(string? username)
        {
             userMain? user = db.userMain.Find(username);
            return user;
        }

        public void CreateRating(string uid, string tconst, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
