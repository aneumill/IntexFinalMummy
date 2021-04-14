using IntexFinalMummy.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexFinalMummy.Models.ViewModels
{
    public class IndexViewModel
    {
        //Index View Model that brings in all the tables I need
        public IEnumerable<MummyInfo> MummyInfos { get; set; }

        public IEnumerable<C14sample> C14Sample { get; set; }
        public IEnumerable<Cluster> Cluster { get; set; }
        public IEnumerable<CraniumSample> CraniumSample { get; set; }
        public IEnumerable<Square> Square { get; set; }

        public IEnumerable<Sample> Samples {get;set;}

        public IEnumerable<Quadrant> Quadrants { get; set; }

//Paging/Enpoint information that I need
        public string InfoFromUrl { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        
        public SearchModel SearchModel { get; set; }
    }

}
