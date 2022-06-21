using App.Turistando.Utils.ViewModels;

namespace App.Turistando.Logic.Authentication
{
    public interface IAuthentication
    {
        UserViewModel Get(string username, string password);
    }
}
