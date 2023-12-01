using OnlineStore.Domain.Data;

namespace OnlineStore.Cms.ViewModel
{
    public class ProductsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public float UnitPrice { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; } 
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
