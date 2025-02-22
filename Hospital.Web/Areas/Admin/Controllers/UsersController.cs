using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _applicationUser;

        public UsersController(IApplicationUserService applicationUser)
        {
            _applicationUser = applicationUser;
        }

        public IActionResult Index(int PageNumber=1,int PageSize=4)
        {
            return View(_applicationUser.GetAll(PageNumber, PageSize));
        }

        public IActionResult GetDoctors(int PageNumber = 1, int PageSize = 4)
        {
            return View(_applicationUser.GetAllDoctors(PageNumber, PageSize));
        }
    }
}
