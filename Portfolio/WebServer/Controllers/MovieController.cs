using System.Reflection.Emit;
using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;


        private const int MaxPageSize = 25;

        public MovieController(IDataService dataService, IMapper mapper, LinkGenerator generator)
        {
            _dataService = dataService;
            _mapper = mapper;
            _generator = generator;
        }

        [HttpGet("{tconst}", Name = nameof(GetMovie))]
        public IActionResult GetMovie(string tconst)
        {
            var movie = _dataService.GetMovie(tconst);

            if (movie == null)
            {
                return NotFound();
            }
            var model = MovieCreateModel(movie);

            return Ok(model);
        }

        [HttpGet(Name = nameof(GetMovies))]
        [Route("{page}&{pageSize}")]
        [Authorize]
        public IActionResult GetMovies(int page = 0, int pagesize = 10)
        {
            var movies = _dataService.GetMoviesList(page, pagesize).Select(x => MovieCreateListModel(x));
            var total = _dataService.GetMoviesListCount();
            return Ok(Paging(page, pagesize, total, movies));
        }

        private MovieListModel MovieCreateListModel(titleBasic tconst)
        {
            var model = _mapper.Map<MovieListModel>(tconst);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovie), new { tconst.Tconst });
            return model;
        }

        private MovieModel MovieCreateModel(titleBasic tconst)
        {
            var model = _mapper.Map<MovieModel>(tconst);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovie), new { tconst.Tconst });
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetMovies), new { page, pageSize });
        }
        private object Paging<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

            var pages = (int)Math.Ceiling((double)total / (double)pageSize)
                ;

            var first = total > 0
                ? CreateLink(0, pageSize)
                : null;

            var prev = page > 0
                ? CreateLink(page - 1, pageSize)
                : null;

            var current = CreateLink(page, pageSize);

            var next = page < pages - 1
                ? CreateLink(page + 1, pageSize)
                : null;

            var result = new
            {
                first,
                prev,
                next,
                current,
                total,
                pages,
                items
            };
            return result;
        }
    }
}
