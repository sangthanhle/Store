using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.DTO
{
    public class StockEventDTO
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public StockEventType Type { get; set; }
        public string Reason { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }   
    }
    public enum StockEventType
    {
        In = 1,
        Out = 2
    }
}
