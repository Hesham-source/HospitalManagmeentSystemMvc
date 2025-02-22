using Hospital.Models;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilites
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManger;
        private RoleManager<IdentityRole> _roleManger;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManger,
            RoleManager<IdentityRole> roleManger,ApplicationDbContext context)
        {
            _userManger = userManger;
            _roleManger = roleManger;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                   _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (!_roleManger.RoleExistsAsync(WebsiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManger.CreateAsync(new IdentityRole(WebsiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManger.CreateAsync(new IdentityRole(WebsiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManger.CreateAsync(new IdentityRole(WebsiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();
                _userManger.CreateAsync(new ApplicationUser
                {
UserName="Hesham",
Email="ihesham828@gmail.com",

                },"Hesham@12345").GetAwaiter().GetResult();

                var AppUser = _context.applicationUsers.FirstOrDefault(x => x.Email == "ihesham828@gmail.com");
                if(AppUser !=null)
                {
                    _userManger.AddToRoleAsync(AppUser, WebsiteRoles.WebSite_Admin).GetAwaiter().GetResult(); 
                }
            
            }
        }
    }
}
