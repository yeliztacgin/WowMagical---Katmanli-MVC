using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WowMagical.Business.Dtos;
using WowMagical.Business.Services;
using WowMagical.WebUI.Models;

namespace WowMagical.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("KayitOl")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("KayitOl")]
        public IActionResult Register(RegisterViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var addUserDto = new AddUserDto()
            {
                Email = formData.Email.Trim(),
                FirstName = formData.FirstName.Trim(),
                LastName = formData.LastName.Trim(),
                Password = formData.Password.Trim()
            };

            var result = _userService.AddUser(addUserDto);

            if (result.IsSucceed)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = result.Message;
                return View(formData);
            }

        }

        public async Task<IActionResult> login(LoginViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var loginDto = new LoginDto
            {
                Email = formData.Email,
                Password = formData.Password
            };

            var userInfo = _userService.LoginUser(loginDto);

            if (userInfo is null)
            {
                return RedirectToAction("Index", "Home");

            }


            var claims = new List<Claim>();

            claims.Add(new Claim("id", userInfo.Id.ToString()));
            claims.Add(new Claim("email", userInfo.Email));
            claims.Add(new Claim("firstName", userInfo.FirstName));
            claims.Add(new Claim("lastName", userInfo.LastName));
            claims.Add(new Claim("userType", userInfo.UserType.ToString()));


            claims.Add(new Claim(ClaimTypes.Role, userInfo.UserType.ToString()));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48))
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

    

