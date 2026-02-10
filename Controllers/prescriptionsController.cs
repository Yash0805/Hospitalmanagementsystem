using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class prescriptionsController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<prescriptionsViewModel> prescriptions = DbContext.Prescriptions
                .Select(p => new prescriptionsViewModel
                {
                    prescription_id = p.prescription_id,
                    patient_id = p.patient_id,
                    doctor_id = p.doctor_id,
                    medicine_id = p.medicine_id,
                    dosage = p.dosage
                }).ToList();

            return View(prescriptions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(prescriptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var prescriptions = new prescriptions
                {
                    patient_id = model.patient_id,
                    doctor_id = model.doctor_id,
                    medicine_id = model.medicine_id,
                    dosage = model.dosage
                };

                AppDbContext DbContext = new();
                DbContext.Prescriptions.Add(prescriptions);
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

