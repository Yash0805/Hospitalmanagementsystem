using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class doctorsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public doctorsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IReadOnlyList<doctorsViewModel> doctors = _dbContext.Doctors
                .Select(d => new doctorsViewModel
                {
                    doctor_id = d.doctor_id,
                    doctor_name = d.doctor_name,
                    specialization = d.specialization,
                    phone = d.phone
                }).ToList();

            return View(doctors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(doctorsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctors = new doctors
                {
                    doctor_name = model.doctor_name,
                    specialization = model.specialization,
                    phone = model.phone
                };

                _dbContext.Doctors.Add(doctors);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}