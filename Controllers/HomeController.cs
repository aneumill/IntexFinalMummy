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

        public MummyInfo mummyInfoEmpty;
        public Sample mummySampleDataEmpty;
        public Quadrant mummyQuadrantDataEmpty;
        public Cluster mummyClusterDataEmpty;
        public CraniumSample mummyCraniumDataEmpty;
        public Square mummySquareDataEmpty;
        public C14sample mummyC13Empty;

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
        [HttpGet]
        public IActionResult ViewIndividualRecord(long MummyID, long QuadrantID, long ClusterID)
        {
            int? compareId = 0;
            IQueryable<Quadrant> queryable = _context.Quadrants.Where(x => x.QuadrantId == QuadrantID);
            IQueryable<MummyInfo> queryableMummyInfo = _context.MummyInfos.Where(x => x.MummyId == MummyID);
            IQueryable<Sample> queryableSamples = _context.Samples.Where(x => x.MummyId == MummyID);
            IQueryable<Quadrant> queryableQuadrants = _context.Quadrants.Where(x => x.QuadrantId == QuadrantID);
            IQueryable<Cluster> queryableClusters = _context.Clusters.Where(x => x.ClusterId == ClusterID);
            IQueryable<CraniumSample> queryableCranium = _context.CraniumSamples.Where(x => x.MummyId == MummyID);
            IQueryable<C14sample> queryableC14 = _context.C14samples.Where(x => x.MummyId == MummyID);


            foreach (var x in queryable)
            {
                compareId = x.SquareId;
            }

            IQueryable<Square> queryableSquare = _context.Squares.Where(x => x.SquareId == compareId);

            MummyInfo mummyInfoData = mummyInfoEmpty;
            Sample mummySampleData = mummySampleDataEmpty;
            Quadrant mummyQuadrantData = mummyQuadrantDataEmpty;
            Cluster mummyClusterData = mummyClusterDataEmpty;
            CraniumSample mummyCraniumData = mummyCraniumDataEmpty;
            Square mummySquareData = mummySquareDataEmpty;
            C14sample mummyC14 = mummyC13Empty;




            foreach (var x in queryableMummyInfo)
            {
                mummyInfoData = x;
            }

            foreach (var x in queryableSamples)
            {
                mummySampleData = x;
            }

            foreach (var x in queryableQuadrants)
            {
                mummyQuadrantData = x;
            }

            foreach (var x in queryableClusters)
            {
                mummyClusterData = x;
            }

            foreach (var x in queryableCranium)
            {
                mummyCraniumData = x;
            }

            foreach (var x in queryableSquare)
            {
                mummySquareData = x;
            }

            foreach (var x in queryableC14)
            {
                mummyC14 = x;
            }



            return View(new EditRecordViewModel
            {
                // MummyInfos = mummyInfoData
                // Samples = _context.Samples
                // .Where(x => x.MummyId == MummyID),
                // Quadrants = _context.Quadrants
                // .Where(x => x.QuadrantId == QuadrantID),
                // Cluster = _context.Clusters
                // .Where(x => x.ClusterId == ClusterID),
                // C14Sample = _context.C14samples
                // .Where(x => x.MummyId == MummyID),
                // CraniumSample = _context.CraniumSamples
                // .Where(x => x.MummyId == MummyID),
                // Square = _context.Squares
                //.Where(x => x.SquareId == compareId)

                MummyInfos = mummyInfoData,
                Samples = mummySampleData,
                Quadrants = mummyQuadrantData,
                Cluster = mummyClusterData,
                CraniumSample = mummyCraniumData,
                Square = mummySquareData,
                C14Sample = mummyC14






            });
        }

 

        [HttpGet]
        public IActionResult EditRecord(long MummyID, long QuadrantID, long ClusterID, MummyInfo editedRecordInfo)
        {
            int? compareId = 0;
            IQueryable<Quadrant> queryable = _context.Quadrants.Where(x => x.QuadrantId == QuadrantID);
            IQueryable<MummyInfo> queryableMummyInfo = _context.MummyInfos.Where(x => x.MummyId == MummyID);
            IQueryable<Sample> queryableSamples = _context.Samples.Where(x => x.MummyId == MummyID);
            IQueryable<Quadrant> queryableQuadrants = _context.Quadrants.Where(x => x.QuadrantId == QuadrantID);
            IQueryable<Cluster> queryableClusters = _context.Clusters.Where(x => x.ClusterId == ClusterID);
            IQueryable<CraniumSample> queryableCranium = _context.CraniumSamples.Where(x => x.MummyId == MummyID);
            IQueryable<C14sample> queryableC14 = _context.C14samples.Where(x => x.MummyId == MummyID);


            foreach (var x in queryable)
            {
                compareId = x.SquareId;
            }

            IQueryable<Square> queryableSquare = _context.Squares.Where(x => x.SquareId == compareId);

            MummyInfo mummyInfoData = mummyInfoEmpty;
            Sample mummySampleData = mummySampleDataEmpty;
            Quadrant mummyQuadrantData = mummyQuadrantDataEmpty;
            Cluster mummyClusterData = mummyClusterDataEmpty;
            CraniumSample mummyCraniumData = mummyCraniumDataEmpty;
            Square mummySquareData = mummySquareDataEmpty;
            C14sample mummyC14 = mummyC13Empty;




            foreach (var x in queryableMummyInfo)
            {
                mummyInfoData = x;
            }

            foreach (var x in queryableSamples)
            {
                mummySampleData = x;
            }
            
            foreach (var x in queryableQuadrants)
            {
                mummyQuadrantData = x;
            }

            foreach (var x in queryableClusters)
            {
                mummyClusterData = x;
            }

            foreach (var x in queryableCranium)
            {
                mummyCraniumData = x;
            }

            foreach (var x in queryableSquare)
            {
                mummySquareData = x;
            }

            foreach (var x in queryableC14)
            {
                mummyC14 = x;
            }



            return View(new EditRecordViewModel
            {
             
                MummyInfos = mummyInfoData,
                Samples = mummySampleData,
                Quadrants = mummyQuadrantData,
                Cluster = mummyClusterData,
                CraniumSample = mummyCraniumData,
                Square = mummySquareData,
                C14Sample = mummyC14




            });
        }

      //  [HttpPost]
      //public IActionResult EditRecord(EditRecordViewModel formsubmission)
      //  {




      //      return View()
      //  }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
