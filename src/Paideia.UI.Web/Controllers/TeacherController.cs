using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class TeacherController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
             [FromServices] ITeacherAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;
                var teacher = await service.Get();
                return View(teacher);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id,
          [FromServices] ITeacherAppService service,
          [FromServices] ITeacherDisciplinesAppService teacherDisciplinesAppService)
        {
                await teacherDisciplinesAppService.Remove(id);
                await service.Remove(id);
                return Json(true);            
        }
        public async Task<IActionResult> Action(Guid Id,
            [FromServices] ITeacherAppService service,
            [FromServices] IDisciplineAppService disciplineAppService,
            [FromServices] IModelAppService modelAppService,
            [FromServices] ITraningAppService traningAppService)
        {
            var resultTraining = await traningAppService.GetAll();
            ViewBag.Treinamentos = resultTraining;
            ViewBag.Modulos = await modelAppService.GetByTrainingId(resultTraining.FirstOrDefault().Id);
            var resultModelTraining = await modelAppService.Get();
            ViewBag.Disciplinas = await disciplineAppService.GetByTrainingModelId(resultModelTraining.FirstOrDefault().Id);            
            if (Id == default)
            {
            ViewBag.Action = "Cadastrar";
            return View();
            }
            else
            {
                var disciplineIds = new List<Guid>();
                var result = await service.GetById(Id);
                foreach(var item in result.Disciplines)
                {
                    disciplineIds.Add(item.DisciplineId);
                }             
                ViewBag.DisciplineIds = JsonConvert.SerializeObject(disciplineIds);
                ViewBag.Teacher = await service.GetById(Id);
                ViewBag.Action = "Editar";
                var model = await service.GetById(Id);                
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Action([FromBody]TeacherViewModel teacherViewModel,
             [FromServices] ITeacherAppService service)
        {
            if (teacherViewModel.Id == "")
            {                
                   await service.Save(teacherViewModel);
                   return Json(true);
            }
            else
            {            
                await service.Update(teacherViewModel);
                return Json(true);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetByTraining([FromQuery] string trainingId,
            [FromServices] IModelAppService serviceAppService)
        {
            var result = await serviceAppService.GetByTrainingId(new Guid(trainingId));
           return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByTrainingModel([FromQuery] string trainingModelId,
            [FromServices] IDisciplineAppService serviceAppService)
        {
            var result = await serviceAppService.GetByTrainingModelId(new Guid(trainingModelId));
            return Json(result);
        }
    }
}
