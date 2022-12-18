using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataService : IDataService
    {
        
        public IMDBContext db = new IMDBContext();

        public titleBasic? GetMovie(string? tconst)
        {
            
            titleBasic? movie = db.titleBasics
                .FirstOrDefault(x => x.Tconst == tconst);//add first or default tconst
            if (movie != null)
            {
                movie.OmdbData = db.omdbData.Where(x => x.Tconst == tconst).ToList();
                movie.TitleAkas = db.titleAkas.Where(x => x.Tconst == tconst).ToList();
                movie.TitleRating = db.titleRatings.Where(x => x.Tconst == tconst).ToList();
                movie.UserBookmarks = db.userBookmarks.Where(x => x.Tconst == tconst).ToList();
                movie.UserRating = db.userRates.Where(x => x.Tconst == tconst).ToList();
                
            }
            return movie;
        }

        public IList<titleBasic> GetMoviesList(int page = 0, int pagesize = 25)
        {
            return db.titleBasics.Include(x=>x.OmdbData).Include(x=> x.TitleRating).Skip(page * pagesize).Take(pagesize).OrderBy(x => x.Tconst).ToList();
        }
        public int GetMoviesListCount()
        {
            return db.titleBasics.Count();
        }

        public IList<titleGenre> GetSimilarMoviesList(string uid,string Tconst)
        {
            var result = db.titleGenres.FromSqlInterpolated($"select sim_movie({uid},{Tconst}");
            return result.ToList();
        }
        
        public nameBasic? GetName(string nconst)
        {
            nameBasic? name = db.nameBasics.Find(nconst);
            return name;
        }

        public int GetNamesListCount()
        {
            return db.nameBasics.Count();
        }

        public IList<nameBasic> GetNamesList(int page = 0, int pagesize = 25)
        {
            return db.nameBasics.Skip(page * pagesize).Take(pagesize).ToList();
        }


        public IList<knownFor> GetCoactors(string uid, string namein)
        {
            var result = db.knownFor.FromSqlInterpolated($"select find_coactor({uid},{namein})");
            return result.
        ToList();
        }

    }
}

