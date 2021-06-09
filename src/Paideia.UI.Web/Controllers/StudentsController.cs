using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.UI.Web.Controllers
{
    public class studentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
