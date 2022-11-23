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
        public userMain GetUser(string uid)
        {
            using var db = new IMDBContext();
            return db.userMain.Find(uid);
        }
        public userBookmark? CreateActorBookmark(string userid, string tconstmovie, string? usernote)
        {
            var db = new IMDBContext();
<<<<<<< HEAD
            var bookmark = db.userBookmarks.FromSqlInterpolated($"select bookmark_movie({userid},{tconstmovie},{usernote})");
            return bookmark.FirstOrDefault();
        }
=======
            var bookmark = db.userBookmarks.FromSqlInterpolated($"select bookmark_actor({userid},{tconstmovie},{usernote})");
            return bookmark.FirstOrDefault();
       }
>>>>>>> 30086cc3d512026bcb61640ad649b8a69dd763cd
        public void DeleteActorBookmark(string userid, string nconstactor)
        {
            var db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select delete_bookmark_actor({userid},{nconstactor})");
        }
        public void DeleteMovieBookmark(string userid, string tconstmovie)
        {
            var db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select delete_bookmark_movie({userid},{tconstmovie})");
        }
        public void CreateRating(string userid, string title, int rating)
        {
            var db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select rate({userid},{title},{rating})");
        }
        public void DeleteRating(string userid, string tconst)
        {
            var db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select delete_rate({userid},{tconst})");
        }

        /*public void CreateMovieBookmarksql(string userid, string tconstmovie)
        {
            var db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select bookmark_actor({userid},{tconstmovie})");
        }*/

        /*public IList<UserSearchModel> GetActorSearch(string search)
        {
            var db = new IMDBContext();
            return db.nameBasics
                .Include(x => x.Nconst)
                .Where(x => x.PrimaryName == search)
                .Select(x => new UserSearchModel
                {
                    UserId = x.Nconst
                })
                .ToList(); ;
        }*/
        public IList<UserSearchModel> GetActorSearch(string userid, string search)
        {
            var db = new IMDBContext();
            string search_result = db.Database.ExecuteSqlInterpolated($"select string_search({userid},{search})").ToString();
            return (IList<UserSearchModel>)search_result.ToList();
        }

        public userBookmark? UpdateActorBookmark(string userid, string nconstactor, string note)
        {
            throw new NotImplementedException();
        }

        public void CreateMovieBookmark(userBookmark userid, userBookmark? tconstmovie, userBookmark? note)
        {
            using var db = new IMDBContext();
            var bm = new userBookmark
            {
                Uid = userid.Uid,
                Tconst = userid.Tconst,
                Note = note.Note
            };
            db.userBookmarks.Add(bm);
            db.SaveChanges();
            
        }

        public IList<userBookmark> GetMovieBookmarks()
        {
            using var db = new IMDBContext();
            return db.userBookmarks.ToList();
        }

        public userBookmark? GetMovieBookmark(string userid)
        {
            using var db =  new IMDBContext();
            return db.userBookmarks.Find(userid);
        }
    }
}
