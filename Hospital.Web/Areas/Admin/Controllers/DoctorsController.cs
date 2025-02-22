using Hospital.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorsController : Controller
    {
        private IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index(int pageNumber,int pageSize)
        {
            return View(_doctorService.GetAll(pageNumber,pageSize));
        }

        public IActionResult AddTiming ()
        {
            Timing timing= new Timing();    
            List<SelectListItem> MorningShiftStart= new List<SelectListItem>();
            List<SelectListItem> MorningShiftEnd= new List<SelectListItem>();
            List<SelectListItem> AfterNoonShiftEnd= new List<SelectListItem>();
            List<SelectListItem> AfterNoonShiftStart= new List<SelectListItem>();

            for (int i = 1; i <11; i++)
            {
                MorningShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            
            for (int i = 1; i <13; i++)
            {
                MorningShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 13; i < 16; i++)
            {
                AfterNoonShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 13; i < 18; i++)
            {
                AfterNoonShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.morningStart=new SelectList(MorningShiftStart,"Value","Text");
            ViewBag.morningEnd = new SelectList(MorningShiftStart, "Value", "Text");
            ViewBag.evenStart = new SelectList(MorningShiftStart, "Value", "Text");
            ViewBag.evenEnd = new SelectList(MorningShiftStart, "Value", "Text");
            TimingViewModel vm = new TimingViewModel();
            vm.ScheduleDate=DateTime.Now;   
            vm.ScheduleDate=vm.ScheduleDate.AddDays(1);
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if(claims!=null)
            {
                vm.Doctor.Id = claims.Value;
                _doctorService.AddTiming(vm);
            }

            return RedirectToAction("Index");

        }
    }
}
