using GameAPI.Application.Services.AutoMapper;
using GameAPI.Application.UseCases.Players.GainExperience;
using GameAPI.Application.UseCases.Players.Get;
using GameAPI.Application.UseCases.Players.Register;
using GameAPI.Application.UseCases.Players.Remove;
using Microsoft.Extensions.DependencyInjection;

namespace GameAPI.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AutoMapper(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetPlayerUseCase, GetPlayerUseCase>();
            services.AddScoped<RegisterPlayerUseCase>();
            services.AddScoped<RemoveUseCase>();
            services.AddScoped<GainExperienceUseCase>();
            services.AddScoped<GetPlayerUseCase>();
        }

        private static void AutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
    }
}
