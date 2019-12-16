using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorThemeSwitcher_Sample
{
    using variablesList = List<(string variableName, (string light, string dark) possibleValues)>;
    public class VariableSetter : ThemeSwitcher.IVariableSetter
    {
        public variablesList Variables { get { return GetVariables(); } }

        private variablesList GetVariables()
        {
            var variables = new variablesList();
            //variables.Add(("var",("light","dark")));
            variables.Add(("bg-color",("#FFFFFF", "#121212")));
            variables.Add(("bg-text", ("#000000", "#FFFFFF")));
            variables.Add(("outline", ("#6200EE", "#BB86FC")));
            return variables;
        }
    }
}
