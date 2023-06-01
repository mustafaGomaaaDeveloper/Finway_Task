using Finway.Models.DTO;

namespace Finway.Interfaces
{
    public interface IAccountService
    {
        Task<AuthModel> Login(LoginDTO model);
    }
}
