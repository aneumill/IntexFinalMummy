using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class Quadrant
    {
        public Quadrant()
        {
            Clusters = new HashSet<Cluster>();
            MummyInfos = new HashSet<MummyInfo>();
        }

        public int QuadrantId { get; set; }
        public int? SquareId { get; set; }
        public string QuadrantDirection { get; set; }

        public virtual Square Square { get; set; }
        public virtual ICollection<Cluster> Clusters { get; set; }
        public virtual ICollection<MummyInfo> MummyInfos { get; set; }
    }
}
