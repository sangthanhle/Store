using OnlineStore.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string Thumbnail { get; set; } 
        public float UnitPrice { get; set; } 
        public int CreatedById { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public int CategoryId { get; set; } 
        public bool IsDeleted { get; set; } 
    }
}

