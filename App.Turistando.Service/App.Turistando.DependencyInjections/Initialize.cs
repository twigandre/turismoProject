using App.Turistando.Logic.Authentication;
using App.Turistando.Logic.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Turistando.DependencyInjections
{
    public class Initialize
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {

            #region Logic
                services.AddScoped<IToken, Token>();
                services.AddScoped<IAuthentication, Authentication>();
            #endregion

            #region Entitites

            #endregion

        }
    }
}
