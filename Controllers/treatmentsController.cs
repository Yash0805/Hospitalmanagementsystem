using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class treatmentsController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<treatmentsViewModel> treatments = DbContext.Treatments
                .Select(t => new treatmentsViewModel
                {
                    treatment_id = t.treatment_id,
                    patient_id = t.patient_id,
                    doctor_id = t.doctor_id,
                    treatment_details = t.treatment_details,
                    treatment_date = t.treatment_date,
                    cost = t.cost,
                }).ToList();

            return View(treatments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(treatmentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var treatments = new treatments
                {
                    patient_id = model.patient_id,
                    doctor_id = model.doctor_id,
                    treatment_details = model.treatment_details,
                    treatment_date = model.treatment_date,
                    cost = model.cost,
                };

                AppDbContext DbContext = new();
                DbContext.Treatments.Add(treatments);
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
