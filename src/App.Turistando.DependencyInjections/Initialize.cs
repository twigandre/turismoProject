using App.Turistando.Database.SqlServer;
using App.Turistando.Database.SqlServer.Entities;
using App.Turistando.Database.SqlServer.Repository;
using App.Turistando.Logic.Authentication;
using App.Turistando.Logic.FileUpload;
using App.Turistando.Logic.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Turistando.DependencyInjections
{
    public class Initialize
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            string connectionStringAzure = Environment.GetEnvironmentVariable("azureConnectionString", EnvironmentVariableTarget.Machine);

            services.AddDbContext<TuristandoSqlServerContext>(options => {
                options.UseSqlServer(connectionStringAzure);
            });

            #region Context

            services.AddScoped<TuristandoSqlServerContext>();

            #endregion

            #region Logic
            services.AddScoped<IToken, Token>();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IFileUpload, FileUpload>();
            #endregion

            #region Entitites
            services.AddScoped<IRepository<UsuariosCadastradosEntity>, EntityRepository<UsuariosCadastradosEntity>>();
            #endregion

        }
    }
}
