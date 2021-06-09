using Paideia.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace Paideia.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IUserAppService service,
            bool isSuccess = false)
        {            
            var result = await service.GetAll();
            ViewBag.IsSuccess = isSuccess;
            return View(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(AccountViewModel registroVM,
           [FromServices] IUserAppService service)
        {
            try
            {
                await service.Remove(registroVM.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Action(AccountViewModel registroVM,
            [FromServices] IUserAppService service)
        {
            if(registroVM.Id == default)
            {
                ViewBag.Action = "Criar contra";
                return View();
            }
            ViewBag.Action = "Editar";            
            var ok = await service.GetById(registroVM.Id);
            return View(ok);         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Action(Guid Id, 
            AccountViewModel registroVM, 
            [FromServices] IUserAppService service)
        {
            if (registroVM.Id == default)
            {
                var result = await service.Register(registroVM);
                if (result == true)
                {
                    await service.GetAll();
                    return RedirectToAction("Index", "Login", new { isSuccess = true });
                }
            }
            else
            {
                await service.Update(registroVM);
                return RedirectToAction("Index", "Account", new { isSuccess = true });
            }
            return View(registroVM);
        }        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout([FromServices] IUserAppService service)
        {
            await service.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}

