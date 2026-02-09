using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Data
{
    public class patients
    {
        [Key]
        public int patient_id { get; set; }
        public required string patient_name { get; set; }
        public required string gender { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
    }
}
