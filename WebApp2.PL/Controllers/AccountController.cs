using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp2.BLL.ModelVM.Account;
using WebApp2.DAL.Entity;

namespace WebApp2.PL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;
        
        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeVM resgiterEmployeeVm)
        {
            var user = new Employee(resgiterEmployeeVm.Name, 1,resgiterEmployeeVm.UserName, "ali");

            
            var result = await userManager.CreateAsync(user, resgiterEmployeeVm.Password);

            if (result.Succeeded)
            {
                // check if user has a role
                var hasRole = await userManager.IsInRoleAsync(user, resgiterEmployeeVm.RoleName);
                // if not, assign the role
                if (!hasRole)
                {
                    var resultRole = await userManager.AddToRoleAsync(user, resgiterEmployeeVm.RoleName);
                }

                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }
            return View(resgiterEmployeeVm);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginEmployeeVM loginEmployeeVM)
        {
            var result = await signInManager.PasswordSignInAsync(loginEmployeeVM.UserName, loginEmployeeVM.Password,true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName Or Password");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
