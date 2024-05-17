using MasterSkill.Application.Contracts.Persistence;
using MasterSkills.Persistence.DatabaseContext;
using MasterSkills.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasterSkills.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MasterSkillsDatabaseContext>(options =>
        {
            // Use appsettings.json
            options.UseSqlServer(configuration.GetConnectionString("MasterSkillsConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<INoteCategoryRepository, NoteCategoryRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();

        return services;
    }
}
