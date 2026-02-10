using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication3.Controllers
{
    public sealed class medicinesController : Controller
    {
        private readonly AppDbContext _dbContext;
        public medicinesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IReadOnlyList<medicinesViewModel> medicines = _dbContext.Medicines
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

                _dbContext.Medicines.Add(medicines);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

