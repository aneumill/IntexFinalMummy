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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "User/Admin")]
        public IActionResult AddRecord()
        {
            return View();
        }

        public IActionResult KidsBop()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Policy="User/Admin")]
        public IActionResult AddRecord(MummyInfo newRecord)
        {
            if (newRecord.QuadrantId == null)
            {
                newRecord.QuadrantId = 123;
            }


            if (ModelState.IsValid == true)
            {
                _context.MummyInfos.Add(newRecord);
                _context.SaveChanges();

                return View("AddConfirmation", newRecord);
            }
            else
            {
                return View();
            }

        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRecord(MummyInfo passedMummyID)
        {
            IQueryable<MummyInfo> removingRecord = _context.MummyInfos.Where(p => p.MummyId == passedMummyID.MummyId);

            //loop to remove the record in the database
            foreach (var x in removingRecord)
            {
                _context.MummyInfos.Remove(x);
            }

            _context.SaveChanges();

            return View("DeleteConfirmation");
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

 

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize(Policy = "User/Admin")]
        public IActionResult EditRecord(long MummyID, long QuadrantID, long ClusterID)
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

     
        [HttpPost]
        [Authorize(Policy = "User/Admin")]
        public IActionResult EditRecord(EditRecordViewModel formsubmission)
        {

            int? compareId = 0;
            IQueryable<Quadrant> queryable = _context.Quadrants.Where(x => x.QuadrantId == formsubmission.Quadrants.QuadrantId);
            IQueryable<MummyInfo> queryableMummyInfo = _context.MummyInfos.Where(x => x.MummyId == formsubmission.MummyInfos.MummyId);
            IQueryable<Sample> queryableSamples = _context.Samples.Where(x => x.MummyId == formsubmission.Samples.MummyId);
            IQueryable<Quadrant> queryableQuadrants = _context.Quadrants.Where(x => x.QuadrantId == formsubmission.Quadrants.QuadrantId);
            IQueryable<Cluster> queryableClusters = _context.Clusters.Where(x => x.ClusterId == formsubmission.Cluster.ClusterId);
            IQueryable<CraniumSample> queryableCranium = _context.CraniumSamples.Where(x => x.MummyId == formsubmission.CraniumSample.MummyId);
            IQueryable<C14sample> queryableC14 = _context.C14samples.Where(x => x.MummyId == formsubmission.CraniumSample.MummyId);


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
                x.MummyId = formsubmission.MummyInfos.MummyId;
                x.AdultChild = formsubmission.MummyInfos.AdultChild;
                x.QuadrantId = formsubmission.MummyInfos.QuadrantId;
                x.ClusterId = formsubmission.MummyInfos.ClusterId;
                x.BurialNumber = formsubmission.MummyInfos.BurialNumber;
                x.Sex = formsubmission.MummyInfos.Sex;
                x.SexMethod = formsubmission.MummyInfos.SexMethod;
                x.MinAge = formsubmission.MummyInfos.MinAge;
                x.MaxAge = formsubmission.MummyInfos.MaxAge;
                x.HairColor = formsubmission.MummyInfos.HairColor;
                x.Sample = formsubmission.MummyInfos.Sample;
                x.YearDiscovered = formsubmission.MummyInfos.YearDiscovered;
                x.MonthDiscovered = formsubmission.MummyInfos.MonthDiscovered;
                x.DayDiscovered = formsubmission.MummyInfos.DayDiscovered;
                x.Artifacts = formsubmission.MummyInfos.Artifacts;
                x.ArtifactsDescription = formsubmission.MummyInfos.ArtifactsDescription;
                x.HairTaken = formsubmission.MummyInfos.HairTaken;
                x.SoftTissueTaken = formsubmission.MummyInfos.SoftTissueTaken;
                x.BoneTaken = formsubmission.MummyInfos.BoneTaken;
                x.ToothTaken = formsubmission.MummyInfos.ToothTaken;
                x.TextileTaken = formsubmission.MummyInfos.TextileTaken;
                x.MummyDescription = formsubmission.MummyInfos.MummyDescription;
                x.BurialDepth = formsubmission.MummyInfos.BurialDepth;
                x.ExtractedOrder = formsubmission.MummyInfos.ExtractedOrder;
                x.SouthToFeet = formsubmission.MummyInfos.SouthToFeet;
                x.SouthToHead = formsubmission.MummyInfos.SouthToHead;
                x.WestToHead = formsubmission.MummyInfos.WestToHead;
                x.WestToFeet = formsubmission.MummyInfos.WestToFeet;
                x.HeadDirection = formsubmission.MummyInfos.HeadDirection;
                x.FieldBookYear = formsubmission.MummyInfos.FieldBookYear;
                x.FieldBookPageNum = formsubmission.MummyInfos.FieldBookPageNum;
                x.PreservationDescription = formsubmission.MummyInfos.PreservationDescription;
                x.PreviouslySampled = formsubmission.MummyInfos.PreviouslySampled;
                x.BurialSituationNotes = formsubmission.MummyInfos.BurialSituationNotes;
                x.LengthOfRemains = formsubmission.MummyInfos.LengthOfRemains;
                x.SexGe = formsubmission.MummyInfos.SexGe;
                x.VentralArc = formsubmission.MummyInfos.VentralArc;
                x.SubponicAngle = formsubmission.MummyInfos.SubponicAngle;
                x.SciaticNotch = formsubmission.MummyInfos.SciaticNotch;
                x.PubicBone = formsubmission.MummyInfos.PubicBone;
                x.PreaurSulcus = formsubmission.MummyInfos.PreaurSulcus;
                x.MedialIpramus = formsubmission.MummyInfos.MedialIpramus;
                x.DorsalPitting = formsubmission.MummyInfos.DorsalPitting;
                x.FormanMagnum = formsubmission.MummyInfos.FormanMagnum;
                x.FemurHead = formsubmission.MummyInfos.FemurHead;
                x.HumerusHead = formsubmission.MummyInfos.HumerusHead;
                x.TibiaLength = formsubmission.MummyInfos.TibiaLength;
                x.Robust = formsubmission.MummyInfos.Robust;
                x.SupraorbitalRidges = formsubmission.MummyInfos.SupraorbitalRidges;
                x.OrbitEdge = formsubmission.MummyInfos.OrbitEdge;
                x.ParietalBossing = formsubmission.MummyInfos.ParietalBossing;
                x.Gonian = formsubmission.MummyInfos.Gonian;
                x.NuchalCrest = formsubmission.MummyInfos.NuchalCrest;
                x.ZygomaticCrest = formsubmission.MummyInfos.ZygomaticCrest;
                x.CranialSuture = formsubmission.MummyInfos.CranialSuture;
                x.CranialSuture = formsubmission.MummyInfos.CranialSuture;
                x.EstLivingStature = formsubmission.MummyInfos.EstLivingStature;
                x.ToothAttrition = formsubmission.MummyInfos.ToothAttrition;
                x.ToothEruption = formsubmission.MummyInfos.ToothEruption;
                x.PathalogyAnomaly = formsubmission.MummyInfos.PathalogyAnomaly;
                x.EpiphysealUnion = formsubmission.MummyInfos.EpiphysealUnion;
                x.ByuSample = formsubmission.MummyInfos.ByuSample;
                x.ToBeConfirmed = formsubmission.MummyInfos.ToBeConfirmed;
                x.SkullTrauma = formsubmission.MummyInfos.SkullAtMagazine;
                x.PostcraniaTrauma = formsubmission.MummyInfos.PostcraniaTrauma;
                x.ButtonOsteoma = formsubmission.MummyInfos.ButtonOsteoma;
                x.CibraOrbitala = formsubmission.MummyInfos.CibraOrbitala;
                x.PoroticHyperostosis = formsubmission.MummyInfos.PoroticHyperostosis;
                x.PoroticHyperostosisLocations = formsubmission.MummyInfos.PoroticHyperostosisLocations;
                x.MetopicSuture = formsubmission.MummyInfos.MetopicSuture;
                x.ButtonOsteoma = formsubmission.MummyInfos.ButtonOsteoma;
                x.OsteologyUnknownComment = formsubmission.MummyInfos.OsteologyUnknownComment;
                x.TemporalMandibularJointOsteoarthritis = formsubmission.MummyInfos.TemporalMandibularJointOsteoarthritis;
                x.LinearHypoplasiaEnamel = formsubmission.MummyInfos.LinearHypoplasiaEnamel;
                x.Area = formsubmission.MummyInfos.Area;
                x.Tomb = formsubmission.MummyInfos.Tomb;
                x.FaceBundle = formsubmission.MummyInfos.FaceBundle;
                x.BodyAnalysisYear = formsubmission.MummyInfos.BodyAnalysisYear;
                x.SkullAtMagazine = formsubmission.MummyInfos.SkullAtMagazine;
                x.PostcraniaAtMagazine = formsubmission.MummyInfos.PostcraniaAtMagazine;
                x.DataEntryExpert = formsubmission.MummyInfos.DataEntryExpert;
                x.DataEntryChecker = formsubmission.MummyInfos.DataEntryChecker;
                x.OsteologyNotes = formsubmission.MummyInfos.OsteologyNotes;
               
            }
            _context.SaveChanges();

            foreach (var x in queryableSamples)
            {
                //x.SampleId = formsubmission.Samples.SampleId;
                x.MummyId = formsubmission.Samples.MummyId;
                x.SampleYear = formsubmission.Samples.SampleYear;
                x.SampleNotes = formsubmission.Samples.SampleNotes;
                x.BagNum = formsubmission.Samples.BagNum;
                x.RackNumByu = formsubmission.Samples.RackNumByu;
                x.Initial = formsubmission.Samples.Initial;
    }
           
            foreach (var x in queryableQuadrants)
            {
                x.QuadrantId = formsubmission.Quadrants.QuadrantId;
                x.SquareId = formsubmission.Quadrants.SquareId;
                x.QuadrantDirection = formsubmission.Quadrants.QuadrantDirection;
    }
           
            foreach (var x in queryableClusters)
            {
                x.ClusterId = formsubmission.Cluster.ClusterId;
                x.QuadrantId = formsubmission.Cluster.QuadrantId;
                x.ClusterNum = formsubmission.Cluster.ClusterNum;
    }
            
            foreach (var x in queryableCranium)
            {
                x.CraniumSampleId = formsubmission.CraniumSample.CraniumSampleId;
                x.MummyId = formsubmission.CraniumSample.MummyId;
                x.MaxCranialLength = formsubmission.CraniumSample.MaxCranialLength;
                x.MaxCranialBreadth = formsubmission.CraniumSample.MaxCranialBreadth;
                x.BasionBregmaHeight = formsubmission.CraniumSample.BasionBregmaHeight;
                x.BasionNasion = formsubmission.CraniumSample.BasionNasion;
                x.BasionProsthionLength = formsubmission.CraniumSample.BasionProsthionLength;
                x.BizygomaticDiameter = formsubmission.CraniumSample.BizygomaticDiameter;
                x.NasionProsthion = formsubmission.CraniumSample.NasionProsthion;
                x.MaxNasalBreadth = formsubmission.CraniumSample.MaxNasalBreadth;
                x.InterorbitalBreadth = formsubmission.CraniumSample.InterorbitalBreadth;
                x.ShelfNum = formsubmission.CraniumSample.ShelfNum;
                x.RackNumEgypt = formsubmission.CraniumSample.RackNumEgypt;
                x.GilesSex = formsubmission.CraniumSample.GilesSex;
    }

            foreach (var x in queryableSquare)
            {
                //x.SquareId = formsubmission.Square.SquareId;
                x.LowNs = formsubmission.Square.LowNs;
                x.HighNs = formsubmission.Square.HighNs;
                x.NS = formsubmission.Square.NS;
                x.LowEw = formsubmission.Square.LowEw;
                x.HighEw = formsubmission.Square.HighEw;
                x.EW = formsubmission.Square.EW;
    }
            
            foreach (var x in queryableC14)
            {
                //x.C14sampleId = formsubmission.C14Sample.C14sampleId;
                x.MummyId = formsubmission.C14Sample.MummyId;
                x.Tube = formsubmission.C14Sample.Tube;
                x.C14description = formsubmission.C14Sample.C14description;
                x.Size = formsubmission.C14Sample.Size;
                x.Foci = formsubmission.C14Sample.Foci;
                x.C14Sample2017 = formsubmission.C14Sample.C14Sample2017;
                x.Location = formsubmission.C14Sample.Location;
                x.Questions = formsubmission.C14Sample.Questions;
                x.Conventional14CageBp = formsubmission.C14Sample.Conventional14CageBp;
                x.C14calendarDate = formsubmission.C14Sample.C14calendarDate;
                x.Calibrated95perCalendarDateMax = formsubmission.C14Sample.Calibrated95perCalendarDateMax;
                x.Calibrated95perCalendarDateMin = formsubmission.C14Sample.Calibrated95perCalendarDateMin;
                x.Calibrated95perCalendarDateSpan = formsubmission.C14Sample.Calibrated95perCalendarDateSpan;
                x.Calibrated95perCalendarAvg = formsubmission.C14Sample.Calibrated95perCalendarAvg;
                x.Category = formsubmission.C14Sample.Category;
                x.Lab = formsubmission.C14Sample.Lab;
            }


            


            return View("EditConfirmation", formsubmission.MummyInfos);
        }

    }


}
