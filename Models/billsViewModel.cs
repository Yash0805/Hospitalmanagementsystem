using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models
{
    public class billsViewModel
    {
        [Key]
        public int bill_id { get; set; }
        public int patient_id { get; set; }
        public decimal total_amount { get; set; }
        public DateOnly bill_date { get; set; }
    }
}
