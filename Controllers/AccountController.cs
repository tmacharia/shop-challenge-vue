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
                return BadRequest(GetModelValidationErrorsAsArray());

            if (!model.Email.IsEmailValid())
            {
                ModelState.AddModelError("Email", "Incorrect email format");
                return BadRequest(GetModelValidationErrorsAsArray());
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("User", "User does not exist.");
                return BadRequest(GetModelValidationErrorsAsArray());
            }
            else
            {
                var res = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (res.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("User", "Incorrect email/password combination.");
                    return BadRequest(GetModelValidationErrorsAsArray());
                }
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelValidationErrorsAsArray());

            if(!model.Email.IsEmailValid())
            {
                ModelState.AddModelError("Email", "Incorrect email format");
                return BadRequest(GetModelValidationErrorsAsArray());
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
                return BadRequest(GetModelValidationErrorsAsArray());
            }
        }
        [HttpGet("status")]
        public IActionResult GetUserSignInStatus()
        {
            var user_status = new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name
            };

            return Ok(user_status);
        }

        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            // sign the current user out of the application and redirect them 
            // to the main page.
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        private string[] GetModelValidationErrorsAsArray()
        {
            if (!ModelState.IsValid)
            {
                return ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray();
            }
            return new string[0];
        }
    }
}