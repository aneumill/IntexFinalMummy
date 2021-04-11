using IntexFinalMummy.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexFinalMummy.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<MummyInfo> MummyInfos { get; set; }
        public string InfoFromUrl { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        
        public SearchModel SearchModel { get; set; }
    }

}
