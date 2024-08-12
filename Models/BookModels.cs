using System.ComponentModel.DataAnnotations;

namespace bookstore_management_api.Models
{
    public class BookModels
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public long Price { get; set; }
        public long StockQuantity { get; set; }
    }
}
