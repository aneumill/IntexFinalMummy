using IntexFinalMummy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IntexFinalMummy.Models.ViewModels;

namespace IntexFinalMummy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IntexMummyVaultContext _context { get; set; }
 
        public HomeController(ILogger<HomeController> logger, IntexMummyVaultContext con)
        {
            _logger = logger;
            _context = con;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRecords()
        {
            return View(new IndexViewModel
            {
                MummyInfos = _context.MummyInfos

            });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
