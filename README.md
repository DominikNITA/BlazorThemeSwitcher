[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](https://github.com/DominikNITA/Blazor.ThemeSwitcher/blob/master/LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.0.1-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorThemeSwitcher/)
# BlazorThemeSwitcher
Simple and flexible way to allow your Blazor app to switch between light and dark mode. If you are looking for more elaborate solution check MatBlazor at https://www.matblazor.com/Themes
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
@using ThemeSwitcher
```
# Sample usage
With this extension you can switch themes in several ways: 
**1. Changing css variables values with JSInterop**
   - Create a class implementing ```ThemeSwitcher.IVariableSetter``` interface with this template:
          
```C#
using variablesList = List<(string variableName, (string light, string dark) possibleValues)>;
public class VariableSetter : ThemeSwitcher.IVariableSetter
{
  public variablesList Variables { get { return GetVariables(); } }

  private variablesList GetVariables()
  {
    var variables = new variablesList();
    //variables.Add(("var",("light","dark")));
    variables.Add(("bg-color",("#FFFFFF", "#121212")));
    variables.Add(("bf-text", ("#000000", "#FFFFFF")));
    variables.Add(("outline", ("#6200EE", "#BB86FC")));
    return variables;
  }
}
```

   - ```variableName``` corresponds to any CSS variable declared in root scope in any file linked in static ```index.html```. For the previous example, you can insert following line in ```wwwroot/css/site.css```:
          
```css
:root {
  //set initial values to default theme(in this case the light one)
  --bg-color: #FFFFFF;
  --bg-text: #000000;
  --outline: #6200EE;
}
//Example use of css variables
.content {
    padding-top: 1.1rem;
    background: var(--bg-color);
    color: var(--bg-text);
}
```

   - Then add following lines to ```ConfigureServices``` in ```Startup.cs```:

```C#
services.AddSingleton<ThemeSwitcher.IVariableSetter, VariableSetter>();
services.AddSingleton<ThemeSwitcher.ThemeState>();
```
   - You will use **ThemeState class** to change to another theme. Attention, **ThemeState** does not implement any kind of server-side or client-side storage between sessions, so you have to implement on your own.
   Add the following line to ```<body>``` in ```index.html```:
```
<script src="_content/BlazorThemeSwitcher/JsInterop.js"></script>
```
   - Below you will find example of Razor Component using **ThemeState**
``` C#
@page "/"
@inject ThemeState ThemeState;

<h1>Hello, Darkness!</h1>
<button class="btn btn-primary" @onclick="ThemeState.ChangeTheme">Change Theme</button>

@code{
    protected override void OnInitialized()
    {
        //Simulates loading saved data from storage
        ThemeState.ChangeTheme(Theme.Light);
    }
}
```
**2. Use UsedTheme or ThemeName**
   - ```UsedTheme``` returns ```Theme``` enumerator (Light or Dark)
   - ```ThemeName``` returns string value of ```UsedTheme``` in lowercase ("light" or "dark")
```C#
@page "/"
@inject ThemeState ThemeState;

@if(ThemeState.UsedTheme == Theme.Light){
   //This header is only displayed in Light Theme 
   <h1>Consider changing to dark theme with the button below</h1>
}

<div class="@ThemeState.ThemeName">
   This div is styled with .light or .dark classes depending on current theme!
</div>

<button class="btn btn-primary" @onclick="ThemeState.ChangeTheme">Change Theme</button>

@code{
    protected override void OnInitialized()
    {
        //Simulates loading saved data from storage
        ThemeState.ChangeTheme(Theme.Light);
    }
}
```
With CSS code for previous snippet:
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

**1.0.0**
> - Initial release
