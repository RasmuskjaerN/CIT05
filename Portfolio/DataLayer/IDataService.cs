using DataLayer.Domain;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataService
    {
        
        IList<akaAttribute> GetAkaAttributes();
        akaAttribute? GetAkaAttributes(string Tconst);
        IList<akaType> GetAkaTypes();
        akaType? GetAkaType(string Tconst);

        IList<ProductSearchModel> GetAttributeByName(string search);
     
    }
}