using System;
using System.Collections.Generic;

namespace CataloguingAppApi.Data
{
    public partial class Directory
    {
        public int Hierarchynodeid { get; set; }
        public string? Name { get; set; }

        public virtual Hierarchynode Hierarchynode { get; set; } = null!;
    }
}
