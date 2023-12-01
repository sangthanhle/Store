using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Data
{
    public class StockEvent
    {
        [Key]
        public int Id { get; set; }

        public int StockId { get; set; }
        [ForeignKey("StockId")]
        public virtual Stock Stock { get; set; }

        public int Type { get; set; }

        public string Reason { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
