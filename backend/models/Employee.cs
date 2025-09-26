using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalveyInsuranceGroup.Backend.Models
{
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int? employee_id { get; set; }

        //[Required]
        [MaxLength(100)]
        [Column("name")]
        public string? name { get; set; }

        [MaxLength(60)]
        [Column("title")]
        public string? title { get; set; }

        //[Required]
        [MaxLength(120)]
        [Column("email")]
        public string? email { get; set; }

        //[Required]
        [MaxLength(25)]
        [Column("phone")]
        public string? phone { get; set; } 

        //[Required]
        [Column("status")]
        public string? status { get; set; }

        //[Required]
        [Column("created_at")]
        public DateTime created_at { get; set; }

    }
}
