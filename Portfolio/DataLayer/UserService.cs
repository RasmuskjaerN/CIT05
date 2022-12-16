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
        /*public void CreateUser(userMain newUser)
        {
            newUser.Uid = db.userMain.Any() ? db.userMain.Max(x => x.Uid) + 1 : 1;
            //db.Database.ExecuteSqlInterpolated($"select user_create({newUser.UserName},{newUser.Password}");
            db.userMain.Add(newUser);
            db.SaveChanges();
            //create sql function elsewhere and save changes through that.
        }*/
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
        public userMain? GetUser(int uid)
        {
            userMain? user = db.userMain
                .Include(x => x.Bookmarks)
                .Include(x => x.Ratings)
                .Include(x => x.History)
                .FirstOrDefault(x=> x.Uid == uid);
            return user;
        }
        /*public IList<userMain>? GetUserModel()
        {
            //userMain? user = 
            return db.userMain
                .Include(x => x.Bookmarks)
                .Include(x => x.Ratings)
                .Include(x => x.History)
                .OrderBy(x=>x.Uid)
                .ToList();
            //return user;
        }*/
        public IList<userMain> GetUsers()//tjek bulskovs product search model for inspiration.
        {
            return db.userMain.ToList();
        }

        public void CreateRating(string uid, string tconst, int rating)
        {
            db.Database.ExecuteSqlInterpolated($"select rate_movie({uid},{tconst},{rating})");
            db.SaveChanges();
        }
        public void DeleteRating(string uid, string tconst)
        {
            //var user = db.userRate.Find(uid);
            db.Database.ExecuteSqlInterpolated($"select delete_rate({uid},{tconst})");
            db.SaveChanges();
        }

        public IList<userRate> GetRatings()
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

        public void DeleteMovieBookmark(string uid, string tconstmovie)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_bookmark_movie({uid},{tconstmovie})");
            db.SaveChanges();
        }


        public IList<userBookmark> GetMovieBookmarks()
        {
           
            return db.userBookmarks.ToList();
        }

        public userBookmark? GetMovieBookmark(string userid)
        {
         
            return db.userBookmarks.Find(userid);
        }

        public void CreateActorBookmark(string userid, string nconstactor, string? usernote)
        {
            db.Database.ExecuteSqlInterpolated($"select bookmark_actor({userid},{nconstactor},{usernote})");
            db.SaveChanges();
        }

        public void DeleteActorBookmark(string userid, string nconstactor)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_bookmark_actor({userid},{nconstactor})");
            db.SaveChanges();
        }
        //cannot get history to return the actual user_history, so for now it's void
      /*  public void GetUsersHistory(string uid)
        {

            var result = db.userHistory.Find(uid);
            //return result;
           
        }*/
        
        public void getSearch(string input)
        {
            db.Database.ExecuteSqlInterpolated($"select string_search({input})");
            db.SaveChanges();
        }
<<<<<<< HEAD
        
/*
        public IList<tempSearch> GetTitlesSearchList(List<string> search)
=======
        public userMain GetUserName(string? username)
        {
            return db.userMain.FirstOrDefault(x => x.UserName == username);
        }


        /*public IList<tempSearch> GetTitlesSearchList(List<string> search)
>>>>>>> f9e92dab41f4aaff27c0606ee026f07218cbe348
        {
            string ConcatInput = "SELECT * string_search('";
            foreach (string element in search)
            {
                if (search.Last().Equals(element))
                {
                    ConcatInput = ConcatInput + element;
                    ConcatInput = ConcatInput + "')";
                    break;
                }
                ConcatInput = ConcatInput + element;
                ConcatInput = ConcatInput + "', '";

            }

            var result = db.tempSearches.FromSqlRaw(ConcatInput);
            return result.ToList();
            
        }*/
    }
}
