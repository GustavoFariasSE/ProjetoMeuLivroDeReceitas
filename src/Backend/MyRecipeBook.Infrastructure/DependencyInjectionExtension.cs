using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using MyRecipeBook.Infrastructure.Security.PasswordHashing; 

namespace MyRecipeBook.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastrucuture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();

        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

        services.AddScoped<IUnityOfWork, UnityOfWork>();

        services.AddDbContext<MyRecipeBookDbContext>(config =>
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            config.UseSqlServer(connectionString);
        });
    }
}
