using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Data
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        public int Order { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public string Path { get; set; }
    }
}
