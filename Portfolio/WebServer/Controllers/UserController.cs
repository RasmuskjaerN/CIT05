using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace WebServer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly Hashing _hashing;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public UserController(IUserService userService, Hashing hashing, LinkGenerator generator, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            _hashing = hashing;
            _generator = generator;
            _mapper = mapper;
            _configuration = configuration;
        }

        private UserModel UserCreateModel(userMain user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetUser), new { user.Uid });
            return model;
        }


        [HttpPost("create")]
        public IActionResult CreateUser(UserCreateModel model)
        {
            var newUser = _mapper.Map<userMain>(model);
            _userService.CreateUser(newUser.UserName, newUser.Password, newUser.Salt);
            return CreatedAtRoute(null, UserCreateModel(newUser));
        }
        //[Authorize]
        [HttpGet("{uid}", Name = nameof(GetUser))]
        public IActionResult GetUser(int? uid)
        {
            var Uid = _userService.GetUser(uid);

            if (Uid == null)
            {
                return NotFound();
            }

            var model = UserCreateModel(Uid);

            return Ok(model);
        }

        /*[HttpGet("{uid}", Name = nameof(GetUserName))]
        public IActionResult GetUserName(string? username)
        {
            var UserName = _userService.GetUserName(username);

            if (UserName == null)
            {
                return NotFound();
            }

            var model = UserCreateModel(UserName);

            return Ok(model);
        }*/



        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers().Select(x => UserCreateModel(x));
            return Ok(users);
        }


        [HttpPost("uid")]
        [Route("delete")]
        public IActionResult DeleteUser(int uid)
        {
            if (uid == 0)
            {
                return NotFound();
            }
            try
            {
                _userService.DeleteUser(uid);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("uid&tconst&rating")]
        [Route("rate")]

        public IActionResult CreateRating(string uid, string tconst, int rating)
        {
            if (uid == null && string.IsNullOrEmpty(tconst) && rating == null)
            {
                return BadRequest();
            }
            try
            {
                _userService.CreateRating(uid, tconst, rating);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("uid&tconst")]
        [Route("ratedelete")]
        public IActionResult DeleteRating(string uid, string tconst)
        {
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }
            try
            {
                _userService.DeleteRating(uid, tconst);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPost]
        [Route("bookmark/create")]
        public IActionResult CreateMovieBookmark(CreateMovieBookmarkModel movie)
        {
            if (movie.Uid == null || string.IsNullOrEmpty(movie.Tconst ))
            {
                return BadRequest();
            }
            try
            {
                _userService.CreateMovieBookmark(movie.Uid, movie.Tconst, movie.Note);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
        
        [HttpPost]
        [Route("delete/bookmark")]
        
        public IActionResult DeleteMovieBookmark(int uid, string tconst)
        {
            if (uid == null || string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }
            try
            {
                _userService.DeleteMovieBookmark(uid, tconst);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
                 
        }
        private UserModel HistoryGetModel(userHistory history)
        {
            var model = _mapper.Map<UserModel>(history);
            model.Url = _generator.GetUriByName(HttpContext,
                                                nameof(GetUser),
                                                new { history.Uid });
            return model;
        }

        [HttpGet]
        [Route("history/{uid}")]
        public IActionResult GetHistory(int uid)
        {
            if (uid != null)
            {
                var data = _userService.GetUsersHistory(uid).Select(x => _mapper.Map<UserGetHistory>(x));
                if (data != null)
                {
                    return Ok(data);
                }
            }
            return BadRequest();

        }
        [HttpPost]
        [Route("stringsearch")]
        public IActionResult StringSearch(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest();
            }
            var data = _userService.getSearch(input).Select(x => _mapper.Map<SearchResultModel>(x));

            /*try
            {
                _userService.getSearch(input);
            }
            catch
            {
                return BadRequest();
            }*/
            return Ok(data);
        }
        [HttpPost]
        [Route("stringsearch/{uid}")]
        public IActionResult StringSearch(int uid, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest();
            }
            var data = _userService.getSearch(uid, input).Select(x => _mapper.Map<SearchResultModel>(x));

            /*try
            {
                _userService.getSearch(input);
            }
            catch
            {
                return BadRequest();
            }*/
            return Ok(data);
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetUsers), new { page, pageSize });
        }
       

        [HttpPost("register")]
        public IActionResult RegisterUser(UserCreateModel model)
        {
            if(_userService.GetUserName(model.UserName) != null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest();
            }

            var hashResult = _hashing.hash(model.Password);
            _userService.CreateUser(model.UserName, hashResult.hash, hashResult.salt);
            return Ok();
        }
        [HttpPost("login")]
        public IActionResult LoginUser(UserLoginModel model)
        {
            var user = _userService.GetUserName(model.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            if(!_hashing.Verify(model.Password, user.Password, user.Salt))
            {
                return BadRequest();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Auth:secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {user.Uid,user.UserName, token = jwt});
        }

    }
}
