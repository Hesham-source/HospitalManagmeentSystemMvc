using Microsoft.AspNetCore.Mvc;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital.ViewModels;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactsController : Controller
    {
        private IContactService _contactService;
        private IHospitalInfo _hospitalInfo;
        public ContactsController(IContactService contactService, IHospitalInfo hospitalInfo)
        {
            _contactService = contactService;
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 2)
        {
            return View(_contactService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = _hospitalInfo.GetAllItems();
            var viewModel = _contactService.GetContactById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _contactService.UpdateContactInfo(vm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospital=new SelectList(_hospitalInfo.GetAllItems(),"Id","Name");   
            return View();

        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
           
           
               _contactService.InsertContact(vm);
          
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }

    }
}
