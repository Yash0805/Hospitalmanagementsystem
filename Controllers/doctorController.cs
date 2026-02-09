using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class doctorsController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<doctorsViewModel> doctors = DbContext.Doctors
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

                AppDbContext DbContext = new();
                DbContext.Doctors.Add(doctors);
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}