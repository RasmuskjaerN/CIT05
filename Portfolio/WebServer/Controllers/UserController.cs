using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, LinkGenerator generator, IMapper mapper)
        {
            _userService = userService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovieTconst()
        {
            var movieTconst = _userService.GetMovieTconst().Select(x => CreateMovieBookmarkModel(x));
            return Ok(movieTconst);
        }

        [HttpGet("{tconst}", Name = nameof(GetMovieTconst))]
        public IActionResult GetMovieTconst(string tconst)
        {
            var movieTconst = _userService.GetMovieTconst(tconst);

            if (movieTconst == null)
            {
                return NotFound();
            }

            var model = CreateMovieBookmarkModel(movieTconst);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateMovieBookmark(CreateMovieBookmarkModel model)
        {
            var movieBookmark = _mapper.Map<userBookmark>(model);

            _userService.CreateMovieBookmark(movieBookmark);

            return CreatedAtRoute(null, CreateMovieBookmarkModel(movieBookmark));
        }

        private MovieBookmarkModel movieBookmarkModel(userBookmark movieBookmark)
        {
            var model = _mapper.Map<MovieBookmarkModel>(movieBookmark);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovieTconst), new { movieBookmark.Uid });
            return model;
        }

        private MovieBookmarkModel CreateMovieBookmarkModel(userBookmark movieBookmark)
        {
            var model = _mapper.Map<MovieBookmarkModel>(movieBookmark);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovieTconst), new { movieBookmark.Uid });
        }

        /*[HttpPost("{uid}")]
        public IActionResult CreateActorBookmark(string userid, string tconstmovie, string? usernote)
        {
            var movieBookmark = _userService.CreateActorBookmark(userid, tconstmovie, usernote);

            if (movieBookmark == null)
            {
                return NotFound();
            }
            var model = new UserBookmarkModel
            {
                Url = "http//:localhost/5001/api/user" + movieBookmark.Uid,
                Tconst = movieBookmark.Tconst,
                //Nconst = movieBookmark.Nconst,
                Note = movieBookmark.Note
            }
        };*/




    }
}
