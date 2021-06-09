using Microsoft.AspNetCore.Mvc;
using Paideia.Application;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class CandidateController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string id, 
            [FromServices] ICandidateAppService service,
            bool isSuccess = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsSuccess = isSuccess;                
                var response = await service.GetByIdStatus(id);
                ViewBag.StatusId = response;            
                return View(response);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public  IActionResult GetByIdStatus(CandidateViewModel candidateViewModel, [FromServices] ICandidateAppService service)
        {
            return RedirectToAction("Index", "Candidate", new {id = candidateViewModel.Status });  
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery]DropoutsViewModel dropoutsViewModel, 
            Guid id,
           [FromServices] ICandidateAppService service)
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
            [FromServices] ICandidateAppService service,
            [FromServices] ITraningAppService traningAppService)
        {            
            ViewBag.Treinamentos = await traningAppService.GetAll();
            if (id == default)
            {
                ViewBag.Action = "Cadastrar";
                return View();
            }
            ViewBag.Action = "Editar";
            var candidate = await service.GetById(id);
            return View(candidate);
        }
        [HttpPost]
        public async Task<IActionResult> Action(Guid id,
            CandidateViewModel candidateViewModel,
             [FromServices] ICandidateAppService service)
        {
            if (id == default)
            {
                var result = await service.Save(candidateViewModel);
                if (result == true)
                {
                    return RedirectToAction("Index", new { isSuccess = true });
                }
                else
                {
                    return RedirectToAction("Action", new { isSuccess = true });
                }
            }
            else
            {
                candidateViewModel.Id = id;
                await service.Update(candidateViewModel);
                return RedirectToAction("Index", new { isSuccess = true });
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Summon( Guid id,
            [FromServices] ICandidateAppService service)
        {
            await service.UpdateStatus(id);
            return RedirectToAction("Index","Candidate");
        }
    }
}
