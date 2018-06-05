using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceNet
{
    public static class MicroServiceNetInjection
    {
        public static void Configure(Assembly assembly, IServiceCollection services)
        {
            foreach (var inter in assembly.GetTypes().Where(i => i.IsInterface))
            {
                var implement = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .FirstOrDefault(p => inter.IsAssignableFrom(p) &&
                                         p.GetInterfaces().Contains(typeof(IMicroService)) &&
                                        !p.IsInterface);
                if (implement != null)
                {
                    services.AddSingleton(inter, implement);
                }
            }
        }
    }
}
