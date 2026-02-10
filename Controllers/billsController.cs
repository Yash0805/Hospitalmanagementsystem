using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class billsController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<billsViewModel> bills = DbContext.Bills
                .Select(b => new billsViewModel
                {
                    bill_id = b.bill_id,
                    patient_id = b.patient_id,
                    total_amount = b.total_amount,
                    bill_date = b.bill_date
                }).ToList();
            return View(bills);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(billsViewModel model)
        {
            if(ModelState.IsValid)
            {
                var bills = new bills
                {
                    patient_id = model.patient_id,
                    total_amount = model.total_amount,
                    bill_date = model.bill_date
                };
                AppDbContext DbContext = new();
                DbContext.Bills.Add(bills);
                DbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model); 
        }
    }
}
