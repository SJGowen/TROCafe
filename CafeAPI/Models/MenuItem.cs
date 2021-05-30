using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeAPI.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SKU { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
    }
}
