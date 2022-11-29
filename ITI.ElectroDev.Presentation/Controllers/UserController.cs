using ITI.ElectroDev.Models;
using ITI.ElectroDev.Presentation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.ElectroDev.Presentation
{

    public class UserController : Controller
    {
        UserManager<User> UserManager;
        SignInManager<User> SignInManager;
        public UserController(UserManager<User> usermanager, SignInManager<User> signInManager)
        {
            UserManager = usermanager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {

            if (ModelState.IsValid == false)
            {

                return View();

            }
            else
            {
                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,

                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);

                    });
                    return View();

                }
                else
                    return RedirectToAction("SignIn", "User");

            }
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid==false)
            {
                return View();
            }
            else
            {
                User user = new User()
                {
                    UserName = model.UserName

                };
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password,model.RememberMe,false);

                if (result.Succeeded == false)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
        }
        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }
    }
}

    
