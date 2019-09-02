using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.ViewModels;

namespace Shop.Web.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelStateErrors());

            if (!model.Email.IsEmailValid())
            {
                ModelState.AddModelError("Email", "Incorrect email format");
                return BadRequest(GetModelStateErrors());
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("User", "User does not exist.");
                return BadRequest(GetModelStateErrors());
            }
            else
            {
                var res = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (res.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("User", "Incorrect email/password combination.");
                    return BadRequest(GetModelStateErrors());
                }
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelStateErrors());

            if(!model.Email.IsEmailValid())
            {
                ModelState.AddModelError("Email", "Incorrect email format");
                return BadRequest(GetModelStateErrors());
            }

            var user = new IdentityUser() { Email = model.Email, UserName = model.Email.Split("@")[0] };

            var res = await _userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                return Ok();
            }
            else
            {
                res.Errors.ForEach(error =>
                {
                    ModelState.AddModelError(error.Code, error.Description);
                });
                return BadRequest(GetModelStateErrors());
            }
        }
        [HttpGet("status")]
        public IActionResult Status()
        {
            var user_status = new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name
            };

            return Ok(user_status);
        }
        private string[] GetModelStateErrors()
        {
            if (!ModelState.IsValid)
            {
                return ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray();
            }
            return new string[0];
        }
    }
}