using IntexFinalMummy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IntexFinalMummy.Models.ViewModels;
using IntexFinalMummy.Models.Filters;

namespace IntexFinalMummy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IntexMummyVaultContext _context { get; set; }

        private int pageSize = 25;
 
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

        [HttpGet]
        public IActionResult ViewRecords(SearchModel? searchmodel, int PageNum = 1)
        {
            var LogicForSearch = new SearchLogic(_context);
            var mummyqueryable = LogicForSearch.GetRecords(searchmodel);

            return View(new IndexViewModel
            {
                MummyInfos = (mummyqueryable
                    .Skip((PageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),



                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = PageNum,
                    TotalNumItems = (mummyqueryable.Count())
                },



                SearchModel = searchmodel,



                InfoFromUrl = Request.QueryString.Value

            });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
