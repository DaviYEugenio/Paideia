using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class ModelController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
            [FromServices] IModelAppService service,
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
          [FromServices] IModelAppService service)
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
        [HttpGet]
        public async Task<IActionResult> Action(Guid id,
            [FromServices] IModelAppService service,
            [FromServices] ITraningAppService traningAppService)
        {
            ViewBag.Treinamentos = await traningAppService.GetAll();
            if (id == default)
            {
                ViewBag.Action = "Cadastrar";
                return View();
            }
            else
            {
                ViewBag.Action = "Editar";
                var model = await service.GetById(id);
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Action(Guid Id,
            ModelViewModel modelViewModel,
             [FromServices] IModelAppService service)
        {            
            if (Id == default)
            {
                await service.Save(modelViewModel);
            }
            else
            {
                modelViewModel.Id = Id;
                await service.Update(modelViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
    }
}
