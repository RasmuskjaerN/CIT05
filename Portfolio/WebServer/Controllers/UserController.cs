﻿using Microsoft.AspNetCore.Mvc;
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
        /*[HttpGet]
        [Route("tempSearch")]
        public IActionResult GetTitlesSearchList(List<string> userinput)
        {
            if (userinput == null && !userinput.Any())
            {
                return BadRequest();
            }

            var search = _userService.GetTitlesSearchList(userinput);
            return Ok(search);
        }*/

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
            var newUser = _mapper.Map<userMain>(model);
            _userService.CreateUser(newUser.UserName, newUser.Password);
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

        [HttpGet("{userid}", Name = nameof(GetUser))]
        public IActionResult GetUser(string userid)
        {
            var user = _userService.GetUser(userid);

            if (user == null)
            {
                return NotFound();
            }

            var model = UserCreateModel(user);

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
            return _generator.GetUriByName(HttpContext, nameof(GetUsers), new { page, pageSize });
        }

        
    }
}
