using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models
{
    public class prescriptionsViewModel
    {
        [Key]
        public int prescription_id { get; set; }
        public int patient_id { get; set; }
        public int doctor_id { get; set; }
        public int medicine_id { get; set; }
        public string dosage { get; set; }
    }
}
