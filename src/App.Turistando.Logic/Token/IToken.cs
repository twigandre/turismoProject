using App.Turistando.Utils.ViewModels;

namespace App.Turistando.Logic.Token
{
    public interface IToken
    {
        string GenerateToken(UserViewModel user);
    }
}
