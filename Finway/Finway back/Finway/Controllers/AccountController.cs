using Finway.extantion;
using Finway.Interfaces;
using Finway.Models;
using Finway.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public AccountController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        [HttpPost("Login")]
        public async Task<AuthModel> Login(LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new() {Message= "User Name and Password are Requires" };


                var result = await _UnitOfWork.AccountService.Login(model);

                return result;

            }
            catch (Exception ex)
            {

                return new() { Message = "User Name and Password are Requires" };
            }


        }
    }
}
