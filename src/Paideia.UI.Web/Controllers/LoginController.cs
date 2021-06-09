using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string returnUrl,
          bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] LoginViewModel loginVM,
            [FromServices] ILoginAppService service)
        {
            if (!ModelState.IsValid) { return View(loginVM); }

            if (ModelState.IsValid)
            {
                var result = await service.Loggin(loginVM);
                if (result == true)
                {
                    return Json(true);
                }
            }
            return Json(false);
        }
        [HttpPost]
        public async Task<IActionResult> Recuperation([FromBody] LoginViewModel loginVM,
            [FromServices] ILoginAppService service)
        {
            var result = await service.Recuperation(loginVM);
            if (result == true)
            {
                return Json(true);
            }
            return Json(false);
        }
        [HttpGet]
        public IActionResult Reset([FromQuery] string email, [FromQuery] string token)
        { 
            var loginVM = new LoginViewModel
            {
                Email = email,
                Token = token
            };
            return View(loginVM);
        }       
        [HttpPost]
        public async Task<IActionResult> Reset(LoginViewModel loginVM,
            [FromServices] ILoginAppService service)
        {           
            if (loginVM.ConfirmPassword == loginVM.NewPassword)
            if (loginVM.Email != default && loginVM.Token != default)
            {              
                    var result = await service.ResetPassword(loginVM, loginVM.Email, loginVM.Token);
                    if (result == true)
                    {
                        return RedirectToAction("Index", "Login");
                    }                
            }
            return View(new { isSuccess = true });
        }
    }
}
