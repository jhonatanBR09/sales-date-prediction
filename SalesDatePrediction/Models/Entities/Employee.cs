using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.Models.Entities
{
    [Table("Employees", Schema = "HR")]
    public class Employee
    {
        [Key]
        [Column("empid")]
        public int EmpId { get; set; }

        [Column("lastname")]
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Column("firstname")]
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Column("title")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Column("titleofcourtesy")]
        [Required]
        [MaxLength(25)]
        public string TitleOfCourtesy { get; set; }

        [Column("birthdate")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Column("hiredate")]
        [Required]
        public DateTime HireDate { get; set; }

        [Column("address")]
        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        [Column("city")]
        [Required]
        [MaxLength(15)]
        public string City { get; set; }

        [Column("region")]
        [MaxLength(15)]
        public string? Region { get; set; }

        [Column("postalcode")]
        [MaxLength(10)]
        public string? PostalCode { get; set; }

        [Column("country")]
        [Required]
        [MaxLength(15)]
        public string Country { get; set; }

        [Column("phone")]
        [Required]
        [MaxLength(24)]
        public string Phone { get; set; }

        [Column("mgrid")]
        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Employee? Manager { get; set; }
    }
}
