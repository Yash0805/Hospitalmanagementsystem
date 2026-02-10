using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class billsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public billsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IReadOnlyList<billsViewModel> bills = _dbContext.Bills
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
                _dbContext.Bills.Add(bills);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model); 
        }
    }
}
