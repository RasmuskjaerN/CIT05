using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
                
        private readonly IUserService _userService;
        //private readonly Hashing _hashing;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public UserController(IUserService userService, /*Hashing hashing,*/LinkGenerator generator, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            //_hashing = hashing;
            _generator = generator;
            _mapper = mapper;
        }
        

        [HttpPost]
        public IActionResult CreateUser(UserCreateModel model)
        {
            /*if (_userService.GetUser(model.UserName) == null)
            {
                return BadRequest();
            }
           if (_userService.GetUser(model.Password) = null)
            {
                return BadRequest();
            }*/
            //var hashResult = _hashing.hash(model.Password);
            var newUser = _mapper.Map<userMain>(model);
            _userService.CreateUser(newUser);
            return CreatedAtRoute(null, UserCreateModel(newUser));
        }

       
        private UserModel UserCreateModel(userMain user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetUser), new { user.Uid });
            return model;
        }

        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers().Select(x => UserCreateModel(x));
            return Ok(users);
        }

        [HttpDelete]
        public IActionResult DeleteUser(string username, string password)
        {
            if (username == null)
            {
                return BadRequest();
            }
            try
            {
                _userService.DeleteUser(username, password);
            } catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("{username}", Name = nameof(GetUser))]
        public IActionResult GetUser(string user)
        {
            var username = _userService.GetUser(user);

            if (username == null)
            {
                return NotFound();
            }

            var model = UserCreateModel(username);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateRating(string userid, string tconst, string note)
        {
            if (userid == null || tconst == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRating(string userid, string tconst)
        {
            if (userid == null || tconst == null)
            {
                return BadRequest();
            }
            try
            {
                _userService.DeleteRating(userid, tconst);
            } catch
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPost]
        public IActionResult CreateMovieBookmark(string uid, string tconstmovie, string? note)
        {
            if (uid == null || tconstmovie == null)
            {
                return BadRequest();
            }
            try
            {
                _userService.CreateMovieBookmark(uid, tconstmovie, note);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete/{uid]")]
        
        public IActionResult DeleteMovieBookmark(string uid, string tconstmovie)
        {
            if (uid == null || tconstmovie == null)
            {
                return BadRequest();
            }
            try
            {
                _userService.DeleteMovieBookmark(uid, tconstmovie);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
                 
        }

        [HttpGet]
        [Route("{uid}/history")]

        public IActionResult GetHistory([FromRoute]string userid)
        {
            if (!string.IsNullOrEmpty(userid))
            {
                return BadRequest();
            }
                       
            return Ok();
        }
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetUsers), new { page, pageSize });
        }

        
    }
}
