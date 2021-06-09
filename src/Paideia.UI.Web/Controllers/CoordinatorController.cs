using Microsoft.AspNetCore.Mvc;
using Paideia.Application.Interfaces;
using Paideia.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class CoordinatorController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ICoordinatorAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;
                var coordinator = await service.Get();
                return View(coordinator);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
           [FromServices] ICoordinatorAppService service)
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
            [FromServices] ICoordinatorAppService service)
        {
            if (id == default)
            {
                ViewBag.Action = "Cadastrar";
                return View();
            }
            ViewBag.Action = "Editar";
            var coordinator = await service.GetById(id);
            return View(coordinator);
        }
        [HttpPost]
        public async Task<IActionResult> Action(Guid id,
            CoordinatorViewModel coordinatorViewModel,
             [FromServices] ICoordinatorAppService service)
        {
            if (id == default)
            {
                await service.Save(coordinatorViewModel);
            }
            else
            {
                coordinatorViewModel.Id = id;
                await service.Update(coordinatorViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
    }
}
