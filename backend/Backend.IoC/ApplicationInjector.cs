using FluentValidation;
using System.Reflection;
using Backend.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Backend.Application.Behaviors;

namespace Backend.IoC
{
    public static class ApplicationInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // AutoMapper
            var mapper = AutoMapperConfiguration.ConfigureMappings();
            services.AddAutoMapper(x => mapper.CreateMapper(), Assembly.Load("Backend.Application"));

            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.Load("Backend.Application"));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.Load("Backend.Application"));

            return services;
        }
    }
}
