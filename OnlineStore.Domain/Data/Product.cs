using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public float UnitPrice { get; set; }

        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categorie Category { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
