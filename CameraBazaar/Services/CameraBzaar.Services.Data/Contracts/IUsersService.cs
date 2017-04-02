namespace CameraBzaar.Services.Data.Contracts
{
    using CamBazaar.Data.Models;

    public interface IUsersService
    {
        User GetUserById(string id);
    }
}