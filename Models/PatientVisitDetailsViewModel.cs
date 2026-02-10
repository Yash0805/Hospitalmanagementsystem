using System.ComponentModel.DataAnnotations;    
namespace WebApplication5.Models
{
    public class PatientVisitDetailsViewModel
    {
        internal string one;

        [Key]
        //patients table
        public int patient_id { get; set; }
        public required string? patient_name { get; set; }
        public required string Patient_phone { get; set; }
        //doctors table
        public required string doctor_name { get; set; }
        public required string Doctor_phone { get; set; }
        //appointments table
        public DateOnly appointment_date { get; set; }
        //treatments table
        public string treatment_details { get; set; }
        public DateOnly treatment_date { get; set; }
    }
}
