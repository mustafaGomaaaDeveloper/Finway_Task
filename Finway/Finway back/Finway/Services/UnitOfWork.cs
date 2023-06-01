using AutoMapper;
using Finway.extantion;
using Finway.Interfaces;
using Finway.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Finway.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPerson Person { get; set; }
        public IAccountService AccountService { get; set; }
        public IJWTService JWTService { get; set; }

        private readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context, IMapper mapper ,UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,IOptions<JWT> jwt)
        {
            _context = context;
            Person = new PersonService(_context,mapper);
            AccountService = new AccountService(this,userManager);
            JWTService = new JWTService(userManager,jwt);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
