using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class C14sample
    {
        public int C14sampleId { get; set; }
        public int? MummyId { get; set; }
        public int? Tube { get; set; }
        public string C14description { get; set; }
        public int? Size { get; set; }
        public int? Foci { get; set; }
        public int? C14Sample2017 { get; set; }
        public string Location { get; set; }
        public string Questions { get; set; }
        public int? Conventional14CageBp { get; set; }
        public int? C14calendarDate { get; set; }
        public int? Calibrated95perCalendarDateMax { get; set; }
        public int? Calibrated95perCalendarDateMin { get; set; }
        public int? Calibrated95perCalendarDateSpan { get; set; }
        public int? Calibrated95perCalendarAvg { get; set; }
        public string Category { get; set; }
        public string Lab { get; set; }

        public virtual MummyInfo Mummy { get; set; }
    }
}
