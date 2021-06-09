using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class DisciplineController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
             [FromServices] IDisciplineAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;
                var discipline = await service.Get();
                return View(discipline);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
          [FromServices] IDisciplineAppService service)
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
            [FromServices] IDisciplineAppService service,
            [FromServices] IModelAppService serviceAppService,
            [FromServices] ITraningAppService traningAppService)
        {              
            var resultTraining= await traningAppService.GetAll();
            ViewBag.Modulos = await serviceAppService.GetByTrainingId(resultTraining.FirstOrDefault().Id);
            ViewBag.Treinamentos = resultTraining;
            if (Id == default)
            {
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
            DisciplineViewModel disciplineViewModel,
             [FromServices] IDisciplineAppService service)
        {
            if (Id == default)
            {
                await service.Save(disciplineViewModel);
            }
            else
            {
                disciplineViewModel.Id = Id;
                await service.Update(disciplineViewModel);
            }
            return RedirectToAction("Index", new { isSuccess = true });
        }
        [HttpGet]
        public async Task<IActionResult> GetByTraining([FromQuery]string trainingId,
            [FromServices] IModelAppService serviceAppService)
        {
            var result =  await serviceAppService.GetByTrainingId(new Guid(trainingId));
            return Json(result);
        }
    }
}

