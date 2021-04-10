using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class Cluster
    {
        public Cluster()
        {
            MummyInfos = new HashSet<MummyInfo>();
        }

        public int ClusterId { get; set; }
        public int QuadrantId { get; set; }
        public int? ClusterNum { get; set; }

        public virtual Quadrant Quadrant { get; set; }
        public virtual ICollection<MummyInfo> MummyInfos { get; set; }
    }
}
