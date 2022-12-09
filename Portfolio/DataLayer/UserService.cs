using System;
using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserService : IUserService
    {
        public IMDBContext db = new IMDBContext();
        public void CreateUser(userMain newUser)
        {
            newUser.Uid = db.userMain.Any() ? db.userMain.Max(x => x.Uid) + 1 : 1;
            //db.Database.ExecuteSqlInterpolated($"select user_create({newUser.UserName},{newUser.Password}");
            db.userMain.Add(newUser);
            db.SaveChanges();
            //create sql function elsewhere and save changes through that.
        }

        public void DeleteUser(int uid)
        {
            
            db.Database.ExecuteSqlInterpolated($"select user_delete({uid})");
            db.SaveChanges();
        }
        public userMain? GetUser(int uid)
        {
            var user = db.userMain.Find(uid);
            return user;
        }
        public IList<userMain> GetUsers()
        {
            return db.userMain.ToList();
        }

        public void CreateRating(string uid, string tconst, int rating)
        {
            db.Database.ExecuteSqlInterpolated($"select rate_movie({uid},{tconst},{rating})");
            db.SaveChanges();
        }
        public void DeleteRating(int uid, string tconst)
        {
            //var user = db.userRate.Find(uid);
            db.Database.ExecuteSqlInterpolated($"select delete_rate({uid},{tconst})");
            db.SaveChanges();
        }

        public IList<userRate> GetRatings()
        {
            return db.userRate.ToList();
        }

        public IList<UserSearchModel> GetActorSearch(string userid, string search)
        {
           
            string search_result = db.Database.ExecuteSqlInterpolated($"select string_search({userid},{search})").ToString();
            return (IList<UserSearchModel>)search_result.ToList();
        }

        

        public void CreateMovieBookmark(string uid, string tconstmovie, string? note)
        {

            db.Database.ExecuteSqlInterpolated($"select bookmark_movie({uid}, {tconstmovie}, {note})");
            db.SaveChanges();
            
        }

        public void DeleteMovieBookmark(string uid, string tconstmovie)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_movie_bookmark({uid},{tconstmovie})");
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

        public void GetUsersHistory(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select get_user_history({userid})");
            db.SaveChanges();
        }
        

        /*public IList<tempSearch> GetTitlesSearchList(List<string> search)
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
