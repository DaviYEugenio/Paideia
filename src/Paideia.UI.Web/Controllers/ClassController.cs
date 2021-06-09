using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class ClassController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
             [FromServices] IClassAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;
                var module = await service.Get();
                return View(module);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
          [FromServices] IClassAppService service)
        {
            try
            {
                await service.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        public async Task<IActionResult> Action(Guid Id,            
            [FromServices] IClassAppService service,
            [FromServices] ITraningAppService traningAppService)
        {
            ViewBag.Treinamentos = await traningAppService.GetAll();
            if (Id == default) {
                ViewBag.Action = "Cadastrar";
                return View();
            }
            else
            {
                ViewBag.Action = "Editar";
                var model = await service.GetById(Id);
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Action(Guid Id,
            ClassViewModel classViewModel,
             [FromServices] IClassAppService service)
        {
            if (Id == default)
            {
                await service.Save(classViewModel);
            }
            else
            {
                classViewModel.Id = Id;
                await service.Update(classViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
    }
}
