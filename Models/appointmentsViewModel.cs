using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models
{
    public class appointmentsViewModel
    {
        [Key]
        public int appointment_id { get; set; }
        public int patient_id { get; set; }
        public int doctor_id { get; set; }
        public DateOnly appointment_date { get; set; }
    }
}


