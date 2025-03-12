using FluentValidation;
using ASPReactCQRS.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ASPReactCQRS.Application
{
     public static class ServiceExtensions
 {
     public static void ConfigureApplication(this IServiceCollection services)
     {
         services.AddAutoMapper(Assembly.GetExecutingAssembly());
         services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
     }
 }
}