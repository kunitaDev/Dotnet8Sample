using Application.Common.Interfaces.Users;
using Infastructure.Common.Options;
using Infastructure.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<UsersClientOptions>(configuration.GetSection("ExternalService:UsersClient"));
            services.AddHttpClient<IUsersClient, UsersClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["ExternalService:UsersClient:ServerUrl"]);
                client.Timeout = new TimeSpan(0, 0, 60);
                client.DefaultRequestHeaders.Clear();
            });
            //services.AddHttpClient();
            return services;
        }
    }
}
