using System;
using System.Collections.Generic;

#nullable disable

namespace CataloguingAppApi.Models
{
    public partial class Collectable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Pricepaid { get; set; }
        public decimal? Currentworth { get; set; }
        public string Size { get; set; }
    }
}
