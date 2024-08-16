using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.Models.Entities
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
        [Key]
        [Column("shipperid")]
        public int ShipperId { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("companyname")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(24)]
        [Column("phone")]
        public string Phone { get; set; }
    }
}
