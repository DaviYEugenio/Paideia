using Microsoft.AspNetCore.Mvc;
using Paideia.Application.Interfaces;
using Paideia.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class DropoutsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
             [FromServices] IDropoutsAppService service,
            bool isSuccess = false)

        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;
                var dropouts = await service.Get();
                return View(dropouts);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
           [FromServices] IDropoutsAppService service)
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
        public async Task<IActionResult> Action(string name
            , Guid id,
            [FromServices] IDropoutsAppService service)
        {
            if (id == default)
            {
                ViewBag.Action = "Cadastrar";
                var result = await service.GetByName(name);
                return View(result);
            }
            ViewBag.Action = "Editar";
            var dropouts = await service.GetById(id);
            return View(dropouts);
        }
        [HttpPost]
        public async Task<IActionResult> Action(Guid id,
            DropoutsViewModel dropoutsViewModel,
             [FromServices] IDropoutsAppService service)
        {
            if (id == default)
            {
                await service.Save(dropoutsViewModel);
            }
            else
            {
                dropoutsViewModel.Id = id;
                await service.Update(dropoutsViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
    }
}
