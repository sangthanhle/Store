using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int ClerkId { get; set; }
        [ForeignKey("ClerkId")]
        public virtual User Clerk { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual User Customer { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

