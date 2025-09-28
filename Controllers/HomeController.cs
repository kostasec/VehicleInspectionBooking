using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PregledPlus.Models;
using PregledPlus.Repository;
using System.Diagnostics;

namespace PregledPlus.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private IUnitOfWork unitOfWork;
        private IToastNotification toast;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork _unitOfWork, IToastNotification _toast)
		{
			_logger = logger;
            unitOfWork = _unitOfWork;
            toast = _toast;
        }
        
        public IActionResult Index()
		{
			return View();
		}
		[Route("zakazivanje-termina")]
		public IActionResult zakazivanje_termina()
		{
			return View("Zakazivanje");
		}
        [Route("kontakt")]
        public IActionResult Kontakt()
        {
            return View();
        }

        public IActionResult addEmail(Newsletter ns)
		{
			if(ModelState.IsValid) 
			{
				unitOfWork.NewsletterRepository.Add(ns);
				unitOfWork.Save();
                toast.AddSuccessToastMessage("Email je uspesno dodat!");
                return View("Index");
			}
			else
			{
                toast.AddErrorToastMessage("Doslo je do greske pri dodavanju emaila!");
				return RedirectToAction("Index");

            }
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}