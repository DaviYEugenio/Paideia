using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Paideia.Application.Interfaces;
using Paideia.Application.Services;
using Paideia.Domain.Interfaces;
using Paideia.Infra.CrossCutting.Identity;
using Paideia.Infra.CrossCutting.Identity.Interface;
using Paideia.Infra.Data.Repository;

namespace Paideia.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void Registers(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITraningAppService, TraningAppService>();
            services.AddScoped<ITeacherAppService, TeacherAppService>();
            services.AddScoped<ITeacherDisciplinesAppService, TeacherDisciplinesAppService>();
            services.AddScoped<IModelAppService, ModelAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ISendEmailAppService, SendEmailAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IDropoutsAppService, DropoutsAppService>();
            services.AddScoped<IDisciplineAppService, DisciplineAppService>();
            services.AddScoped<IClassAppService, ClassAppService>();
            services.AddScoped<ICandidateAppService, CandidateAppService>();
            services.AddScoped<ICoordinatorAppService, CoordinatorAppService>();
            services.AddScoped<ICepAppService, CepAppService>();
            services.AddScoped<IChurchAppService, ChurchAppService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ITrainingModelRepository, TrainingModelRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherDisciplinesRepository, TeacherDisciplinesRepository>();            
            services.AddScoped<ICoordinatorRepository, CoordinatorRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IChurchRepository, ChurchRepository>();
            services.AddScoped<IDropoutsRepository, DropoutsRepository>();
            services.AddScoped<IDisciplineRepository, DisciplineRepository>(); 
            services.AddScoped<ITrainingClassRepository, TrainingClassRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();
        }
    }

}