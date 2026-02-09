using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Data
{
    public class medicines
    {
        [Key]
        public int medicine_id { get; set; }
        public string medicine_name { get; set; }
        public decimal price { get; set; }
    }
}
