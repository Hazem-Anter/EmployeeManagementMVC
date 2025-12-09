using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp2.BLL.ModelVM.Role;

namespace WebApp2.PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleVM roleVM)
        {
            try
            {
                var getRoleByName = await RoleManager.FindByNameAsync(roleVM.Name); //Admin
                if (getRoleByName is not { })
                {
                    var role = new IdentityRole() { Name = roleVM.Name };
                    var result = await RoleManager.CreateAsync(role);
                    return RedirectToAction("Index","Home");
                }


                return View(roleVM);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
