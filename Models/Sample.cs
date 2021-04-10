using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class Sample
    {
        public int SampleId { get; set; }
        public int? MummyId { get; set; }
        public int? SampleYear { get; set; }
        public string SampleNotes { get; set; }
        public int? BagNum { get; set; }
        public int? RackNumByu { get; set; }
        public string Initial { get; set; }

        public virtual MummyInfo Mummy { get; set; }
    }
}
