using CP.Abstractions.Models;
using CP.Abstractions.Services.Business;
using CP.Abstractions.Services.Data;
using CP.Abstractions.Services.Infrastructure;
using CP.Business;
using CP.Data.Mock;
using CP.Data.Sql;
using CP.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace CP.Bootstrapper
{
    public class BootstrapperCommon
    {
        public static IServiceCollection AddDependenciesToServiceCollection(IServiceCollection services, AppSettings appSettings)
        {
            //add appsettings
            services.AddSingleton(appSettings);

            //add mapper
            services.AddScoped<IMappingService, MappingService>();

            //data layer services
            if (appSettings.Settings.UseMockForDatabase)
            {
                services.AddScoped<IQuestionDataService, MockQuestionDataService>();
                services.AddScoped<IProfileDataService, MockProfileDataService>();
                services.AddScoped<IProgramDataService, MockProgramDataService>();
            }
            else
            {
                services.AddScoped<IQuestionDataService, DBQuestionDataService>();
                services.AddScoped<IProfileDataService, DBProfileDataService>();
                services.AddScoped<IProgramDataService, DBProgramDataService>();
            }

            //business logic services
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProgramService, ProgramService>();


            return services;
        }
    }
}
