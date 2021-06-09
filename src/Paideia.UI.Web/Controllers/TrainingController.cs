using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using Paideia.Application.Interfaces;
using Paideia.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class TrainingController : Controller
    {        
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ITraningAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                var training = await service.GetAll();
                ViewBag.IsSuccess = isSuccess;
                return View(training);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
           [FromServices] ITraningAppService service)
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
            [FromServices] ITraningAppService service,
            [FromServices] ICoordinatorAppService Coservice)
        {
            ViewBag.Coordinator = await Coservice.Get();
            if (id == default)
            {
                ViewBag.Action = "Cadastrar";
                return View();
            }
            ViewBag.Action = "Editar";
            var training = await service.GetById(id);
            return View(training);
            }         
        [HttpPost]
        public async Task<IActionResult> Action(Guid id,
            TrainingViewModel trainingViewModel,
             [FromServices] ITraningAppService service)
        {
            if (!ModelState.IsValid) { return View(); }
            if (id == default)
            {
                await service.Add(trainingViewModel);
            }
            else
            {
                trainingViewModel.Id = id;
                await service.Update(trainingViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
    }
}

