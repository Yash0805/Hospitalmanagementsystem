using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Data
{
    public class doctors
    {
        [Key]
        public int doctor_id { get; set; }
        public required string doctor_name { get; set; }
        public string specialization { get; set; }
        public string phone { get; set; }

    }
}
