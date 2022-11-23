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
        
        public IMDBContext? db = new IMDBContext();
        //Get movie titles
        public titleBasic? GetTitle(string Tconst)
        {
            titleBasic? titles = db.titleBasics.Find(Tconst);
            return titles;
        }
        //get similar movies depending on genre
        public IList<titleGenre> GetSimilarMovies(string input)
        {
            
            return (IList<titleGenre>)db.titleGenres.FromSqlInterpolated($"select sim_movie({input})");
        }
        //Get actor names
        public nameBasic? GetName(string nconst)
        {
            
            return db.nameBasics?.FirstOrDefault(x => x.Nconst == nconst);
        }
        //get coactors
        public IList<knownFor> GetCoactors(string primaryname)
        {
            
            return (IList<knownFor>)db.knownFor.FromSqlInterpolated( $"select find_coactors({primaryname})");
        }
        //get attributes
        public akaAttribute? GetAkaAttribute(string Tconst)
        {
            
            return db.Attributes.Find(Tconst);
        }

        public IList<akaAttribute> GetAkaAttributes()
        {
            
            return db.Attributes.ToList();
        }
        //get types
        public akaType? GetAkaType(string Tconst)
        {
            
            return db.Types.Find(Tconst);
        }
        //get akatypes as a list
        public IList<akaType> GetAkaTypes()
        {
            
            return db.Types.ToList();
        }
        //get popular actors
        public IList<titlePrincipal> GetPopularActors(string input)
        {
            
            return (IList<titlePrincipal>)db.titlePrincipals.FromSqlInterpolated($"select popular_actors({input})");
        }
        public IList<ProductSearchModel> GetAttributeByName(string search)
        {
            
            return db.Attributes
                .Include(x => x.Attribute)
                .Where(x => x.Tconst == search)
                .Select(x => new ProductSearchModel
                {
                    AttributeName = x.Attribute,
                    TypeName = x.Tconst
                })
                .ToList();
        }



       

    }
}

