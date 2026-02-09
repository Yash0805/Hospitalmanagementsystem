using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class medicinesController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<medicinesViewModel> medicines = DbContext.Medicines
                .Select(m => new medicinesViewModel
                {
                    medicine_id = m.medicine_id,
                    medicine_name = m.medicine_name,
                    price = m.price,
                }).ToList();

            return View(medicines);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(medicinesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var medicines = new medicines
                {
                    medicine_name = model.medicine_name,
                    price = model.price,
                };

                AppDbContext DbContext = new();
                DbContext.Medicines.Add(medicines);
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

