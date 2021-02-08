[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](https://github.com/DominikNITA/Blazor.ThemeSwitcher/blob/master/LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v2.0.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorThemeSwitcher/)
# BlazorThemeSwitcher
Simple and flexible way to allow your Blazor app to switch between light and dark mode. If you are looking for more elaborated solution check MatBlazor at https://www.matblazor.com/Themes
# Nuget Gallery
The Nuget package page can be found at https://www.nuget.org/packages/BlazorThemeSwitcher/
# Installation
To install ```BlazorThemeSwitcher``` using NPM run the following command
```
Install-Package BlazorThemeSwitcher
```
To install ```BlazorThemeSwitcher``` using .NET CLI run the following command
```
dotnet add package BlazorThemeSwitcher
```
After you have installed the package add the following line in the ```_Imports.razor``` file
```
@using Dodo.BlazorThemeSwitcher
```
# Sample usage
   - First add theme switching service (with selected theme names) inside Program.cs. This service initializes ThemeManager that will be used for switching between themes:
   ``` C#
       public class Program
       {
         public static async Task Main(string[] args)
         {
            ...
            builder.Services.AddThemeSwitcher(new List<string>() { "light", "dark" });
            await builder.Build().RunAsync();
         }
       }
   ```
   - Below you will find example of Razor Component using **ThemeManager**
``` C#
@page "/"
@inject ThemeManager TM

<h1>Hello, Darkness!</h1>
<button class="btn btn-primary" @onclick="@(()=>TM.SwitchTheme())">Change Theme</button>
<div class="@TM.GetCurrentTheme()">
    This div is styled with .light or .dark classes depending on current theme!
</div>
```

   - With CSS code for previous snippet:
```css
    .light{
        outline: 2px dotted red;
    }

    .dark{
        outline: 3px dashed white;
        font-size: 2rem;
    }

```
          
# Feedback
   Feel free to use this component and provide your valuable feedback. If you encounter any bugs open an issue and discuss.
# Release notes
- **2.0.0**
   - Breaking changes with upgrade to .NET 5
   - CSS variable switching is deprecated (meaning no JavaScript dependency)
- **1.0.1**
   - Minor fixes
- **1.0.0**
   - Initial release
