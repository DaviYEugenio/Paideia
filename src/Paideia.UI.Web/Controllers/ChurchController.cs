using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class ChurchController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IChurchAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;
                var church = await service.Get();
                return View(church);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
           [FromServices] IChurchAppService service)
        {            
                await service.Remove(id);
                return Ok();            
        }
        [HttpGet]
        public async Task<IActionResult> GetByCep ([FromQuery]string cep,
            [FromServices] ICepAppService service)
        {
            var result =  await service.GetByCep(cep);
            return Json(result);
        }
       [HttpGet]
        public async Task<IActionResult> Action(Guid id,
            [FromServices] IChurchAppService service)
        {
            if (id == default)
            {
                ViewBag.Action = "Cadastrar";
                return View();
            }
            ViewBag.Action = "Editar";
            var church = await service.GetById(id);
            return View(church);
        }
        [HttpPost]
        public async Task<IActionResult> Action(Guid id,
            ChurchViewModel churchViewModel,
             [FromServices] IChurchAppService service)
        {
            if (id == default)
            {
                await service.Save(churchViewModel);
            }
            else
            {
                churchViewModel.Id = id;
                await service.Update(churchViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
    }
}
