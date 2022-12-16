using DataLayer.Domain;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLayer
{
    public interface IDataService
    {

        titleBasic? GetMovie(string tconst);
        IList<titleBasic> GetMoviesList(int page, int pagesize);
        int GetMoviesListCount();

        IList<titleGenre> GetSimilarMoviesList(string uid,string Tconst);

        nameBasic? GetName(string nconst);
        int GetNamesListCount();
        IList<nameBasic> GetNamesList(int page, int pagesize);
        IList<knownFor> GetCoactors(string uid,string namein);
        





    }
}