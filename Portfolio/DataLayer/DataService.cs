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
        public akaAttribute? GetAkaAttributes(string Tconst)
        {
            throw new NotImplementedException();
        }

        public IList<akaAttribute> GetAkaAttributes()
        {
            throw new NotImplementedException();
        }

        public akaType? GetAkaType(string Tconst)
        {
            throw new NotImplementedException();
        }

        public IList<akaType> GetAkaTypes()
        {
            throw new NotImplementedException();
        }

        public IList<ProductSearchModel> GetAttributeByName(string search)
        {
            throw new NotImplementedException();
        }
    }
}
/* public void CreateCategory(akaAttribute akaType)
        {
            using var db = new NorthwindContext();
            akaType.Id = db.Categories.Any() ? db.Categories.Max(x => x.Id) + 1 : 1;
            db.Categories.Add(akaType);
            db.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            using var db = new NorthwindContext();
            var akaType = db.Categories.Find(id);
            db.Categories.Remove(akaType);
            return db.SaveChanges() > 0;
        }

        public IList<Category> GetAkaTypes()
        {
            using var db = new NorthwindContext();
            return db.Categories.ToList();
        }

        public Category? GetAkaType(int id)
        {
            using var db = new NorthwindContext();
            return db.Categories.Find(id);
        }

        public AkaAttribute? GetProduct(int id)
        {
            using var db = new NorthwindContext();
            return db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public IList<ProductSearchModel> GetProductByName(string search)
        {
            using var db = new NorthwindContext();
            return db.Products
                .Include(x => x.Category)
                .Where(x => x.Name == search)
                .Select(x => new ProductSearchModel
                {
                    ProductName = x.Name,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }

        public IList<AkaAttribute> GetAkaAttributes(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.Products
                .Include(x => x.Category)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public int GetNumberOfAttributes()
        {
            using var db = new NorthwindContext();
            return db.Products.Count();
        }

        public bool UpdateCategory(Category akaType)
        {
            using var db = new NorthwindContext();
            var dbCategory = db.Categories.Find(akaType.Id);
            if (dbCategory == null) return false;
            dbCategory.Name = akaType.Name;
            dbCategory.Description = akaType.Description;
            db.SaveChanges();
            return true;
        }*/