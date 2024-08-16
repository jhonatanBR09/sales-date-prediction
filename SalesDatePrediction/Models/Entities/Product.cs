using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.Models.Entities
{
    [Table("Products", Schema = "Production")]
    public class Product
    {
        [Key]
        [Column("productid")]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("productname")]
        public string ProductName { get; set; }

        [Required]
        [Column("supplierid")]
        public int SupplierId { get; set; }

        [Required]
        [Column("categoryid")]
        public int CategoryId { get; set; }

        [Required]
        [Column("unitprice", TypeName = "money")]
        [Range(0, double.MaxValue, ErrorMessage = "UnitPrice must be a positive value.")]
        public decimal UnitPrice { get; set; } = 0;

        [Required]
        [Column("discontinued")]
        public bool Discontinued { get; set; } = false;
    }
}
