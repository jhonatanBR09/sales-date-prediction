using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.Models.Entities
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrderDetail
    {
        [Key, Column("orderid", Order = 0)]
        public int OrderId { get; set; }

        [Key, Column("productid", Order = 1)]
        public int ProductId { get; set; }

        [Column("unitprice", TypeName = "money")]
        [Required]
        public decimal UnitPrice { get; set; } = 0; 

        [Column("qty")]
        [Required]
        public short Quantity { get; set; } = 1; 

        [Column("discount", TypeName = "numeric(4, 3)")]
        [Required]
        public decimal Discount { get; set; } = 0;

    }
}
