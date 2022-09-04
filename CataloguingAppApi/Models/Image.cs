#nullable disable

namespace CataloguingAppApi.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public int? Collectableid { get; set; }
        public string Filename { get; set; }
        public byte[] Data { get; set; }
    }
}
