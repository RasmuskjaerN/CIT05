using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataService : IDataService
    {
        public akaAttribute? GetAkaAttribute(string Tconst)
        {
            using var db = new IMDBContext();
            return db.Attributes.Find(Tconst);
        }

        public IList<akaAttribute> GetAkaAttributes()
        {
            using var db = new IMDBContext();
            return db.Attributes.ToList();
        }

        public akaType? GetAkaType(string Tconst)
        {
            using var db = new IMDBContext();
            return db.Types.Find(Tconst);
        }

        public IList<akaType> GetAkaTypes()
        {
            using var db = new IMDBContext();
            return db.Types.ToList();
        }

        public IList<ProductSearchModel> GetAttributeByName(string search)
        {
            using var db = new IMDBContext();
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

        public nameBasic? GetName(string nconst)
        {
            using var db = new IMDBContext();
            return db.nameBasics?.FirstOrDefault(x => x.Nconst == nconst);
        }

    }
}

