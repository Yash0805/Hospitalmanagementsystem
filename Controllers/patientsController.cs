using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;    
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class patientsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public patientsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IReadOnlyList<patientsViewModel> patients = _dbContext.patients
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


                _dbContext.patients.Add(patients);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}