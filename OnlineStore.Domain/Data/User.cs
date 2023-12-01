using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CivilianId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Role { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> CreatedProducts { get; set; }
        public virtual ICollection<Order> ClerkOrders { get; set; }
        public virtual ICollection<Order> CustomerOrders { get; set; }
    }
}
