namespace Finway.Interfaces
{
    public interface IUnitOfWork
    {
        IPerson Person { get; set; }
        IAccountService AccountService { get; set; }
        IJWTService JWTService { get; set; }

        int Complete();
    }
}
