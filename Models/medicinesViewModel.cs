using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models

{
    public class medicinesViewModel
    {
        [Key]
        public int medicine_id { get; set; }
        public string medicine_name { get; set; }
        public decimal price { get; set; }
    }
}

