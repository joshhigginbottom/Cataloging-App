using System;
using System.Collections.Generic;

namespace CataloguingAppApi.Data
{
    public partial class Collectable
    {
        public Collectable()
        {
            Images = new HashSet<Image>();
        }

        public int Hierarchynodeid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Pricepaid { get; set; }
        public decimal? Currentworth { get; set; }
        public string? Size { get; set; }

        public virtual Hierarchynode Hierarchynode { get; set; } = null!;
        public virtual ICollection<Image> Images { get; set; }
    }
}
