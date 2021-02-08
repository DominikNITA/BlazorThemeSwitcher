using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo.BlazorThemeSwitcher
{
    public static class Extensions
    {
        public static IServiceCollection AddThemeSwitcher(this IServiceCollection serviceCollection, ICollection<string> themes)
        {
            return serviceCollection.AddSingleton(new ThemeManager(themes));
        }

        public static IServiceCollection AddThemeSwitcher(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton(new ThemeManager(new string[] { "light", "dark" }));
        }
    }
}
