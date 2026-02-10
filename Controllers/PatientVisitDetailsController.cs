using Microsoft.AspNetCore.Mvc;
using WebApplication5.Service;
using WebApplication5.Models;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    public sealed class PatientVisitDetailsController : Controller
    {
        private readonly PatientVisitDetailsService _context;
        public PatientVisitDetailsController(PatientVisitDetailsService Context)
        {
            _context = Context ?? throw new ArgumentNullException(nameof(Context));
        }
        
        public IActionResult Index()
        {
           
            IReadOnlyList<PatientVisitDetailsViewModel> patientVisitDetails = _context.GetPatientVisitDetail();
            return View(patientVisitDetails);
        }
    }
}
