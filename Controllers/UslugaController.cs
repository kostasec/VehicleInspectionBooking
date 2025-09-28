using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PregledPlus.Models;
using PregledPlus.Repository;

namespace PregledPlus.Controllers
{
    public class UslugaController : Controller
    {
        private IUnitOfWork unitOfWork;
        private IToastNotification toast;
        public UslugaController(IUnitOfWork _unitOfWork, IToastNotification _toast)
        {
            unitOfWork = _unitOfWork;
            toast = _toast;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var item = unitOfWork.UslugaRepository.GetAll();
            return Json(item);
        }
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Usluga item = unitOfWork.UslugaRepository.GetFirstOrDefault(x => x.id == id);
            return Json(item);
        }
        [HttpPost]

        public IActionResult Create(Usluga usluga)
        {
            
            if (ModelState.IsValid)
            {
                unitOfWork.UslugaRepository.Add(usluga);
                unitOfWork.Save();
                toast.AddSuccessToastMessage("Usluga je uspesno dodata!");
                return RedirectToAction("UslugaView", "CMS");
            }
            else
            {
                toast.AddErrorToastMessage("Doslo je do greske pri kreiranju usluge!");
                return RedirectToAction("UslugaView", "CMS");
            }

        }
        public IActionResult Update(Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UslugaRepository.Update(usluga);
                unitOfWork.Save();
                toast.AddSuccessToastMessage("Usluga je uspesno izmenjen!");
                return RedirectToAction("UslugaView", "CMS");
            }
            else
            {
                toast.AddErrorToastMessage("Doslo je do greske pri izmeni usluge!");
                return RedirectToAction("UslugaView", "CMS");
            }
        }
        public IActionResult Delete(int id)
        {

            Usluga prod = unitOfWork.UslugaRepository.GetFirstOrDefault(x => x.id == id);
            if (prod != null)
            {
                unitOfWork.UslugaRepository.Delete(prod);
                unitOfWork.Save();
            }
            toast.AddSuccessToastMessage("Termin je uspesno izbrisan!");
            return RedirectToAction("UslugaView", "CMS");
        }


    }
}
