using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeAPI.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SKU { get; set; }

        // Don't want to do this but I am having problems joining to MenuItem.Cost
        public decimal Cost { get; set; }
    }
}
