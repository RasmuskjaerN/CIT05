using DataLayer.Domain;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLayer
{
    public interface IDataService
    {

        titleBasic? GetMovie(string Tconst);

        IList<titleBasic> GetMoviesList(string Tconst);
        IList<titleBasic> GetMoviesList(int page, int pagesize);

        IList<titleGenre> GetSimilarMoviesList(string Tconst);

        nameBasic? GetName(string nconst);
        IList<nameBasic> GetNamesList(string nconst);
        IList<nameBasic> GetNamesList(int page, int pagesize);
        IList<knownFor> GetCoactors(string nconst);
        





    }
}