using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class appointmentsController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<appointmentsViewModel> appointments = DbContext.Appointments
                .Select(a => new appointmentsViewModel
                {
                    appointment_id = a.appointment_id,
                    patient_id = a.patient_id,
                    doctor_id = a.doctor_id,
                    appointment_date = a.appointment_date
                }).ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(appointmentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointments = new appointments
                {
                    patient_id = model.patient_id,
                    doctor_id = model.doctor_id,
                    appointment_date = model.appointment_date
                };

                AppDbContext DbContext = new();
                DbContext.Appointments.Add(appointments);
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}


