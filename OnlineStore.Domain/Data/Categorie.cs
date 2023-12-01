using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Data
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
