using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class CraniumSample
    {
        public int CraniumSampleId { get; set; }
        public int? MummyId { get; set; }
        public decimal? MaxCranialLength { get; set; }
        public decimal? MaxCranialBreadth { get; set; }
        public decimal? BasionBregmaHeight { get; set; }
        public decimal? BasionNasion { get; set; }
        public decimal? BasionProsthionLength { get; set; }
        public decimal? BizygomaticDiameter { get; set; }
        public decimal? NasionProsthion { get; set; }
        public decimal? MaxNasalBreadth { get; set; }
        public decimal? InterorbitalBreadth { get; set; }
        public string ShelfNum { get; set; }
        public int? RackNumEgypt { get; set; }
        public string GilesSex { get; set; }

        public virtual MummyInfo Mummy { get; set; }
    }
}
