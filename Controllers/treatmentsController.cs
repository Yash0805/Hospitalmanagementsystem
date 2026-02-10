using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class treatmentsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public treatmentsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IReadOnlyList<treatmentsViewModel> treatments = _dbContext.Treatments
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

                _dbContext.Treatments.Add(treatments);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
