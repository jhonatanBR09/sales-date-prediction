using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.Models.Entities
{
    [Table("Orders", Schema = "Sales")]
    public class Order
    {
        [Key]
        [Column("orderid")]
        public int orderid { get; set; }

        [Column("custid")]
        public int CustomerId { get; set; }

        [Column("empid")]
        [Required]
        public int EmployeeId { get; set; }

        [Column("orderdate")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Column("requireddate")]
        [Required]
        public DateTime RequiredDate { get; set; }

        [Column("shippeddate")]
        public DateTime? ShippedDate { get; set; }

        [Column("shipperid")]
        [Required]
        public int ShipperId { get; set; }

        [Column("freight")]
        [Required]
        public decimal Freight { get; set; }

        [Column("shipname")]
        [Required]
        [MaxLength(40)]
        public string ShipName { get; set; }

        [Column("shipaddress")]
        [Required]
        [MaxLength(60)]
        public string ShipAddress { get; set; }

        [Column("shipcity")]
        [Required]
        [MaxLength(15)]
        public string ShipCity { get; set; }

        [Column("shipregion")]
        [MaxLength(15)]
        public string? ShipRegion { get; set; }

        [Column("shippostalcode")]
        [MaxLength(10)]
        public string? ShipPostalCode { get; set; }

        [Column("shipcountry")]
        [Required]
        [MaxLength(15)]
        public string ShipCountry { get; set; }
    }
}
