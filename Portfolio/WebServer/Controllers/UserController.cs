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

        [HttpGet(Name = nameof(GetMovieBookmarks))]
        public IActionResult GetMovieBookmarks()
        {
            var bookmarks = _userService.GetMovieBookmarks().Select(x => CreateMovieBookmarkModel(x));
            return Ok(bookmarks);
        }

        [HttpGet("{userid}", Name = nameof(GetMovieBookmark))]
        public IActionResult GetMovieBookmark(string userid)
        {
            var user = _userService.GetMovieBookmark(userid);

            if (user == null)
            {
                return NotFound();
            }

            var model = CreateMovieBookmarkModel(user);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateMovieBookmark(CreateMovieBookmarkModel model)
        {
            var bm = _mapper.Map<userBookmark>(model);            

            _userService.CreateMovieBookmark(bm, bm, bm);

            return CreatedAtRoute(null, CreateMovieBookmarkModel(bm));
        }

        private MovieBookmarkModel CreateMovieBookmarkModel(userBookmark user)
        {
            var model = _mapper.Map<MovieBookmarkModel>(user);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovieBookmark), new { user.Uid});
            model.Uid = user.Uid;
            model.Tconst = "tt6201920 "+user.Tconst;
            model.Note = "this is a test"+user.Note;
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetMovieBookmarks), new{page, pageSize});
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
