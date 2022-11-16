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
        public CreateActorBookmark(string userid, string nconstactor, string? usernote)
        {
            var db = new IMDBContext();
            return db.Database.ExecuteSqlInterpolated($"select bookmark_actor({userid},{nconstactor},{usernote})");
        }
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
    }
}
