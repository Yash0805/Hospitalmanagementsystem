using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Data
{
    public class prescriptions
    {
        [Key]
        public int prescription_id { get; set; }
        public int patient_id { get; set; }
        public int doctor_id { get; set; }
        public int medicine_id { get; set; }
        public string dosage { get; set; }
    }
}
