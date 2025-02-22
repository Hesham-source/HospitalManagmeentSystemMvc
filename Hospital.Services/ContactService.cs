using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> vmlist = new List<ContactViewModel>();
            try
            {
                int ExcludedRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Contact>()
                                           .GetAll(includeProperties:"Hospital")
                                           .Skip(ExcludedRecord)
                                           .Take(pageSize)
                                           .ToList();

                totalCount = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;


                vmlist = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<ContactViewModel>()
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,

            };
            return Result;
        }

        public ContactViewModel GetContactById(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            var vm = new ContactViewModel(model);
            return vm;
        }

        public void InsertContact(ContactViewModel ContactViewModel)
        {
            var model = new ContactViewModel().ConvertViewModel(ContactViewModel);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateContactInfo(ContactViewModel ContactViewModel)
        {
            throw new NotImplementedException();
        }

        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> contacts)
        {
            return contacts.Select(Model => new ContactViewModel(Model)).ToList();
        }
    }
}
