using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Service
{
    public class PatientVisitDetailsService 
    {
        private readonly AppDbContext _context;
        public PatientVisitDetailsService(AppDbContext Context)
        {
            _context = Context;
        }
        
        public IReadOnlyList<PatientVisitDetailsViewModel> GetPatientVisitDetail()
        {
            var data =  (
                from a in _context.Appointments
                join p in _context.patients on a.patient_id equals p.patient_id
                join d in _context.Doctors on a.doctor_id equals d.doctor_id
                join t in _context.Treatments on p.patient_id equals t.patient_id
                select new PatientVisitDetailsViewModel
                {
                    patient_id = p.patient_id,
                    patient_name = p.patient_name,
                    Patient_phone = p.phone,

                    doctor_name = d.doctor_name,
                    Doctor_phone = d.phone,

                    appointment_date = a.appointment_date,

                    treatment_details = t.treatment_details,
                    treatment_date = t.treatment_date,
                }
                ).ToList();
            return data;
        }
    }

}