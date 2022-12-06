using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;
using AutoMapper;
using DataLayer.Domain;
<<<<<<< HEAD
using WebServiceTokens.Models;
=======
>>>>>>> 12f94253f6db57afab7e06b75d48454898aeb0d8

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

<<<<<<< HEAD
        public UserController(IUserService userService, /*Hashing hashing,*/ IConfiguration configuration, IMapper mapper, LinkGenerator generator)
        {
            _userService = userService;
            //_hashing = hashing
            _configuration = configuration;
=======
        public UserController(IUserService userService, /*Hashing hashing,*/LinkGenerator generator, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            //_hashing = hashing;
>>>>>>> 12f94253f6db57afab7e06b75d48454898aeb0d8
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
        public IActionResult CreateUser(UserCreateModel model)
        {
<<<<<<< HEAD
            if (_userService.GetUserName(model.UserName) == null)
=======
            /*if (_userService.GetUser(model.UserName) == null)
>>>>>>> 12f94253f6db57afab7e06b75d48454898aeb0d8
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

        /*private UserModel NewUserCreateModel(userMain newUser)
        {
            var model = _mapper.Map<UserModel>(newUser);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetUser), new { newUser.Uid });
            return model;
        }*/
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

        

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetUsers), new { page, pageSize });
        }

        
    }
}
