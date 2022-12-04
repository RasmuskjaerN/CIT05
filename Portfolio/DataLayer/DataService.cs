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
        public IList<titleBasic> GetMoviesList(string Tconst)
        {
            return db.titleBasics.ToList();
        }
        public titleBasic? GetMovie(string Tconst)
        {
            titleBasic? title = db.titleBasics.Find(Tconst);
            return title;
        }

        public IList<titleBasic> GetMoviesList(int page = 0, int pagesize = 25)
        {
            return db.titleBasics.Skip(page).Take(pagesize).ToList();
        }

        public IList<titleGenre> GetSimilarMoviesList(string Tconst)
        {
            return db.titleGenres.ToList();
        }
        
        public nameBasic? GetName(string nconst)
        {
            nameBasic? name = db.nameBasics.Find(nconst);
            return name;
        }

        public IList<nameBasic> GetNamesList(string nconst)
        {
            return db.nameBasics.ToList();
        }

        public IList<nameBasic> GetNamesList(int page = 0, int pagesize = 25)
        {
            return db.nameBasics.Skip(page).Take(pagesize).ToList();
        }


        public IList<knownFor> GetCoactors(string nconst)
        {
            throw new NotImplementedException();
        }
        

    }
}

