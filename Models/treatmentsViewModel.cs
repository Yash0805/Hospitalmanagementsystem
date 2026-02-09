using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class treatmentsViewModel
    {
        [Key]
        public int treatment_id { get; set; }
        public int patient_id { get; set; }
        public int doctor_id { get; set; }
        public string treatment_details { get; set; }
        public DateOnly treatment_date { get; set; }
        public decimal cost { get; set; }

    }
}



