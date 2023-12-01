using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClerkId { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
