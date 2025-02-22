using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool dispose = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.dispose = true;
        }


        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> Repo = new GenericREpository<T>(_context);
            return Repo;
        }

        public void save()
        {
           _context.SaveChanges();
        }
    }
}
