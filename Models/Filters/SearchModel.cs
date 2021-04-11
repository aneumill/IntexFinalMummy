using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexFinalMummy.Models.Filters
{
    public class SearchModel
    {
        public string Gender { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public bool? Artifacts { get; set; } 
        //In Quadrant Table
        public string HeadDirection {get;set;}
        public int? YearDiscovered { get; set; }
        public int? BurialDepth { get; set; }
        
    }
}
