using System;
using System.Collections.Generic;

namespace CataloguingAppApi.Data
{
    public partial class Image
    {
        public int Id { get; set; }
        public int? Collectableid { get; set; }
        public string? Filename { get; set; }
        public byte[]? Data { get; set; }

        public virtual Collectable? Collectable { get; set; }
    }
}
