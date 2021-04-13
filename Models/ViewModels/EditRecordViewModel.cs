using IntexFinalMummy.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexFinalMummy.Models.ViewModels
{
    public class EditRecordViewModel
    {
        public MummyInfo MummyInfos { get; set; }

        public C14sample C14Sample { get; set; }
        public Cluster Cluster { get; set; }
        public CraniumSample CraniumSample { get; set; }
        public Square Square { get; set; }

        public Sample Samples {get;set;}

        public Quadrant Quadrants { get; set; }

        public string InfoFromUrl { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        
        public SearchModel SearchModel { get; set; }
    }

}
