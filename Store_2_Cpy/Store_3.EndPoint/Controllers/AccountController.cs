using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.basketsService;
using Store_2.Application.Services;
using Store_2.Domain.Users;
using Store_3.EndPoint.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly EmailService _emailService;
        private readonly IBasketservice _basketservice;
        public AccountController(UserManager<User> userManager, SignInManager<User> SignInManager
    , IBasketservice basketservice)
        {
            _userManager = userManager;
            _SignInManager = SignInManager;
            _emailService = new EmailService();
            _basketservice = basketservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExternalLogin(string ReturnUrl)
        {

            string url = Url.Action("CallBack", "Account",
                new
                {
                    ReturnUrl
                });
            var Propertis = _SignInManager.ConfigureExternalAuthenticationProperties
                ("Google", url);
            return new ChallengeResult("Google", Propertis);

        }
        public IActionResult CallBack(string ReturnUrl)
        {
            var loginInfo = _SignInManager.GetExternalLoginInfoAsync().Result;
            string email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value;
            string username = loginInfo.Principal.FindFirst(ClaimTypes.GivenName)?.Value??null;
            var signin = _SignInManager.ExternalLoginSignInAsync("Google", loginInfo.ProviderKey
                , true, true).Result;
            if (signin.Succeeded)
            {
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect("");
                }
                return RedirectToAction("Index", "Home");
            }
            else if (signin.RequiresTwoFactor)
            {
                ///
            }
            var user = _userManager.FindByEmailAsync(email).Result;
            if(user == null)
            {
                User newuser = new User()
                {
                    Email = email,
                    UserName = username,
                    EmailConfirmed=true,
                };
                var resulr = _userManager.CreateAsync(newuser).Result;
                user=newuser;
            }
            var resultatlogin = _userManager.AddLoginAsync(user,loginInfo).Result;
            _SignInManager.SignInAsync(user, true).Wait();

            return Redirect("/");
        }
        public IActionResult Login(string returnurl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnurl,
            });
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.LoginWIthGoogle.Contains("LoginWIthGoogle"))
            {
                string url = Url.Action("CallBack", "Account",
                    new
                    {
                        model.ReturnUrl
                    });
                var Propertis = _SignInManager.ConfigureExternalAuthenticationProperties
                    ("Google", url);
                return new ChallengeResult("Google", Propertis);
            }

            var user = _userManager.FindByEmailAsync(model.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "User Not Found");
                return View(model);
            }
            _SignInManager.SignOutAsync();

            var result = _SignInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, true).Result;
            if (result.Succeeded)
            {
                transforbasketforuser(user.Id);
                return Redirect(model.ReturnUrl);
            }
            if (result.RequiresTwoFactor)
            {

            }
            return View(model);
        }
        public IActionResult LogOut()
        {
            _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User newUser = new User()
            {
                Email = model.Email,
                UserName = model.FullName,
            };
            var result = _userManager.CreateAsync(newUser, model.Password).Result;
            if (result.Succeeded)
            {
                //this is new
                var user = _userManager.FindByEmailAsync(newUser.Email).Result;
                transforbasketforuser(user.Id);
                _SignInManager.SignInAsync(user,true).Wait();
                //this is new

                var token = _userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
                string callbackurl = Url.Action("ConfrimEmail", "Account", new { UserId = newUser.Id, token = token }, protocol: Request.Scheme);

                string body = $"{newUser} please to verify your email click on this link<br/> <a href={callbackurl}> Link </a>";
                _emailService.Execute(newUser.Email, body, "Confrim Your Email");
                return RedirectToAction("Profile");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }

            return View(model);
        }
        public IActionResult ConfrimEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                return BadRequest();
            }
            var user = _userManager.FindByIdAsync(UserId).Result;
            if (user == null)
            {
                return BadRequest();
            }
            var result = _userManager.ConfirmEmailAsync(user, Token).Result;
            if (result.Succeeded)
            {
                RedirectToAction("Index", "Home");
            }
            else
            {
                //errors
            }
            return RedirectToAction("Login");
        }
        public IActionResult displayemail()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RequestChangePassword(string returnUrl = "/")
        {

            return View(new ChangePassworddViewModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public IActionResult RequestChangePassword(ChangePassworddViewModel request)
        {
            string erorr = "Email is not correct";


            var mail = _userManager.FindByEmailAsync(request.Email).Result;
            if (mail != null)
            {
                var Token = _userManager.GeneratePasswordResetTokenAsync(mail).Result;
                string callbackurl = Url.Action("NewPassword", "Account", new { Email = request.Email, token = Token }, protocol: Request.Scheme);
                string body = $"please to Change your Password click on this link<br/> <a href={callbackurl}> Link </a>";
                _emailService.Execute(request.Email, body, "Change passowrd");
                return RedirectToAction(nameof(displayemail));
            }
            else
            {
                return View(erorr);
            }

        }
        public IActionResult NewPassword(string email, string token)
        {
            return View(new NewPasswordViewModel
            {
                Email = email,
                Token = token
            });
        }
        [HttpPost]
        public IActionResult NewPassword(NewPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userManager.FindByEmailAsync(model.Email).Result;
            var newpass = _userManager.ResetPasswordAsync(user, model.Token, model.Password).Result;
            //var loginuser = _SignInManager.SignInAsync(user, true, model.Password);
            return View(newpass);
        }
        private void transforbasketforuser(string userid)
        {
            string cookieName = "BasketId";
            if (Request.Cookies.ContainsKey(cookieName))
            {
                var anonymouseid = Request.Cookies[cookieName];
                _basketservice.TransferBasket(anonymouseid, userid);
                Response.Cookies.Delete(cookieName);
            }
        }
    }
}
