using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.Models.Entities
{
    [Table("Customers", Schema = "Sales")]
    public class Customer
    {
        [Key]
        [Column("custid")]
        public int CustId { get; set; }

        [Column("companyname")]
        public string CompanyName { get; set; }

        [Column("contactname")]
        public string ContactName { get; set; }

        [Column("contacttitle")]
        public string ContactTitle { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("region")]
        public string? Region { get; set; } 

        [Column("postalcode")]
        public string? PostalCode { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("fax")]
        public string? Fax { get; set; }
    }
}
