

namespace OnlineStore.Domain.DTO
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
    }
}
