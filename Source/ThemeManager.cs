using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodo.BlazorThemeSwitcher
{
    public class ThemeManager
    {
        public event Action ThemeChanged;
        public string[] Themes { get => _themes; private set => _themes = value; }
        private string[] _themes;
        int _currentThemeIndex;

        public ThemeManager(ICollection<string> themes)
        {
            Themes = themes.ToArray();
        }

        public string GetCurrentTheme()
        {
            return Themes[_currentThemeIndex];
        }

        /// <summary>
        /// Switch theme automatically to the next one
        /// </summary>
        /// <returns>New selected theme name</returns>
        public string SwitchTheme()
        {
            _currentThemeIndex += 1;
            _currentThemeIndex %= Themes.Length;
            CallThemeChange();
            return GetCurrentTheme();
        }

        /// <summary>
        /// Switch theme automatically to the one passed in parameter
        /// </summary>
        /// <returns>Currently selected theme name</returns>
        public string SwitchTheme(string theme)
        {
            int i = Array.IndexOf(Themes, theme);
            if (i > 0)
            {
                _currentThemeIndex = i;
            }
            else
            {
                Console.Error.WriteLine($"Theme {theme} is not found!");
            }
            CallThemeChange();
            return GetCurrentTheme();
        }
        private void CallThemeChange()
        {
            ThemeChanged?.Invoke();
        }
    }
}
