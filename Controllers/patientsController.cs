using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;    
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class patientsController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<patientsViewModel> patients = DbContext.patients
                .Select(p => new patientsViewModel
                {
                    patient_id = p.patient_id,
                    patient_name = p.patient_name,
                    gender = p.gender,
                    age = p.age,
                    phone = p.phone
                }).ToList();

            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(patientsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patients = new patients
                    {
                    patient_name = model.patient_name,
                    gender = model.gender,
                    age = model.age,
                    phone = model.phone
                };

                AppDbContext DbContext = new();
                DbContext.patients.Add(patients);
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}