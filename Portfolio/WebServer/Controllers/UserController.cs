using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;
using WebServiceTokens.Models;

namespace WebServer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
                
        private IUserService _userService;
        //private readonly Hashing _hashing;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public UserController(IUserService userService, /*Hashing hashing,*/ IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            //_hashing = hashing;
            _generator = _generator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult CreateUser(UserCreateModel model)
        {
            if (_userService.GetUser(model.UserName) == null)
            {
                return BadRequest();
            }
           if (_userService.GetUser(model.Password) == null)
            {
                return BadRequest();
            }
            //var hashResult = _hashing.hash(model.Password);
            _userService.CreateUser(model.UserName, model.Password);
            return Ok();
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

        [HttpPost("{userid}",Name =nameof(CreateMovieBookmark))]
        public IActionResult CreateMovieBookmark(CreateMovieBookmarkModel model)
        {
            var bm = _mapper.Map<userBookmark>(model);
            

            _userService.CreateMovieBookmark(bm, bm, bm);

            return CreatedAtRoute(null, CreateMovieBookmarkModel(bm));
        }

        private MovieBookmarkModel CreateMovieBookmarkModel(userBookmark user)
        {
            var model = _mapper.Map<MovieBookmarkModel>(user);
            //model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovieBookmark), new { user.Uid});
            model.Url = "http//:localhost/5001/api/user" + user.Uid;
            //model.Uid = "44444";
            //model.Tconst = "tt6201920";
            //model.Note = "test create";
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetMovieBookmarks), new { page, pageSize });
        }
    }
}
