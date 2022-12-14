﻿using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
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
            _userService.CreateUser(newUser.UserName, newUser.Password, newUser.Salt);
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
        
        /*private RatingModel UserCreateRatingModel(userRate us)
        {
            var model = _mapper.Map<userRate>(us);
            model.Uid = us.Uid;
           w return model;
        }*/

        [HttpPost("uid&tconst&rating")]
        [Route("rate")]
        //[Authorize]
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
        
        [HttpPost("uid&tconst")]
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
                return Ok("hello");
            }
            return Ok();
        }
        

        /*[HttpPost("create/moviemark/{tconstmovie}")]
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
        }*/
        /*
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
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Auth:secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {user.UserName, token = jwt});
        }

    }
}
