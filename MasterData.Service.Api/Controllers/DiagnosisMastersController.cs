using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Controllers
{
    public class DiagnosisMastersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
