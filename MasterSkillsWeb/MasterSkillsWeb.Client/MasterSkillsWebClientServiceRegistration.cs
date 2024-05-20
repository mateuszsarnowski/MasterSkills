using MasterSkillsWeb.Client.HttpRepository;
using MasterSkillsWeb.Client.HttpRepository.Interfaces;
using Microsoft.Extensions.Http;

namespace MasterSkillsWeb.Client
{
    public static class MasterSkillsWebClientServiceRegistration
    {
        public static IServiceCollection AddWebClientServices(this IServiceCollection services, Uri uri)
        {
            services.AddHttpClient("MasterSkillsWebApi", client =>
            {
                client.BaseAddress = uri;
                client.Timeout = TimeSpan.FromMinutes(5);
            });

            services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("MasterSkillsWebApi"));

            services.AddScoped<INoteHttpRepository, NoteHttpRepository>();
            return services;
        }

    }
}
