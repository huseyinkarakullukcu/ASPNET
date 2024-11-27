using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Models;
using BlogApp.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index","Posts");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var isUser = _userRepository.Users.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);
                if(isUser !=null)
                {
                    //claims user özellikerini taşımak için. Cokie içinde benzersiz rakamlarla saklanır
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.UserId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? "")); //nullable olduğunda boş gelirse ad "" ata
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                    if(isUser.Email == "huseyin@huseyin.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties{ //Beni hatırla
                        IsPersistent = true
                    };

                    //Daha önce cookie bilgisini sil
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                        );

                    return RedirectToAction("Index","Posts");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya şifre yanlış");
                }
            }
            
            return View(model);
        }

        public IActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
           if(ModelState.IsValid)
           {
                var user = await _userRepository.Users.FirstOrDefaultAsync(u=>u.UserName == model.UserName || u.Email == model.Email);
                if(user == null)
                {
                    _userRepository.CreateUser(
                        new User{
                            UserName = model.UserName,
                            Name = model.Name,
                            Email = model.Email,
                            Password = model.Password,
                            Image = "profile.png"
                        }
                    );
                    return RedirectToAction("Login");
                }
                else{
                    ModelState.AddModelError("","Username veya email kullanımda.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Profile(string username)
        {
            if(string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            var user = _userRepository
                                    .Users
                                    .Include(x=>x.Posts)
                                    .Include(c=>c.Comments)
                                    .ThenInclude(p=>p.Post)
                                    .FirstOrDefault(x=>x.UserName == username);
            
            if(user == null)
            {
                return NotFound();
            }
             return View(user);
        }
    }
}