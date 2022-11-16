using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = new UserService();
        [HttpPost("{uid}")]
        public IActionResult CreateActorBookmark(string userid, string tconstmovie, string? usernote)
        {
            var bookmark = _userService.CreateActorBookmark(userid, tconstmovie, usernote);

            if (bookmark == null)
            {
                return NotFound();
            }
            var model = new UserBookmarkModel
            {
                Url = "http//:localhost/5001/api/user" + bookmark.Uid,
                Tconst = bookmark.Tconst,
                //Nconst = bookmark.Nconst,
                Note = bookmark.Note
            };
        return Ok(model);
           

        }
    }
}
