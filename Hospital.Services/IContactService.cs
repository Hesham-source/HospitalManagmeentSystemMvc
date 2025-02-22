using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
   public interface IContactService
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetContactById(int id);
        void UpdateContactInfo(ContactViewModel ContactViewModel);
        void DeleteContact(int id);
        void InsertContact(ContactViewModel ContactViewModel);

    }
}
