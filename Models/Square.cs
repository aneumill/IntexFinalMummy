using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class Square
    {
        public Square()
        {
            Quadrants = new HashSet<Quadrant>();
        }

        public int SquareId { get; set; }
        public int? LowNs { get; set; }
        public int? HighNs { get; set; }
        public string NS { get; set; }
        public int? LowEw { get; set; }
        public int? HighEw { get; set; }
        public string EW { get; set; }

        public virtual ICollection<Quadrant> Quadrants { get; set; }
    }
}
