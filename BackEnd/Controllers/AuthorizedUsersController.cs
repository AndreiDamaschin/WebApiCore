using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizedUsersController : ControllerBase
    {
        [Route("Login")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Route("Role")]
        [Authorize(Roles = "admin", AuthenticationSchemes = "Bearer")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }
    }
}