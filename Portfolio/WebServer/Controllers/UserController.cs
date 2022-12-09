using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;

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

        private UserModel UserCreateModel(userMain user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetUser), new { user.Uid });
            return model;
        }


        [HttpPost("create")]
        
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
        [HttpGet("{uid}", Name = nameof(GetUser))]
        public IActionResult GetUser(int uid)
        {
            var Uid = _userService.GetUser(uid);

            if (Uid == null)
            {
                return NotFound();
            }

            var model = UserCreateModel(Uid);

            return Ok(model);
        }



        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers().Select(x => UserCreateModel(x));
            return Ok(users);
        }

<<<<<<< HEAD
        [HttpPost("uid")]
        [Route("delete")]
        public IActionResult DeleteUser(int uid)
=======
        /*[HttpDelete]
        public IActionResult DeleteUser(string username, string password)
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
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
        }*/

<<<<<<< HEAD
        [HttpGet(Name =nameof(GetRatings))]
        public IActionResult GetRatings()
=======
        
        [HttpGet("{uid}", Name = nameof(GetUser))]
        public IActionResult GetUser(int uid)
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
        {
            var ratings = _userService.GetRatings().Select(x => UserCreateRatingModel(x));
            return ratings;
        }
        
        private RatingModel UserCreateRatingModel(userRate us)
        {
            var model = _mapper.Map<userRate>(us);
            model.Uid = us.Uid;
            return model;
        }

<<<<<<< HEAD
        [HttpPost("uid&tconst&rating")]
        [Route("rate")]
        [Authorize]
        public IActionResult CreateRating(string uid, string tconst, int rating)
=======
        /*[HttpPost]
        public IActionResult CreateRating(string userid, string tconst, string? note)
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
        {
            if (uid == null || tconst == null || rating == null)
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
<<<<<<< HEAD
        }
        
        [HttpDelete("Uid&Tconst")]
        [Route("ratedelete")]
        public IActionResult DeleteRating(int uid, string tconst)
=======
        }*/
        /*[HttpDelete]
        public IActionResult DeleteRating(string userid, string tconst)
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
        {
            if (uid == null || string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }
            try
            {
                _userService.DeleteRating(uid, tconst);
            } 
            catch
            {
                return Ok("hello");
            }
            return Ok();
<<<<<<< HEAD
        }
        

        [HttpPost("create/moviemark/{tconstmovie}")]
=======
        }*/


        /*[HttpPost]
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
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
<<<<<<< HEAD
        }
        /*
        [HttpDelete("delete/{uid]")]
        
=======
        }*/

        /*[HttpDelete("delete/{uid]")]
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
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
                 
<<<<<<< HEAD
        }

        [HttpGet("{uid}/history")]
        
=======
        }*/

        /*[HttpGet]
        //[Route("{uid}/history")]
>>>>>>> e9251a7d6b811cb87bb31858f90fdcb5b361be2b
        public IActionResult GetHistory([FromRoute]string userid)
        {
            if (!string.IsNullOrEmpty(userid))
            {
                return BadRequest();
            }
                       
            return Ok();
        }*/
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetUsers), new { page, pageSize });
        }*/
        
        [HttpPost("Uid")]
        [Route("delete")]
        public IActionResult DeleteUser(int Uid)
        {
            if (Uid == 0)
            {
                return BadRequest();

            }

            try
            {
                _userService.DeleteUser(Uid);
            }
            catch
            {
                return BadRequest();
            }


            return Ok();

        }


    }
}
