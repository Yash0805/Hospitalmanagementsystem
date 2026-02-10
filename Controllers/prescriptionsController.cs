using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class prescriptionsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public prescriptionsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IReadOnlyList<prescriptionsViewModel> prescriptions = _dbContext.Prescriptions
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


                _dbContext.Prescriptions.Add(prescriptions);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

