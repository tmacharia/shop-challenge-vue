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
        public async Task<IActionResult> Login(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("User", "User does not exist.");
                return BadRequest(ModelState);
            }
            else
            {
                var res = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (res.Succeeded)
                {
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("User", "Incorrect email/password combination.");
                    return BadRequest(ModelState);
                }
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
                return BadRequest(ModelState);
            }
        }
    }
}