using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ruffys.HostingExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllTransientImplementations<TInterface>(this IServiceCollection services)
        {
            return AddAllTransientImplementations<TInterface>(services, typeof(TInterface).Assembly);
        }

        public static IServiceCollection AddAllTransientImplementations<TInterface>(this IServiceCollection services, Type AssemblyType)
        {
            return AddAllTransientImplementations<TInterface>(services, AssemblyType.Assembly);
        }

        public static IServiceCollection AddAllTransientImplementations<TInterface>(this IServiceCollection services, Assembly? assembly = null)
        {
            assembly ??= Assembly.GetExecutingAssembly();

            // Finde alle Klassen, die TInterface implementieren und nicht abstrakt sind.
            var typesToRegister = assembly.GetTypes()
                .Where(t => typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass);

            foreach (var type in typesToRegister)
            {
                services.AddTransient(typeof(TInterface), type);
            }

            return services;
        }

        public static IServiceCollection AddAllSingletonImplementations<TInterface>(this IServiceCollection services)
        {
            return AddAllSingletonImplementations<TInterface>(services, typeof(TInterface).Assembly);
        }

        public static IServiceCollection AddAllSingletonImplementations<TInterface>(this IServiceCollection services, Type assembly)
        {
            return AddAllSingletonImplementations<TInterface>(services, assembly.Assembly);
        }

        public static IServiceCollection AddAllSingletonImplementations<TInterface>(this IServiceCollection services, Assembly? assembly = null)
        {
            assembly ??= Assembly.GetExecutingAssembly();

            // Finde alle Klassen, die TInterface implementieren und nicht abstrakt sind.
            var typesToRegister = assembly.GetTypes()
                .Where(t => typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass);

            foreach (var type in typesToRegister)
            {
                services.AddSingleton(typeof(TInterface), type);
            }

            return services;
        }
    }
}
