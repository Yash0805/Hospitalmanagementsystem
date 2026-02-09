using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class patientsViewModel
    {
            [Key]
            public int patient_id { get; set; }
            public required string? patient_name { get; set; }
            public required string gender { get; set; }
            public int age { get; set; }
            public required string phone { get; set; }
    }
}
