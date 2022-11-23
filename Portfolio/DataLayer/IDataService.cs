using DataLayer.Domain;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataService
    {

        titleBasic? GetTitle(string Tconst);
        IList<titleGenre> GetSimilarMovies(string Tconst);
        nameBasic? GetName(string nconst);
        IList<knownFor> GetCoactors(string nconst);
        /*IList<akaAttribute> GetAkaAttributes();
        akaAttribute? GetAkaAttribute(string Tconst);
        IList<akaType> GetAkaTypes();
        akaType? GetAkaType(string Tconst);

        IList<ProductSearchModel> GetAttributeByName(string search);*/

        IList<titlePrincipal> GetPopularActors(string input);





    }
}