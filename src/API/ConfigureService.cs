using API.Filters;
using Application.Users.GetUsers;
using Domain.Infrastructure.Users;
using FluentValidation.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureService
{
    public static IServiceCollection AddComponentServiceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddControllers(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
        //services.AddOpenApiDocument(configure =>
        //{
        //    configure.Title = "Dotnet8Sample API";
        //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //    {
        //        Type = OpenApiSecuritySchemeType.ApiKey,
        //        Name = "Authorization",
        //        In = OpenApiSecurityApiKeyLocation.Header,
        //        Description = "Type into the textbox: Bearer {your JWT token}."
        //    });
        //    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        //});

        services.AddAutoMapper(option =>
        {
            option.CreateMap<GetUsersResponse, GetUsersDto>();
            option.CreateMap<Domain.Infrastructure.Users.GetUsersResponse.UserData, Application.Users.GetUsers.GetUsersDto.UserData>();
            option.CreateMap<Domain.Infrastructure.Users.GetUsersResponse.Support, Application.Users.GetUsers.GetUsersDto.Support>();
        });
        return services;
    }
}