using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalsController : Controller
    {
        private IHospitalInfo _hospitalInfo;

        public HospitalsController(IHospitalInfo hospitalInfo)
        {
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pageNumber=1,int pageSize=2)
        {
            return View(_hospitalInfo.GetAll(pageNumber,pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalInfoViewModel vm)
        {
            if(ModelState.IsValid)
            {
                _hospitalInfo.InsertHospitalInfo(vm);   
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel=_hospitalInfo.GetHospitalById(id);    
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel vm)
        {
          _hospitalInfo.UpdateHospitalInfo(vm); 

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _hospitalInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
        }
    }
}
