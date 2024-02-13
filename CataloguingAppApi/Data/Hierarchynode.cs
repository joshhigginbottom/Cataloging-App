using System;
using System.Collections.Generic;

namespace CataloguingAppApi.Data
{
    public partial class Hierarchynode
    {
        public Hierarchynode()
        {
            InverseParentNode = new HashSet<Hierarchynode>();
        }

        public int Id { get; set; }
        public int? ParentNodeId { get; set; }

        public virtual Hierarchynode? ParentNode { get; set; }
        public virtual Collectable? Collectable { get; set; }
        public virtual Directory? Directory { get; set; }
        public virtual ICollection<Hierarchynode> InverseParentNode { get; set; }
    }
}
