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
        public void CreateUser(string username, string password)
        {
            db.Database.ExecuteSqlInterpolated($"select user_create({username},{password}");
            db.SaveChanges();
        }

        public void DeleteUser(string uid, string username)
        {
            
            db.Database.ExecuteSqlInterpolated($"select user_delete({uid}, {username})");
            db.SaveChanges();
        }
        public userMain GetUser(string uid)
        {
            return db.userMain.Find(uid);
        }
        
        public userMain GetUserName(string username)
        {
            return db.userMain.Find(username);
        }
        public void DeleteRating(string userid, string tconst)
        {
           
            db.Database.ExecuteSqlInterpolated($"select delete_rate({userid},{tconst})");
        }

       

        /*public IList<UserSearchModel> GetActorSearch(string search)
        {
           
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
           
            string search_result = db.Database.ExecuteSqlInterpolated($"select string_search({userid},{search})").ToString();
            return (IList<UserSearchModel>)search_result.ToList();
        }

        public userBookmark? UpdateActorBookmark(string userid, string nconstactor, string note)
        {
            throw new NotImplementedException();
        }

        public void CreateMovieBookmark(userBookmark userid, userBookmark? tconstmovie, userBookmark? note)
        {
           
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
           
            return db.userBookmarks.ToList();
        }

        public userBookmark? GetMovieBookmark(string userid)
        {
         
            return db.userBookmarks.Find(userid);
        }

        public userBookmark? CreateActorBookmark(string userid, string nconstactor, string? usernote)
        {
            throw new NotImplementedException();
        }

        public void DeleteActorBookmark(string userid, string nconstactor)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovieBookmark(string userid, string tconstmovie)
        {
            throw new NotImplementedException();
        }

        public void CreateRating(string userid, string title, int rating)
        {
            throw new NotImplementedException();
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
