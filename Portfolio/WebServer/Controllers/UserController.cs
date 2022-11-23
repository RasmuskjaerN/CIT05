using Microsoft.AspNetCore.Mvc;
using DataLayer;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = new UserService();
        [HttpPost("{tconst}")]
        public IActionResult CreateActorBookmark(string userid, string tconstmovie, string? usernote)
        {
            var bookmark = _userService.CreateActorBookmark(userid, tconstmovie, usernote);

            if (bookmark == null)
            {
                return NotFound();
            }
            var model = new UserBookmarkModel
            {
                Uid = bookmark.Uid,
                Tconst = bookmark.Tconst,
                Note = bookmark.Note
            };
           return Ok(model);

        }
    }
}
